using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_Féléves2
{
    public interface IFogyasztható
    {
        int Ár { get; set; }
        int Mennyiség { get; set; }
    }
}
