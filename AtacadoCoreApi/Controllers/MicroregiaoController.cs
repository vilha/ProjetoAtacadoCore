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
    /// Serviço de Estadoes.
    /// </summary>
    [Route("atacado/localizacao/microregiao")]
    [ApiController]
    public class MicroregiaoController : GenericBaseController<MicroregiaoPoco>
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="contexto"></param>
        public MicroregiaoController(AtacadoContext contexto) :
            base(contexto)
        {
            this.servico = new MicroregiaoService(this.contexto);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<MicroregiaoPoco> Get()
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
        public MicroregiaoPoco Get(int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter municipios por id da microregiao.
        /// </summary>
        /// <param name="micid">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{micid:int}/municipios")]
        public List<MunicipioPoco> GetMunicipiosPorID(int micid)
        {
            MunicipioService srv = new MunicipioService(this.contexto);
            List<MunicipioPoco> municipioPoco = srv.ObterTodos()
                .Where(mic => mic.MesoregiaoID == micid).ToList();
            return municipioPoco;
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public MicroregiaoPoco Post([FromBody] MicroregiaoPoco poco)
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
        public MicroregiaoPoco Put([FromBody] MicroregiaoPoco poco)
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
        public MicroregiaoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}