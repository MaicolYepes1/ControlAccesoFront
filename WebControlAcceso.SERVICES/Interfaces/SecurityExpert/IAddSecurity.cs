using System.Collections.Generic;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Constants;

namespace WebControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IAddSecurity<T>
    {
        Task<Response> Add(object model, string url);
        Task<List<T>> AddDependency(object model, string url);
    }
}
