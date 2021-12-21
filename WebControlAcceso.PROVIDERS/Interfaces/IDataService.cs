using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Loads;

namespace WebControlAcceso.PROVIDERS.Interfaces
{
    public interface IDataService<T>
    {
        Task<T> GetParameters(LoginLoad loginLoad);
        Task<List<T>> PostList(object objrequest);
        Task<T> Post(object objrequest = null);
        Task<bool> PostBool(object objrequest = null);
        Task<List<T>> Get(object objrequest = null);
    }
}
