using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;

namespace WebControlAcceso.SERVICES.Interfaces.SiteId
{
    public interface ISiteIdService
    {
        Task<List<SiteDto>> GetSiteId();
        Task<List<SiteDto>> GetRecordGroups(List<SeLoad> model);
    }
}
