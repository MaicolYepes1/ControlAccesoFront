using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Constants;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.SecurityExpert;
using WebControlAcceso.SERVICES.Interfaces.SiteId;
using WebControlAcceso.SERVICES.Interfaces.Visitantes;

namespace WebControlAcceso.WEB.Controllers.SecurityExpert
{
    public class SecurityExpertController : Controller
    {
        private readonly IPeolpeSeTargetService _get;
        private readonly IGetCustomFields<CustomFieldsDto> _custom;
        private readonly ISiteIdService _site;
        private readonly IGetLevelSites _level;
        private readonly IGetListCustomFields<CustomFieldListGroupDatumDto> _customFields;
        private readonly IGetRecordGroup<RecordGroupsDto> _record;
        private readonly IConfiguration _config;
        private readonly IAddSecurity<UsserInfoDto> _addUsser;
        private readonly IMapper _mapper;
        private readonly IAddService<CustomFieldGroupData> _addCustomUser;
        private readonly IAddService<UserCardNumberGroupDatumDto> _addTarjet;
        private readonly IAddService<UserAccessLevelGroupDatumDto> _addLevels;
        private readonly IGetAsignTarjet _tarjetsAsign;
        private readonly IGetInfoUser _infoUser;
        private readonly IUpdateUserSe _update;
        private readonly IGetLevelsById _getLevels;


