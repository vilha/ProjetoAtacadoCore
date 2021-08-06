using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.POCO.Localizacao
{
    public class MesoregiaoPoco
    {
        public int MesoregiaoID { get; set; }

        public string Descricao { get; set; }

        public int UFID { get; set; }

        public DateTime? DataInclusao { get; set; }
    }
}
