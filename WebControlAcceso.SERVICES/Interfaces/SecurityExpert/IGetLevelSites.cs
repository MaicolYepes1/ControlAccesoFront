using System.Collections.Generic;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;

namespace WebControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetLevelSites
    {
        Task<List<LevelSitesDto>> GetLevels(SeLoad model, string Url);
    }
}
