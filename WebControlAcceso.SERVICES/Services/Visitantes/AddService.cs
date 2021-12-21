using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.Visitantes;

namespace WebControlAcceso.SERVICES.Services.Visitantes
{
    public class AddService<T> : IAddService<T>
    {
        #region Dependencys
        private readonly IDataService<T> _dataServices;
        #endregion

        #region Constructor
        public AddService(IDataService<T> data)
        {
            _dataServices = data;
        }
        #endregion

        #region Methods
        public async Task<bool> AddOrUpdate(object objrequest, string Url)
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
