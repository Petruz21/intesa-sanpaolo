using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using sanpaolo.Dto.ContoDto;
using sanpaolo.Models;
using sanpaolo.Utility;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace sanpaolo.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Response<string>> Login(string email, string password)
        {
            Response<string> response = new Response<string>();
            Utente utente = await _context.Utenti.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
            if (utente == null)
            {
                response.Success = false;
                response.Message = "Utente non trovato";
            }
            else if (!VerifyPasswordHash(password, utente.PasswordHash, utente.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Password sbagliata, riprovare";
            }
            else
            {
                response.Data = CreateToken(utente);
            }

            return response;
        }

        public async Task<Response<int>> Register(Utente utente, string password)
        {
            Response<int> response = new Response<int>();

            if (await UtenteExists(utente.Email, utente.NumeroCartaIdentita))
            {
                response.Success = false;
                response.Message = "Utente già registrato";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            utente.PasswordHash = passwordHash;
            utente.PasswordSalt = passwordSalt;
            utente.Banca = await _context.Banca.FirstOrDefaultAsync();
            utente.Conto = new Conto
            {
                UtenteId = utente.Id,
                Iban = "IT09000456GH234405640000027",
               
            };
            utente.Conto.Salvadanaio = new Salvadanaio
            {
                ContoId = utente.Conto.Id
            };

            await _context.Utenti.AddAsync(utente);
            await _context.SaveChangesAsync();
            response.Data = utente.Id;
            return response;
        }

        public async Task<bool> UtenteExists(string email, string numeroCartaIdentita)
        {
            if (await _context.Utenti.AnyAsync(x => x.Email.ToLower() == email.ToLower() || x.NumeroCartaIdentita == numeroCartaIdentita.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string CreateToken(Utente utente)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, utente.Id.ToString()),
                new Claim(ClaimTypes.Name, utente.Email)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8 
            .GetBytes(_configuration.GetSection("AppSettings:Token").Value)); // aggiungere la chiave segreta che sta dentro appsettings.json

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token); //token;
        }

        
    }
}
