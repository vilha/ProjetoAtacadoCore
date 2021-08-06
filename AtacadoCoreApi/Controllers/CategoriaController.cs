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
    /// Serviço de Categoria.
    /// </summary>
    [Route("atacado/estoque/categoria")]
    [ApiController]
    public class CategoriaController : GenericBaseController<CategoriaPoco>
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="contexto"></param>
        public CategoriaController(AtacadoContext contexto) :
            base(contexto)
        {
            this.servico = new CategoriaService(this.contexto);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<CategoriaPoco> Get()
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
        public CategoriaPoco Get(int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter subcategorias por id da categoria.
        /// </summary>
        /// <param name="catid">Chave primaria da categoria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{catid:int}/subcategorias")]
        public List<SubcategoriaPoco> GetSubcategoriaPorID(int catid)
        {
            SubcategoriaService srv = new SubcategoriaService(this.contexto);
            List<SubcategoriaPoco> subcategoriaPoco = srv.ObterTodos()
                .Where(sub => sub.CategoriaID == catid).ToList();
            return subcategoriaPoco;
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public CategoriaPoco Post([FromBody] CategoriaPoco poco)
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
        public CategoriaPoco Put([FromBody] CategoriaPoco poco)
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
        public CategoriaPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}