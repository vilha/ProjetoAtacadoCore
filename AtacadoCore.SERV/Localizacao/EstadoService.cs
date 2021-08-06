using AtacadoCore.DAL.Models;
using AtacadoCore.MAPA.Localizacao;
using AtacadoCore.POCO.Localizacao;
using AtacadoCore.REPO.Localizacao;
using AtacadoCore.SERV.Ancestral.Atacado.Service.Ancestor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.SERV.Localizacao
{
    public class EstadoService :
        GenericService<DbContext, UnidadesFederacao, EstadoPoco>,
        IService<EstadoPoco>
    {
        public EstadoService(DbContext contexto)
        {
            this.repositorio = new EstadoRepository(contexto);
            this.mapa = new EstadoMapping();
        }

        public EstadoPoco Obter(int id)
        {
            UnidadesFederacao dominio = this.repositorio.Read(unifed => unifed.Ufid == id);
            EstadoPoco poco = this.mapa.GetMapper.Map<EstadoPoco>(dominio);
            return poco;
        }

        public IEnumerable<EstadoPoco> ObterTodos()
        {
            List<UnidadesFederacao> lista = this.repositorio.Browsable().ToList();
            List<EstadoPoco> listaPoco = this.mapa.GetMapper.Map<List<EstadoPoco>>(lista);
            return listaPoco;
        }

        public EstadoPoco Atualizar(EstadoPoco poco)
        {
            UnidadesFederacao unifed = this.mapa.GetMapper.Map<UnidadesFederacao>(poco);
            UnidadesFederacao alterada = this.repositorio.Edit(unifed);
            EstadoPoco novoPoco = this.mapa.GetMapper.Map<EstadoPoco>(alterada);
            return novoPoco;
        }

        public EstadoPoco Excluir(int id)
        {
            UnidadesFederacao unifed = this.repositorio.Read(reg => reg.Ufid == id);
            EstadoPoco poco = this.mapa.GetMapper.Map<EstadoPoco>(unifed);
            this.repositorio.Delete(unifed);
            return poco;
        }

        public EstadoPoco Incluir(EstadoPoco poco)
        {
            UnidadesFederacao unifed = this.mapa.GetMapper.Map<UnidadesFederacao>(poco);
            UnidadesFederacao nova = this.repositorio.Add(unifed);
            EstadoPoco novoPoco = this.mapa.GetMapper.Map<EstadoPoco>(nova);
            return novoPoco;
        }

       
    }
}
