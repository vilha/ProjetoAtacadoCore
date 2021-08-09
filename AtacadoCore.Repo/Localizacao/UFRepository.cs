using AtacadoCore.DAL.Models;
using AtacadoCore.REPO.Ancestral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.REPO.Localizacao
{
    public class UFRepository : GenericRepository<DbContext, UnidadesFederacao>
    {
        public UFRepository(DbContext contexto) : base(contexto)
        { }
    }
}
