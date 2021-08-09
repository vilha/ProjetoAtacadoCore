using AtacadoCore.DAL.Models;
using AtacadoCore.MAPA.Estoque;
using AtacadoCore.POCO.Estoque;
using AtacadoCore.REPO.Estoque;
using AtacadoCore.SERV.Ancestral;
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

        public SubcategoriaPoco Obter(int id)
        {
            Subcategorium dominio = this.repositorio.Read(subcat => subcat.Subcatid == id);
            SubcategoriaPoco poco = this.mapa.GetMapper.Map<SubcategoriaPoco>(dominio);
            return poco;
        }

        public IEnumerable<SubcategoriaPoco> ObterTodos()
        {
            List<Subcategorium> lista = this.repositorio.Browsable().ToList();
            List<SubcategoriaPoco> listaPoco = this.mapa.GetMapper.Map<List<SubcategoriaPoco>>(lista);
            return listaPoco;
        }

        public SubcategoriaPoco Atualizar(SubcategoriaPoco poco)
        {
            Subcategorium subcat = this.mapa.GetMapper.Map<Subcategorium>(poco);
            Subcategorium alterada = this.repositorio.Edit(subcat);
            SubcategoriaPoco novoPoco = this.mapa.GetMapper.Map<SubcategoriaPoco>(alterada);
            return novoPoco;
        }

        public SubcategoriaPoco Excluir(int id)
        {
            Subcategorium subcat = this.repositorio.Read(reg => reg.Subcatid == id);
            SubcategoriaPoco poco = this.mapa.GetMapper.Map<SubcategoriaPoco>(subcat);
            this.repositorio.Delete(subcat);
            return poco;
        }

        public SubcategoriaPoco Incluir(SubcategoriaPoco poco)
        {
            Subcategorium subcat = this.mapa.GetMapper.Map<Subcategorium>(poco);
            Subcategorium nova = this.repositorio.Add(subcat);
            SubcategoriaPoco novoPoco = this.mapa.GetMapper.Map<SubcategoriaPoco>(nova);
            return novoPoco;
        }

        public void Dispose()
        {
            this.repositorio = null;
            this.mapa = null;
        }
    }
}
