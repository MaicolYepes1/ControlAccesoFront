using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.SecurityExpert;

namespace WebControlAcceso.SERVICES.Services.SecurityExpert
{
    public class GetListCustomFields<T> : IGetListCustomFields<T>
    {
        #region Dependencys
        private readonly IDataService<T> _dataServices;
        #endregion

        #region Constructor
        public GetListCustomFields(IDataService<T> data)
        {
            _dataServices = data;
        }
        #endregion

        #region Methods
        public async Task<List<T>> Get(object objrequest, string Url)
        {
            try
            {
                Base.EndPoint = Url;
                var result = await _dataServices.PostList(objrequest);
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
