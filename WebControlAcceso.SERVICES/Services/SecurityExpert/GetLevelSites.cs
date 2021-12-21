using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.SecurityExpert;

namespace WebControlAcceso.SERVICES.Services.SecurityExpert
{
    public class GetLevelSites : IGetLevelSites
    {
        #region Dependency
        private readonly IDataService<LevelSitesDto> _dataService;
        #endregion

        #region Constructor
        public GetLevelSites(IDataService<LevelSitesDto> dataService)
        {
            _dataService = dataService;
        }
        #endregion

        #region Methods
        public async Task<List<LevelSitesDto>> GetLevels(SeLoad model, string Url)
        {
            try
            {
               Base.EndPoint = Url;
                var result = await _dataService.PostList(model);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
    }
}
