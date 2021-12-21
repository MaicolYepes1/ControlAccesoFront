using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebControlAcceso.PROVIDERS.Interfaces
{
    public interface IDataServiceSE<T>
    {
        Task<List<T>> Get(object objrequest = null);
        Task<List<T>> Post(string ur, object objrequest = null);
        Task<bool> PostBool(object objrequest = null);
    }
}
