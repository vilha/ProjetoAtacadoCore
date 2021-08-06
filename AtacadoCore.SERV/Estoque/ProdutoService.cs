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
    public class ProdutoService :
        GenericService<DbContext, Produto, ProdutoPoco>,
        IService<ProdutoPoco>
    {
        public ProdutoService(DbContext contexto)
        {
            this.repositorio = new ProdutoRepository(contexto);
            this.mapa = new ProdutoMap();
        }

        public ProdutoPoco Obter(int id)
        {
            Produto dominio = this.repositorio.Read(prod => prod.Produtoid == id);
            ProdutoPoco poco = this.mapa.GetMapper.Map<ProdutoPoco>(dominio);
            return poco;
        }

        public IEnumerable<ProdutoPoco> ObterTodos()
        {
            List<Produto> lista = this.repositorio.Browsable().ToList();
            List<ProdutoPoco> listaPoco = this.mapa.GetMapper.Map<List<ProdutoPoco>>(lista);
            return listaPoco;
        }

        public ProdutoPoco Atualizar(ProdutoPoco poco)
        {
            Produto prod = this.mapa.GetMapper.Map<Produto>(poco);
            Produto alterada = this.repositorio.Edit(prod);
            ProdutoPoco novoPoco = this.mapa.GetMapper.Map<ProdutoPoco>(alterada);
            return novoPoco;
        }

        public ProdutoPoco Excluir(int id)
        {
            Produto prod = this.repositorio.Read(reg => reg.Produtoid == id);
            ProdutoPoco poco = this.mapa.GetMapper.Map<ProdutoPoco>(prod);
            this.repositorio.Delete(prod);
            return poco;
        }

        public ProdutoPoco Incluir(ProdutoPoco poco)
        {
            Produto prod = this.mapa.GetMapper.Map<Produto>(poco);
            Produto nova = this.repositorio.Add(prod);
            ProdutoPoco novoPoco = this.mapa.GetMapper.Map<ProdutoPoco>(nova);
            return novoPoco;
        }

    }
}
