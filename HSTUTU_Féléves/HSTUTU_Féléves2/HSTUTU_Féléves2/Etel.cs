using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_Féléves2
{
    public enum Tipus
    {
        meleg = 0, hal = 1, krém = 2, csapolt = 3, hideg = 4
    }

    public enum Stílus
    {
        magyaros = 0, roston_sült = 1, francia = 2, cseh = 3
    }
    abstract class Etel : IFogyasztható
    {
        public string Megnevezés { get; set; }
        public Tipus Tipus { get; set; }
        public Stílus Stílus { get; set; }
        public int Ár { get; set; }
        public int Mennyiség { get; set; }

        public Etel(string megnevezés, Tipus tipus, Stílus stílus, int ár, int mennyiség)
        {
            Megnevezés = megnevezés;
            Tipus = tipus;
            Stílus = stílus;
            Ár = ár;
            Mennyiség = mennyiség;
        }

        public Etel()
        {

        }
    }
}
