using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;

namespace WebControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetCustomFields<T>
    {
        Task<List<T>> GetCustomField(List<SeLoad> model,string url);
    }
}
