using AtacadoCore.DAL.Models;
using AtacadoCore.Repo.Ancestral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.REPO.Estoque
{
    public class SubcategoriaRepository :
        GenericRepository<DbContext, Subcategorium>

    {
        public SubcategoriaRepository(DbContext contexto) : base(contexto)
        { }
    }
}
