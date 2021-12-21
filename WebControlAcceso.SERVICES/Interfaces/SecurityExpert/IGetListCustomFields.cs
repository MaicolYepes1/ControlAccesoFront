using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetListCustomFields<T>
    {
        Task<List<T>> Get(object objrequest, string Url);
    }
}