        public SecurityExpertController(IPeolpeSeTargetService get, IGetCustomFields<CustomFieldsDto> custom, ISiteIdService site,
            IGetLevelSites level, IGetListCustomFields<CustomFieldListGroupDatumDto> customFields, IConfiguration config,
            IGetRecordGroup<RecordGroupsDto> record, IMapper mapper, IAddSecurity<UsserInfoDto> add, IAddService<CustomFieldGroupData> addCustomUser,
            IAddService<UserCardNumberGroupDatumDto> addTarjet, IAddService<UserAccessLevelGroupDatumDto> addLevels,
            IGetAsignTarjet tarjetsAsign, IGetInfoUser infoUser, IUpdateUserSe update, IGetLevelsById getLevels)
        {
            _get = get;
            _custom = custom;
            _site = site;
            _level = level;
            _customFields = customFields;
            _config = config;
            _record = record;
            _mapper = mapper;
            _addUsser = add;
            _addCustomUser = addCustomUser;
            _addTarjet = addTarjet;
            _addLevels = addLevels;
            _tarjetsAsign = tarjetsAsign;
            _infoUser = infoUser;
            _update = update;
            _getLevels = getLevels;
        }
        public IActionResult Index(string model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllPeople()
        {
            var result = await _get.GetAllPeople();
            if (result != null)
            {
                return Ok(result);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomFields(string jsonobtj)
        {
            var siteId = Convert.ToInt32(jsonobtj);
            List<SeLoad> model = new List<SeLoad>();
            model.Add(new SeLoad
            {
                SiteID = siteId
            });
            var Url = _config.GetValue<string>("New");
            var result = await _custom.GetCustomField(model, Url);
            if (result != null)
            {
                return Ok(result);
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> GetInfoUser(string jsonobtj)
        {
            RequestLoad model = JsonConvert.DeserializeObject<RequestLoad>(jsonobtj);
            var Url = _config.GetValue<string>("UrlGetInfoUser");
            var result = await _infoUser.Get(model, Url);
            if (result != null)
            {
                return Ok(result);
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> GetAsignTarjet()
        {
            var Url = _config.GetValue<string>("GetAsignTarjet");
            var result = await _tarjetsAsign.Get(Url);
            if (result != null)
            {
                return Ok(result);
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> GetRecordGruops()
        {
            var Url = _config.GetValue<string>("UrlRecordGroups");
            var result = await _record.Get(Url);
            if (result != null)
            {
                return Ok(result);
            }
            return Ok(false);
        }

        [HttpPost]
        public async Task<IActionResult> GetListCustom(string jsonobtj)
        {
            var customId = Convert.ToInt32(jsonobtj);
            CustomLoad model = new CustomLoad();
            model.CustomFieldId = customId;
            var Url = _config.GetValue<string>("UrlListCustomFields");
            var result = await _customFields.Get(model, Url);
            if (result != null)
            {
                return Ok(result);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddSecurity(string jsonobtj)
        {
            try
            {
                List<CustomFieldGroupData> Dependency = new List<CustomFieldGroupData>();
                SeInfoDto vis = JsonConvert.DeserializeObject<SeInfoDto>(jsonobtj);
                if (vis.UserInfo != null)
                {
                    UsserInfoDto infoU = new UsserInfoDto();
                    vis.UserInfo[0].lastOperator = HttpContext.Session.GetString("Operator");
                    var Url = _config.GetValue<string>("UrlAddSe");
                    var UrlAdd = _config.GetValue<string>("AddCustoms");
                    var UrlTarjet = _config.GetValue<string>("AddTarjet");
                    var UrlLevelAccess = _config.GetValue<string>("UrlLevelAccess");
                    infoU = vis.UserInfo[0];
                    var result = await _addUsser.Add(infoU, Url);
                    if (result != null)
                    {
                        for (int i = 0; i < vis.Dependency.Count; i++)
                        {
                            if (vis.Dependency[i].Area != null)
                            {
                                vis.Dependency[i].Area[i].UserID = result.UserId;
                                var resultDepeArea = await _addCustomUser.AddOrUpdate(vis.Dependency[i].Area, UrlAdd);
                            }
                            if (vis.Dependency[i].Dependencia != null)
                            {
                                vis.Dependency[i].Dependencia[i].UserID = result.UserId;
                                var resultDepeArea = await _addCustomUser.AddOrUpdate(vis.Dependency[i].Dependencia, UrlAdd);
                            }
                            if (vis.Dependency[i].Identificacion != null)
                            {
                                vis.Dependency[i].Identificacion[i].UserID = result.UserId;
                                var resultDepeArea = await _addCustomUser.AddOrUpdate(vis.Dependency[i].Identificacion, UrlAdd);
                            }

                            for (int t = 0; t < vis.InfoTarjet.Count; t++)
                            {
                                vis.InfoTarjet[i].UserId = result.UserId;
                            }
                            var resultTarjet = await _addTarjet.AddOrUpdate(vis.InfoTarjet, UrlTarjet);
                            for (int l = 0; l < vis.LevelAccess.Count; l++)
                            {
                                vis.LevelAccess[l].Site = vis.UserInfo[0].siteID;
                                vis.LevelAccess[l].UserId = result.UserId;
                            }
                            var ResultLevels = await _addTarjet.AddOrUpdate(vis.LevelAccess, UrlLevelAccess);
                        }
                    }

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
        public async Task<IActionResult> UpdateSecurity(string jsonobtj)
        {
            try
            {
                SeInfoDto vis = JsonConvert.DeserializeObject<SeInfoDto>(jsonobtj);
                if (vis.UserInfo != null)
                {
                    vis.UserInfo[0].lastOperator = HttpContext.Session.GetString("Operator");
                    var Url = _config.GetValue<string>("UrlUpdateUserSe");
                    var result = await _update.Update(vis, Url);
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
        public async Task<IActionResult> GetLevelsById(string jsonobtj)
        {
            try
            {
                List<LevelsID> model = JsonConvert.DeserializeObject<List<LevelsID>>(jsonobtj);
                var Url = _config.GetValue<string>("UrlGetLevelsByID");
                var result = await _getLevels.Get(model, Url);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw;
            }
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
        public async Task<IActionResult> GetLevelSites(string jsonobtj)
        {
            var siteId = Convert.ToInt32(jsonobtj);
            var Url = _config.GetValue<string>("New2");
            SeLoad model = new SeLoad();
            model.SiteID = siteId;
            var result = await _level.GetLevels(model, Url);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok(null);
            }

        }
    }
}
