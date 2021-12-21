using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetAsignTarjet
    {
        Task<List<string>> Get(string Url);
    }
}
