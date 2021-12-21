using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Constants;
using WebControlAcceso.MODELS.Dtos;

namespace WebControlAcceso.WEB
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Device, EquipoDto>()
                .ForMember(d => d.Color, o => o.MapFrom(s => s.ColourEq))
                .ForMember(d => d.Detalle, o => o.MapFrom(s => s.DetailsEq))
                .ForMember(d => d.Marca, o => o.MapFrom(s => s.BrandEq))
                .ForMember(d => d.Modelo, o => o.MapFrom(s => s.ModelEq))
                .ForMember(d => d.Serial, o => o.MapFrom(s => s.SerialEq));

            CreateMap<Vehicle, VehiculosVisitanteDto>()
                .ForMember(d => d.Color, o => o.MapFrom(s => s.ColourVehEdit))
                .ForMember(d => d.Detalle, o => o.MapFrom(s => s.DetailsVehEdit))
                .ForMember(d => d.Marca, o => o.MapFrom(s => s.BrandVehEdit))
                .ForMember(d => d.Placa, o => o.MapFrom(s => s.PlateVehEdit));

            CreateMap<Arl, ArlDto>()
             .ForMember(d => d.Detalle, o => o.MapFrom(s => s.DetailsArl))
             .ForMember(d => d.Documento, o => o.MapFrom(s => s.ArlPdf))
             .ForMember(d => d.FechaExpiracion, o => o.MapFrom(s => s.DateExpArl));

            CreateMap<UsserInfoDto, UsserInfoDto>();
        }
    }
}
