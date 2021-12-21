using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Base;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.Visitantes;

namespace WebControlAcceso.SERVICES.Services.Visitantes
{
    public class VisitantesService : IVisitantesService
    {
        #region Dependencias
        private readonly IDataService<VisitanteDto> _dataServices;
        #endregion

        #region Constructor
        public VisitantesService(IDataService<VisitanteDto> dataService)
        {
            _dataServices = dataService;
        }
        #endregion

        #region Metodos
        public async Task<List<VisitanteDto>> Get()
        {
            try
            {
                Base.EndPoint = "api/Visitantes";
                var Visitantes = await _dataServices.Get();

                List<VisitanteDto> lista = new List<VisitanteDto>();
                return Visitantes;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<VisitanteDto> GetInfo(GetInfoLoad getInfoLoad)
        {
            try
            {
                Base.EndPoint = "/api/GetInfoVisitor";
                var Visitantes = await _dataServices.Post(getInfoLoad);
                return Visitantes;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<VisitanteDto> Delete(GetInfoLoad getInfoLoad)
        {
            try
            {
                Base.EndPoint = "/api/DeleteVisitor";
                var Visitantes = await _dataServices.Post(getInfoLoad);
                return Visitantes;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> AccessState(GetInfoLoad getInfoLoad)
        {
            try
            {
                Base.EndPoint = "/api/AccessState";
                var Visitantes = await _dataServices.Post(getInfoLoad);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<VisitanteDto> AddOrUpdate(VisitanteDto info)
        {
            try
            {
                Base.EndPoint = "/api/Visitantes";
                var Visitantes = await _dataServices.Post(info);
                return Visitantes;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
    }
}
