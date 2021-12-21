using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.SecurityExpert;

namespace WebControlAcceso.SERVICES.Services.SecurityExpert
{
    public class AddCustomFieldService<T> : IAddCustomFieldService<T>
    {
        #region Dependency
        private readonly IDataService<T> _dataServices;
        #endregion

        #region Constructor
        public AddCustomFieldService(IDataService<T> data)
        {
            _dataServices = data;
        }
        #endregion

        #region Methods
        public async Task<bool> Add(object objrequest, string Url)
        {
            try
            {
                Base.EndPoint = Url;
                var result = await _dataServices.PostBool(objrequest);
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
