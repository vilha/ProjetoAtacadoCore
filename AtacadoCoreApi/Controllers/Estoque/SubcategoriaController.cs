using AtacadoCore.DAL.Models;
using AtacadoCore.POCO.Estoque;
using AtacadoCore.SERV.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtacadoCoreApi.Controllers
{
    /// <summary>
    /// Serviço de Subcategoria.
    /// </summary>
    [Route("atacado/estoque/subcategoria")]
    [ApiController]
    public class SubcategoriaController : GenericBaseController<SubcategoriaPoco>
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="contexto"></param>
        public SubcategoriaController(AtacadoContext contexto) :
            base(contexto)
        {
            this.servico = new SubcategoriaService(this.contexto);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<SubcategoriaPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
        }

        /// <summary>
        /// Obter registro por chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public SubcategoriaPoco Get(int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter produtos por id da subcategoria.
        /// </summary>
        /// <param name="subcatid">Chave primaria da subcategoria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{subcatid:int}/produtos")]
        public List<ProdutoPoco> GetProdutosPorID(int subcatid)
        {
            ProdutoService srv = new ProdutoService(this.contexto);
            List<ProdutoPoco> produtoPoco = srv.ObterTodos()
                .Where(prod => prod.SubcategoriaID == subcatid).ToList();
            return produtoPoco;
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public SubcategoriaPoco Post([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Incluir(poco);
        }

        /// <summary>
        /// Atualizar um registro.
        /// </summary>
        /// <param name="poco">Objeto a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public SubcategoriaPoco Put([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        /// <summary>
        /// Excluir um registro.
        /// </summary>
        /// <param name="id">Chave primaria.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public SubcategoriaPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}