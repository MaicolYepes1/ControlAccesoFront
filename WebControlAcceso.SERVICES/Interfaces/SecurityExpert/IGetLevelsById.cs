using System.Collections.Generic;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Loads;

namespace WebControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetLevelsById
    {
        Task<List<LevelsID>> Get(List<LevelsID> model, string url);
    }
}
