using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetRecordGroup<T>
    {
        Task<List<T>> Get(string Url);
    }
}
