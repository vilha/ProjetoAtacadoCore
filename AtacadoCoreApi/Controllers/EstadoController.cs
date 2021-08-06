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
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : GenericBaseController<EstadoPoco>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public EstadoController(AtacadoContext contexto) :
            base(contexto)
        {
            this.servico = new EstadoService(this.contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<EstadoPoco> Get()
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
        public EstadoPoco Get(int id)
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
        public EstadoPoco Post(EstadoPoco poco)
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
        public EstadoPoco Put(EstadoPoco poco)
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
        public EstadoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }

    }
}
