using AtacadoCore.DAL.Models;
using AtacadoCore.SERV.Ancestral;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtacadoCoreApi.Controllers
{
    public abstract class GenericBaseController<T> : ControllerBase
        where T : class
    {
        protected AtacadoContext contexto;

        protected IService<T> servico;

        public GenericBaseController(AtacadoContext contexto)
        {
            this.contexto = contexto;
        }
    }
}