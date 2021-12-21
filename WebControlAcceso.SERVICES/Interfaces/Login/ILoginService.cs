using System.Collections.Generic;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;

namespace WebControlAcceso.SERVICES.Interfaces.Login
{
    public interface ILoginService
    {
        Task<UserDto> Authentication(LoginLoad loginLoad);
        Task<List<HelperDto>> GetLogo();
    }
}
