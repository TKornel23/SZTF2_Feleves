using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_Féléves2
{
    class Eloetel : Etel
    {
        public Eloetel(string megnevezés, Tipus tipus, Stílus stilus, int ár, int mennyiség)
            :base(megnevezés, tipus, stilus, ár, mennyiség)
        {
       
        }

        public Eloetel()
        {

        }

        public override string ToString()
        {
            return "előétel";
        }
    }
}
