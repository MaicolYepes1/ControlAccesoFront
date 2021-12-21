using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.SiteId;

namespace WebControlAcceso.SERVICES.Services.SiteId
{
    public class SiteIdService : ISiteIdService
    {
        private readonly IDataServiceSE<SiteDto> dataServices;
        private readonly IDataService<SiteDto> _dataServices;

        public SiteIdService(IDataServiceSE<SiteDto> _IDataServices, IDataService<SiteDto> dataService)
        {
            dataServices = _IDataServices;
            _dataServices = dataService;
        }

        public async Task<List<SiteDto>> GetSiteId()
        {
            try
            {
                Base.EndPoint = "/api/GetSiteID";
                var result = await _dataServices.Get();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<SiteDto>> GetRecordGroups(List<SeLoad> model)
        {
            try
            {
               var url =  "api/Security/spListRecordGroupss";
                var result = await dataServices.Post(url, model);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
