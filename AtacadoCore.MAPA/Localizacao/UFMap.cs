using AtacadoCore.DAL.Models;
using AtacadoCore.MAPA.Ancestral;
using AtacadoCore.POCO.Localizacao;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.MAPA.Localizacao
{
    public class UFMap : BaseMapping
    {
        public UFMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UnidadesFederacao, UFPoco>()
                    .ForMember(dst => dst.DataInclusao, map => map.MapFrom(src => src.Datainsert));

                cfg.CreateMap<UFPoco, UnidadesFederacao>()
                    .ForMember(dst => dst.Datainsert, map => map.MapFrom(src => (src.DataInclusao.HasValue ? src.DataInclusao.Value : DateTime.Now)));
            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
