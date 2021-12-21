using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.MODELS.Loads;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.SecurityExpert;

namespace WebControlAcceso.SERVICES.Services.SecurityExpert
{
    public class GetLevelsById : IGetLevelsById
    {
        #region Dependency
        private readonly IDataService<LevelsID> _dataServices;
        #endregion

        #region Constructor
        public GetLevelsById(IDataService<LevelsID> data)
        {
            _dataServices = data;
        }
        #endregion

        #region Methods
        public async Task<List<LevelsID>> Get(List<LevelsID> model, string url)
        {
            try
            {
                Base.EndPoint = url;
                var res = await _dataServices.PostList(model);
                return res;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
    }
}
