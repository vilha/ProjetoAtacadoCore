using AtacadoCore.DAL.Models;
using AtacadoCore.MAPA.Ancestral;
using AtacadoCore.POCO.Estoque;
using AtacadoCore.POCO.Localizacao;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.MAPA.Localizacao
{
    public class MunicipioMap : BaseMapping
    {
        public MunicipioMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Municipio, MunicipioPoco>();

                cfg.CreateMap<ProdutoPoco, Produto>();
            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
