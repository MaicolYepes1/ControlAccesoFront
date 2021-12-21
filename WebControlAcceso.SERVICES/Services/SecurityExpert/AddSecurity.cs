using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.MODELS.Constants;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.SecurityExpert;

namespace WebControlAcceso.SERVICES.Services.SecurityExpert
{
    public class AddSecurity<T> : IAddSecurity<T>
    {
        #region Dependency
        private readonly IDataServiceSE<UsserResponse> _dataService;
        private readonly IDataServiceSE<T> _dataServicea;
        private readonly IDataService<Response> _data;
        #endregion

        #region Constructor
        public AddSecurity(IDataServiceSE<UsserResponse> dataService, IDataServiceSE<T> dataSe, IDataService<Response> data)
        {
            _dataService = dataService;
            _dataServicea = dataSe;
            _data = data;
        }
        #endregion

        #region Methods
        public async Task<Response> Add(object model, string url)
        {
            Base.EndPoint = url;
            var result = await _data.Post(model);
            return result;
        }

        public async Task<List<T>> AddDependency(object model, string url)
        {
            //Base.EndPoint = url;
            var result = await _dataServicea.Post(url, model);
            return result;
        }
        #endregion
    }
}
