using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.SecurityExpert;

namespace WebControlAcceso.SERVICES.Services.SecurityExpert
{
    public class GetCustomFields<T> : IGetCustomFields<T>
    {
        private readonly IDataService<List<T>> _dataService;

        public GetCustomFields(IDataService<List<T>> dataService)
        {
            _dataService = dataService;
        }

        public async Task<List<T>> GetCustomField(List<SeLoad> model, string url)
        {
            try
            {
                Base.EndPoint = url;
                var result = await _dataService.Post(model);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
