using System;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.SecurityExpert;

namespace WebControlAcceso.SERVICES.Services.SecurityExpert
{
    public class GetInfoUser : IGetInfoUser
    {
        #region Dependencys
        private readonly IDataService<InfoDto> _dataServices;
        #endregion

        #region Constructor
        public GetInfoUser(IDataService<InfoDto> data)
        {
            _dataServices = data;
        }
        #endregion

        #region Methods
        public async Task<InfoDto> Get(RequestLoad request, string Url)
        {
            try
            {
                Base.EndPoint = Url;
                var result = await _dataServices.Post(request);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}
