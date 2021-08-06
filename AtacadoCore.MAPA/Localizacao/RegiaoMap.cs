using AtacadoCore.DAL.Models;
using AtacadoCore.MAPA.Ancestral;
using AtacadoCore.POCO.Estoque;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.MAPA.Estoque
{
    public class RegiaoMap : BaseMapping
    {
        public RegiaoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Regiao, RegiaoPoco>()
                    .ForMember(dst => dst.DataInclusao, map => map.MapFrom(src => src.Datainsert));

                cfg.CreateMap<RegiaoPoco, Regiao>()
                    .ForMember(dst => dst.Datainsert, map => map.MapFrom(src => (src.DataInclusao.HasValue ? src.DataInclusao.Value : DateTime.Now)));
            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}