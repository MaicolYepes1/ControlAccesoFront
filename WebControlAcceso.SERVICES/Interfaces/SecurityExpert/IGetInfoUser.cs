using System.Threading.Tasks;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;

namespace WebControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetInfoUser
    {
        Task<InfoDto> Get(RequestLoad request, string Url);
    }
}
