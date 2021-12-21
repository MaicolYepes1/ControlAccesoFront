using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.SecurityExpert;

namespace WebControlAcceso.SERVICES.Services.SecurityExpert
{
    public class GetRecordGroup<T> : IGetRecordGroup<T>
    {
        #region Dependencys
        private readonly IDataService<T> _dataServices;
        #endregion

        #region Constructor
        public GetRecordGroup(IDataService<T> data)
        {
            _dataServices = data;
        }
        #endregion

        #region Methods
        public async Task<List<T>> Get(string Url)
        {
            try
            {
                Base.EndPoint = Url;
                var result = await _dataServices.Get();
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
