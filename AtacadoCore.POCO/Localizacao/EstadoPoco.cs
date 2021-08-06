using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.POCO.Localizacao
{
    public class EstadoPoco
    {
        public int RegiaoID { get; set; }

        public string SiglaUF { get; set; }

        public int UFID { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataInclusao { get; set; }
    }
}
