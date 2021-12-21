using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebControlAcceso.SERVICES.Interfaces.Visitantes
{
    public interface IAddService<T>
    {
        Task<bool> AddOrUpdate(object objrequest, string Url);
    }
}
