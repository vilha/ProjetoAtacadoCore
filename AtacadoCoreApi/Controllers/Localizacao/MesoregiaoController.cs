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
    [Route("atacado/localizacao/mesoregiao")]
    [ApiController]
    public class MesoregiaoController : GenericBaseController<MesoregiaoPoco>
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="contexto"></param>
        public MesoregiaoController(AtacadoContext contexto) :
            base(contexto)
        {
            this.servico = new MesoregiaoService(this.contexto);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<MesoregiaoPoco> Get()
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
        public MesoregiaoPoco Get(int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter microregioes por id da mesoregiao.
        /// </summary>
        /// <param name="mesid">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{mesid:int}/microregioes")]
        public List<MicroregiaoPoco> GetMicroregioesPorID(int mesid)
        {
            MicroregiaoService srv = new MicroregiaoService(this.contexto);
            List<MicroregiaoPoco> microregiaoPoco = srv.ObterTodos()
                .Where(mes => mes.MesoregiaoID == mesid).ToList();
            return microregiaoPoco;
        }

        /// <summary>
        /// Obter municipios por id da mesoregiao.
        /// </summary>
        /// <param name="mesid">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{mesid:int}/municipios")]
        public List<MunicipioPoco> GetMunicipiosPorID(int mesid)
        {
            MunicipioService srv = new MunicipioService(this.contexto);
            List<MunicipioPoco> municipioPoco = srv.ObterTodos()
                .Where(mes => mes.MesoregiaoID == mesid).ToList();
            return municipioPoco;
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public MesoregiaoPoco Post([FromBody] MesoregiaoPoco poco)
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
        public MesoregiaoPoco Put([FromBody] MesoregiaoPoco poco)
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
        public MesoregiaoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}