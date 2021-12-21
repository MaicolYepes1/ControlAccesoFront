using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.SecurityExpert;

namespace WebControlAcceso.SERVICES.Services.SecurityExpert
{
    public class GetAsignTarjet : IGetAsignTarjet
    {
        #region Dependencys
        private readonly IDataService<string> _dataServices;
        #endregion

        #region Constructor
        public GetAsignTarjet(IDataService<string> data)
        {
            _dataServices = data;
        }
        #endregion

        #region Methods
        public async Task<List<string>> Get(string Url)
        {
            try
            {
                Base.EndPoint = Url;
                var result = await _dataServices.Get(null);
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
