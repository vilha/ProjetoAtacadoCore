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
    [Route("api/[controller]")]
    [ApiController]
    public class RegiaoController : GenericBaseController<RegiaoPoco>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public RegiaoController(AtacadoContext contexto):
            base(contexto)
        {
            this.servico = new RegiaoService(this.contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public  List<RegiaoPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public  RegiaoPoco Get(int id)
        {
            return this.servico.Obter(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public  RegiaoPoco Post(RegiaoPoco poco)
        {
            return this.servico.Incluir(poco);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public RegiaoPoco Put(RegiaoPoco poco)
        {
            return this.servico.Atualizar(poco);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public RegiaoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
        
    }
}

