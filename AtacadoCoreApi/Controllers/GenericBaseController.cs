using AtacadoCore.DAL.Models;
using AtacadoCore.SERV.Ancestral.Atacado.Service.Ancestor;
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
    /// <typeparam name="TPoco"></typeparam>
    public abstract class GenericBaseController<TPoco> : ControllerBase
        where TPoco : class
    {
        protected AtacadoContext contexto;

        protected IService<TPoco> servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public GenericBaseController(AtacadoContext contexto)
        {
            this.contexto = contexto;
        }       
    }
}
