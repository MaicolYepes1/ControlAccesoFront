using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;

namespace WebControlAcceso.SERVICES.Interfaces.Visitantes
{
    public interface IVisitantesService
    {
        Task<List<VisitanteDto>> Get();
        Task<VisitanteDto> GetInfo(GetInfoLoad model);
        Task<VisitanteDto> AddOrUpdate(VisitanteDto info);
        Task<VisitanteDto> Delete(GetInfoLoad getInfoLoad);
        Task<bool> AccessState(GetInfoLoad getInfoLoad);
    }
}
