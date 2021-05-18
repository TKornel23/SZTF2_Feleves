using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_Féléves2
{
    class Rendelések
    {
        public Stílus Stílus { get; set; }
        public Tipus Tipus { get; set; }
        public string Fajta { get; set; }
        public string Kié { get; }

        public Rendelések(string stílus, string tipus, string fajta, string kié)
        {
            this.Stílus = (Stílus)Enum.Parse(typeof(Stílus), stílus.Replace(" ","_"));
            this.Tipus = (Tipus)Enum.Parse(typeof(Tipus), tipus);
            this.Fajta = fajta;
            Kié = kié;
        }
    }
}
