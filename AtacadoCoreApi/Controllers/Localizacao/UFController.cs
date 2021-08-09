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
    [Route("atacado/localizacao/estados")]
    [ApiController]
    public class UFController : GenericBaseController<UFPoco>
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="contexto"></param>
        public UFController(AtacadoContext contexto) :
            base(contexto)
        {
            this.servico = new UFService(this.contexto);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<UFPoco> Get()
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
        public UFPoco Get(int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter mesoregião por id do estado.
        /// </summary>
        /// <param name="ufid">Chave primaria do estado.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{ufid:int}/mesoregioes")]
        public List<MesoregiaoPoco> GetMesoregiaoPorID(int ufid)
        {
            MesoregiaoService srv = new MesoregiaoService(this.contexto);
            List<MesoregiaoPoco> mesoregiaoPoco = srv.ObterTodos()
                .Where(mes => mes.UFID == ufid).ToList();
            return mesoregiaoPoco;
        }

        /// <summary>
        /// Obter municipios por id do estado.
        /// </summary>
        /// <param name="ufid">Chave primaria do estado.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{ufid:int}/municipios")]
        public List<MunicipioPoco> GetMunicipiosPorID(int ufid)
        {
            MunicipioService srv = new MunicipioService(this.contexto);
            List<MunicipioPoco> municipioPoco = srv.ObterTodos()
                .Where(mun => mun.UFID == ufid).ToList();
            return municipioPoco;
        }

        /// <summary>
        /// Obter municipios por sigla do estado.
        /// </summary>
        /// <param name="siglauf">Sigla do estado.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{siglauf}/municipios")]
        public List<MunicipioPoco> GetMunicipiosPorSigla(string siglauf)
        {
            MunicipioService srv = new MunicipioService(this.contexto);
            List<MunicipioPoco> municipioPoco = srv.ObterTodos()
                .Where(mun => mun.SiglaUF == siglauf).ToList();
            return municipioPoco;
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public UFPoco Post([FromBody] UFPoco poco)
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
        public UFPoco Put([FromBody] UFPoco poco)
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
        public UFPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}