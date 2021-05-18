using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_Féléves2
{
    class ÉtelLista
    {
        public Etel Tartalom { get; set; }
        public ÉtelLista Következő { get; set; }

        public ÉtelLista()
        {

        }
    }
}
