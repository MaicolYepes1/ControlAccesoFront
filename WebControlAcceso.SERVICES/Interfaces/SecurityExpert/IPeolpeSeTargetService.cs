using System.Collections.Generic;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Dtos;

namespace WebControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IPeolpeSeTargetService
    {
        Task<List<UserSeDto>> GetAllPeople();
    }
}
