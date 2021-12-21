using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.Login;

namespace WebControlAcceso.SERVICES.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IDataService<UserDto> dataServices;
        private readonly IDataService<HelperDto> _help;

        public LoginService(IDataService<UserDto> _IDataServices, IDataService<HelperDto> help)
        {
            dataServices = _IDataServices;
            _help = help;
        }

        public async Task<UserDto> Authentication(LoginLoad loginLoad)
        {
            try
            {
                Base.EndPoint = "api/Login";
                UserDto userDto = await dataServices.GetParameters(loginLoad);
                return userDto;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<List<HelperDto>> GetLogo()
        {
            try
            {
                Base.EndPoint = "api/Helper";
                List<HelperDto> res = await _help.Get();
                return res;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
