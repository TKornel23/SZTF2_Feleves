using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_Féléves2
{
    class Program
    {
        static void EventHelper()
        {
            Console.WriteLine("Találtam egy jobb megoldást!");
        }
        static void Main(string[] args)
        {
            ÜzletiLogika logika = new ÜzletiLogika();
            logika.MenuLétrehoz();
            logika.Eventecske += EventHelper;
            List<ÉtelLista> ételLista = logika.Ételek;
            logika.MátrixotLétrehoz(ref ételLista);
            logika.MennyiAzAnnyi(11000);
            List<Rendelések> rendelések = new List<Rendelések>();
            rendelések.Add(new Rendelések("magyaros", "meleg", "előétel", "Pisti előétele: "));
            rendelések.Add(new Rendelések("francia", "krém", "desszert", "Pisti desszerte: "));
            rendelések.Add(new Rendelések("cseh", "csapolt", "sör", "Pisti Söre: "));
            rendelések.Add(new Rendelések("francia", "hideg", "előétel", "Kati előétele: "));
            rendelések.Add(new Rendelések("roston sült", "hal", "főétel", "Kati főétel: "));
            rendelések.Add(new Rendelések("cseh", "csapolt", "sör", "Kati söre: "));
            rendelések.Add(new Rendelések("cseh", "csapolt", "sör", "Jancsi söre: "));
            rendelések.Add(new Rendelések("francia", "hideg", "előétel", "Jancsi előétele: "));
            rendelések.Add(new Rendelések("roston sült", "hal", "főétel", "Jancsi főétele: "));
            rendelések.Add(new Rendelések("cseh", "csapolt", "sör", "Zsombi söre: "));
            rendelések.Add(new Rendelések("cseh", "csapolt", "sör", "Zsombi söre: "));
            Etel[] OPT = new Etel[rendelések.Count];
            Etel[] E = new Etel[rendelések.Count];
            logika.BTS(rendelések, ref E, ref OPT);
            int összeg = 0;

            for (int i = 0; i < logika.Megoldas.Length; i++)
            {
                if (logika.Megoldas[i] != null)
                { Console.WriteLine(rendelések[i].Kié + " " + logika.Megoldas[i].Megnevezés + ": " + logika.Megoldas[i].Ár + "Ft"); }
                else
                {
                    Console.WriteLine(rendelések[i].Kié + "nem optimális :c");
                }
            }
            for (int i = 0; i < logika.Megoldas.Length; i++)
            {
                if (logika.Megoldas[i] != null)
                { összeg += logika.Megoldas[i].Ár; }
            }                        
            Console.WriteLine(összeg +"Ft");
            Console.ReadLine();
        }

    }
}
