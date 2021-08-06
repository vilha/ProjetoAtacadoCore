using AtacadoCore.DAL.Models;
using AtacadoCore.MAPA.Estoque;
using AtacadoCore.POCO.Estoque;
using AtacadoCore.REPO.Estoque;
using AtacadoCore.SERV.Ancestral.Atacado.Service.Ancestor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.SERV.Estoque
{
    public class SubcategoriaService :
       GenericService<DbContext, Subcategorium, SubcategoriaPoco>,
       IService<SubcategoriaPoco>
    {

        public SubcategoriaService(DbContext contexto)
        {
            this.repositorio = new SubcategoriaRepository(contexto);
            this.mapa = new SubcategoriaMap();
        }

        public SubcategoriaPoco Incluir(SubcategoriaPoco poco)
        {
            Subcategorium cat = this.mapa.GetMapper.Map<Subcategorium>(poco);
            Subcategorium nova = this.repositorio.Add(cat);
            SubcategoriaPoco novoPoco = this.mapa.GetMapper.Map<SubcategoriaPoco>(nova);
            return novoPoco;
        }

        public SubcategoriaPoco Atualizar(SubcategoriaPoco poco)
        {
            Subcategorium cat = this.mapa.GetMapper.Map<Subcategorium>(poco);
            Subcategorium alterada = this.repositorio.Edit(cat);
            SubcategoriaPoco novoPoco = this.mapa.GetMapper.Map<SubcategoriaPoco>(alterada);
            return novoPoco;
        }

        public SubcategoriaPoco Excluir(int id)
        {
            Subcategorium cat = this.repositorio.Read(ct => ct.Catid == id);
            Subcategorium excluida = this.repositorio.Delete(cat);
            SubcategoriaPoco novoPoco = this.mapa.GetMapper.Map<SubcategoriaPoco>(excluida);

            return novoPoco;
        }


        public SubcategoriaPoco Obter(int id)
        {
            Subcategorium dominio = this.repositorio.Read(cat => cat.Catid == id);
            SubcategoriaPoco poco = this.mapa.GetMapper.Map<SubcategoriaPoco>(dominio);
            return poco;

        }

        public IEnumerable<SubcategoriaPoco> ObterTodos()
        {
            List<Subcategorium> lista = this.repositorio.Browse().ToList();
            List<SubcategoriaPoco> listaPoco = this.mapa.GetMapper.Map<List<SubcategoriaPoco>>(lista);
            return listaPoco;

        }

    }
}
