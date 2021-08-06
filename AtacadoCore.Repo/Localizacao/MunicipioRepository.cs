using AtacadoCore.DAL.Models;
using AtacadoCore.Repo.Ancestral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.REPO.Localizacao
{
    public class MunicipioRepository : GenericRepository<DbContext, Municipio>
    {
        public MunicipioRepository(DbContext contexto) : base(contexto)
        { }
    }
}
