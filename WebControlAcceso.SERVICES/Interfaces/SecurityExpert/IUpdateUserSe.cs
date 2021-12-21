using System.Threading.Tasks;
using WebControlAcceso.MODELS.Dtos;

namespace WebControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IUpdateUserSe
    {
        Task<bool> Update(SeInfoDto seInfoDto, string Url);
    }
}
