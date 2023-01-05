using sanpaolo.Dto.Banca;
using sanpaolo.Utility;
using System.Threading.Tasks;

namespace sanpaolo.Services.BancaService
{
    public interface IBancaService
    {
        public Task<Response<GetBancaDto>> GetBanca();
        public Task<Response<GetBancaDto>> UpdateBanca(UpdateBancaDto updatedBanca);
    }
}
