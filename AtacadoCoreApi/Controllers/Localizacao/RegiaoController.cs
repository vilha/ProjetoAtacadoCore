using AtacadoCore.DAL.Models;
using AtacadoCore.POCO.Localizacao;
using AtacadoCore.SERV.Localizacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtacadoCoreApi.Controllers
{
    /// <summary>
    /// Serviço de Regiao.
    /// </summary>
    [Route("atacado/localizacao/regioes")]
    [ApiController]
    public class RegiaoController : GenericBaseController<RegiaoPoco>
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="contexto"></param>
        public RegiaoController(AtacadoContext contexto) :
            base(contexto)
        {
            this.servico = new RegiaoService(this.contexto);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<RegiaoPoco> Get()
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
        public RegiaoPoco Get([FromRoute] int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter estados por chave primaria da regiao.
        /// </summary>
        /// <param name="regiaoid">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{regiaoid:int}/estados")]
        public List<UFPoco> GetEstadosPorID([FromRoute] int regiaoid)
        {
            UFService srv = new UFService(this.contexto);
            List<UFPoco> ufPoco = srv.ObterTodos()
                .Where(uf => uf.RegiaoID == regiaoid).ToList();
            return ufPoco;
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public RegiaoPoco Post([FromBody] RegiaoPoco poco)
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
        public RegiaoPoco Put([FromBody] RegiaoPoco poco)
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
        public RegiaoPoco Delete([FromRoute] int id)
        {
            return this.servico.Excluir(id);
        }
    }
}