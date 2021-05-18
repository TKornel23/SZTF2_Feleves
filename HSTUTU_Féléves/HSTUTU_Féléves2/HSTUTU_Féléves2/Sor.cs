using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_Féléves2
{
    class Sor : Etel
    {
        public Sor(string megnevezés, Tipus tipus, Stílus stilus, int ár, int mennyiség)
            : base(megnevezés, tipus, stilus, ár, mennyiség)
        {

        }

        public Sor()
        {

        }

        public override string ToString()
        {
            return "sör";
        }
    }
}
