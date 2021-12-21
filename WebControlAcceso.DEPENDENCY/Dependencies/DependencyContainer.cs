using Microsoft.Extensions.DependencyInjection;
using WebControlAcceso.MODELS.Constants;
using WebControlAcceso.MODELS.Dtos;
using WebControlAcceso.MODELS.Loads;
using WebControlAcceso.PROVIDERS.Data;
using WebControlAcceso.PROVIDERS.Interfaces;
using WebControlAcceso.SERVICES.Interfaces.Login;
using WebControlAcceso.SERVICES.Interfaces.SecurityExpert;
using WebControlAcceso.SERVICES.Interfaces.SiteId;
using WebControlAcceso.SERVICES.Interfaces.Visitantes;
using WebControlAcceso.SERVICES.Services.Login;
using WebControlAcceso.SERVICES.Services.SecurityExpert;
using WebControlAcceso.SERVICES.Services.SiteId;
using WebControlAcceso.SERVICES.Services.Visitantes;

namespace WebControlAcceso.DEPENDENCY.Dependencies
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IVisitantesService, VisitantesService>();
            services.AddScoped<ISiteIdService, SiteIdService>();
            services.AddScoped<IPeolpeSeTargetService, PeolpeSeTargetService>();
            services.AddScoped<IGetCustomFields<CustomFieldsDto>, GetCustomFields<CustomFieldsDto>>();
            services.AddScoped<IGetInfoUser, GetInfoUser>();
            services.AddScoped<IUpdateUserSe, UpdateUserSe>();
            services.AddScoped<IGetLevelSites, GetLevelSites>();
            services.AddScoped<IGetAsignTarjet, GetAsignTarjet>();
            services.AddScoped<IGetLevelsById, GetLevelsById>();
            services.AddScoped<IAddSecurity<UsserInfoDto>, AddSecurity<UsserInfoDto>>();
            services.AddScoped<IAddSecurity<DependencyDto>, AddSecurity<DependencyDto>>();
            services.AddScoped<IAddCustomFieldService<CustomFieldGroupData>, AddCustomFieldService<CustomFieldGroupData>>();
            #endregion

            #region Repository
            services.AddScoped<IDataService<UserDto>,DataService<UserDto>>();
            services.AddScoped<IDataService<Response>,DataService<Response>>();
            services.AddScoped<IDataService<VisitanteDto>,DataService<VisitanteDto>>();
            services.AddScoped<IDataService<CustomFieldsDto>,DataService<CustomFieldsDto>>();
            services.AddScoped<IDataService<UserAccessLevelGroupDatumDto>,DataService<UserAccessLevelGroupDatumDto>>();
            //services.AddScoped<IDataServiceSE<SiteDto>,DataServiceSE<SiteDto>>();
            services.AddScoped<IDataService<UserSeDto>,DataService<UserSeDto>>();
            services.AddScoped<IDataService<SiteDto>,DataService<SiteDto>>();
            services.AddScoped<IDataService<SeInfoDto>,DataService<SeInfoDto>>();
            services.AddScoped<IDataService<InfoDto>, DataService<InfoDto>>();
            services.AddScoped<IDataService<HelperDto>,DataService<HelperDto>>();
            services.AddScoped<IDataService<LevelsID>,DataService<LevelsID>>();
            services.AddScoped<IDataService<bool>,DataService<bool>>();
            services.AddScoped<IDataService<string>,DataService<string>>();
           // services.AddScoped<IDataServiceSE<CustomFieldsDto>,DataServiceSE<CustomFieldsDto>>();
            services.AddScoped<IDataServiceSE<LevelSitesDto>,DataServiceSE<LevelSitesDto>>();
            services.AddScoped<IDataServiceSE<RecordGroupsDto>,DataServiceSE<RecordGroupsDto>>();
            services.AddScoped<IDataServiceSE<UsserResponse>,DataServiceSE<UsserResponse>>();
            services.AddScoped(typeof(IDataService<>),typeof(DataService<>));
            services.AddScoped(typeof(IDataServiceSE<>),typeof(DataServiceSE<>));
            services.AddScoped<IAddService<IncidenteDto>, AddService<IncidenteDto>>();
            services.AddScoped<IAddService<EquipoDto>, AddService<EquipoDto>>();
            services.AddScoped<IAddService<VehiculosVisitanteDto>, AddService<VehiculosVisitanteDto>>();
            services.AddScoped<IAddService<CustomFieldGroupData>, AddService<CustomFieldGroupData>>();
            services.AddScoped<IAddService<UserCardNumberGroupDatumDto>, AddService<UserCardNumberGroupDatumDto>>();
            services.AddScoped<IAddService<UserAccessLevelGroupDatumDto>, AddService<UserAccessLevelGroupDatumDto>>();
            services.AddScoped<IAddService<ArlDto>, AddService<ArlDto>>();
            services.AddScoped<IGetListCustomFields<CustomFieldListGroupDatumDto>, GetListCustomFields<CustomFieldListGroupDatumDto>>();
            services.AddScoped<IGetRecordGroup<RecordGroupsDto>, GetRecordGroup<RecordGroupsDto>>();
            #endregion

        }

    }
}
