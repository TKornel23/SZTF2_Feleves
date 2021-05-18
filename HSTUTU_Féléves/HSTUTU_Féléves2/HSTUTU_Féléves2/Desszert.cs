using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_Féléves2
{
    class Desszert : Etel
    {
        public Desszert(string megnevezés, Tipus tipus, Stílus stilus, int ár, int mennyiség)
            : base(megnevezés, tipus, stilus, ár, mennyiség)
        {

        }

        public Desszert()
        {

        }

        public override string ToString()
        {
            return "desszert";
        }
    }
}
