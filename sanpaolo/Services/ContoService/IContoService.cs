using sanpaolo.Dto.ContoDto;
using sanpaolo.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sanpaolo.Services.ContoService
{
    public interface IContoService
    {
        public Task<Response<List<GetContoDto>>> GetAll();
        public Task<Response<GetContoDto>> GetSingle(int IdUtente);
    }
}
