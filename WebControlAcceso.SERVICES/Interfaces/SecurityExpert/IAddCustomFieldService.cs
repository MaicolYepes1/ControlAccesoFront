using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IAddCustomFieldService<T>
    {
        Task<bool> Add(object objrequest, string Url);
    }
}
