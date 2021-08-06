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
    public class MicroregiaoService :
       GenericService<DbContext, Microregiao, MicroregiaoPoco>,
       IService<MicroregiaoPoco>
    {
        public MicroregiaoService(DbContext contexto)
        {
            this.repositorio = new MicroregiaoRepository(contexto);
            this.mapa = new MicroregiaoMap();
        }

        public MicroregiaoPoco Obter(int id)
        {
            Microregiao dominio = this.repositorio.Read(mic => mic.MicroregiaoId == id);
            MicroregiaoPoco poco = this.mapa.GetMapper.Map<MicroregiaoPoco>(dominio);
            return poco;
        }

        public IEnumerable<MicroregiaoPoco> ObterTodos()
        {
            List<Microregiao> lista = this.repositorio.Browsable().ToList();
            List<MicroregiaoPoco> listaPoco = this.mapa.GetMapper.Map<List<MicroregiaoPoco>>(lista);
            return listaPoco;
        }

        public MicroregiaoPoco Atualizar(MicroregiaoPoco poco)
        {
            Microregiao micro = this.mapa.GetMapper.Map<Microregiao>(poco);
            Microregiao alterada = this.repositorio.Edit(micro);
            MicroregiaoPoco novoPoco = this.mapa.GetMapper.Map<MicroregiaoPoco>(alterada);
            return novoPoco;
        }

        public MicroregiaoPoco Excluir(int id)
        {
            Microregiao micro = this.repositorio.Read(reg => reg.MicroregiaoId == id);
            MicroregiaoPoco poco = this.mapa.GetMapper.Map<MicroregiaoPoco>(micro);
            this.repositorio.Delete(micro);
            return poco;
        }

        public MicroregiaoPoco Incluir(MicroregiaoPoco poco)
        {
            Microregiao micro = this.mapa.GetMapper.Map<Microregiao>(poco);
            Microregiao nova = this.repositorio.Add(micro);
            MicroregiaoPoco novoPoco = this.mapa.GetMapper.Map<MicroregiaoPoco>(nova);
            return novoPoco;
        }

     
    }
}
