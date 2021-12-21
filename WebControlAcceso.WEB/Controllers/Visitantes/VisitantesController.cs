using AutoMapper;
using ImageMagick;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Constants;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;
using WebControlAcceso.SERVICES.Interfaces.SiteId;
using WebControlAcceso.SERVICES.Interfaces.Visitantes;

namespace WebControlAcceso.WEB.Controllers.Visitantes
{
    [Authorize]
    public class VisitantesController : Controller
    {
        #region Dependencias
        private readonly IVisitantesService _visitante;
        private readonly ISiteIdService _site;
        private readonly IAddService<IncidenteDto> _addIncident;
        private readonly IAddService<EquipoDto> _addDevice;
        private readonly IAddService<VehiculosVisitanteDto> _addVehicle;
        private readonly IAddService<ArlDto> _addArl;
        private readonly IConfiguration _config;
        private readonly IMapper _map;
        #endregion

        #region Constructor
        public VisitantesController(IVisitantesService visitante, ISiteIdService site, IAddService<IncidenteDto> addIncident,
            IConfiguration config, IMapper mapper, IAddService<EquipoDto> addDevise, IAddService<VehiculosVisitanteDto> addVehicle,
            IAddService<ArlDto> arl)
        {
            _visitante = visitante;
            _site = site;
            _addIncident = addIncident;
            _config = config;
            _map = mapper;
            _addDevice = addDevise;
            _addVehicle = addVehicle;
            _addArl = arl;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            var result = await _visitante.Get();
            if (result != null)
            {
                return View(result.OrderBy(x => x.EstadoAcceso == false));
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> GetInfo(string jsonobtj)
        {
            GetInfoLoad model = new GetInfoLoad();
            model.Id = Convert.ToInt32(jsonobtj);
            var result = await _visitante.GetInfo(model);
            if (result != null)
            {
                return Ok(result);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> GetRecordGroups(string jsonobtj)
        {
            List<SeLoad> model = new List<SeLoad>();
            model[0].SiteID = Convert.ToInt32(jsonobtj);
            var result = await _site.GetRecordGroups(model);
            if (result != null)
            {
                return Ok(result);
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> GetSiteId()
        {
            var result = await _site.GetSiteId();
            if (result != null)
            {
                return Ok(result);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddVisitor(string jsonobtj)
        {
            try
            {
                VisitanteDto vis = JsonConvert.DeserializeObject<VisitanteDto>(jsonobtj);
                if (vis.Identificacion != null || vis.Identificacion != "")
                {
                    var result = await _visitante.AddOrUpdate(vis);
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddIncident(string jsonobtj)
        {
            try
            {
                var Url = _config.GetValue<string>("UrlIncidents");
                IncidenteDto inc = JsonConvert.DeserializeObject<IncidenteDto>(jsonobtj);
                var result = await _addIncident.AddOrUpdate(inc, Url);
                return Ok(true);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddArl(string jsonobtj)
        {
            try
            {
                var Url = _config.GetValue<string>("UrlArl");
                Arl arl = JsonConvert.DeserializeObject<Arl>(jsonobtj);
                var obj = _map.Map<ArlDto>(arl);

                var result = await _addArl.AddOrUpdate(obj, Url);
                return Ok(true);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDevices(string jsonobtj)
        {
            try
            {
                var Url = _config.GetValue<string>("UrlDevices");
                Device eqp = JsonConvert.DeserializeObject<Device>(jsonobtj);
                var obj = _map.Map<EquipoDto>(eqp);
                var result = await _addDevice.AddOrUpdate(obj, Url);
                return Ok(true);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle(string jsonobtj)
        {
            try
            {
                var Url = _config.GetValue<string>("UrlVehicle");
                Vehicle veh = JsonConvert.DeserializeObject<Vehicle>(jsonobtj);
                var obj = _map.Map<VehiculosVisitanteDto>(veh);
                var result = await _addVehicle.AddOrUpdate(obj, Url);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }                
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInfo(string jsonobtj)
        {
            try
            {
                GetInfoLoad model = new GetInfoLoad();
                model.Id = Convert.ToInt32(jsonobtj);
                var result = await _visitante.Delete(model);
                return Ok(true);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AccessState(string jsonobtj)
        {
            try
            {
                GetInfoLoad data = JsonConvert.DeserializeObject<GetInfoLoad>(jsonobtj);
                var result = await _visitante.AccessState(data);
                return Ok(true);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
