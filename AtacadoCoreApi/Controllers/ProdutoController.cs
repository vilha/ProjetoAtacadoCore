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
    /// 
    /// </summary>
    [Route("atacado/estoque/produto")]
    [ApiController]
    public class ProdutoController : GenericBaseController<ProdutoPoco>
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="contexto"></param>
        public ProdutoController(AtacadoContext contexto) :
            base(contexto)
        {
            this.servico = new ProdutoService(this.contexto);
        }

        /// <summary>
        /// Obter registro por chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public ProdutoPoco Get(int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public ProdutoPoco Post([FromBody] ProdutoPoco poco)
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
        public ProdutoPoco Put([FromBody] ProdutoPoco poco)
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
        public ProdutoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}