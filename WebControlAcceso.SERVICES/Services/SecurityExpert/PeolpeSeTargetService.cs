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
    public class PeolpeSeTargetService : IPeolpeSeTargetService
    {
        private readonly IDataService<UserSeDto> _dataService;

        public PeolpeSeTargetService(IDataService<UserSeDto> dataService)
        {
            _dataService = dataService;
        }

        public async Task<List<UserSeDto>> GetAllPeople()
        {
            try
            {
                Base.EndPoint = "api/GetPeople";
                var result = await _dataService.Get();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
