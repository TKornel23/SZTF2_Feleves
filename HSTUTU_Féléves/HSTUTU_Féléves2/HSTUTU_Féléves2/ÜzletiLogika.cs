using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HSTUTU_Féléves2
{
    public delegate void ÚJOptimálisMegoldás();
    class ÜzletiLogika
    {
        public List<ÉtelLista> Ételek = new List<ÉtelLista>();
        public void MenuLétrehoz()
        {
            string[] lines = File.ReadAllLines("menu.txt");
            string[] Fajták = new string[] { "előétel", "főétel", "sör", "desszert" };
            for (int i = 0; i < Fajták.Length; i++)
            {
                Feldolgoz(Fajták[i], lines);
            }
        }

        private void Feldolgoz(string item, string[] lines)
        {
            int linesLength = lines.Length;
            int linesIndex = 0;

            linesIndex = 0;

            ÉtelLista ételTemp = null;
            int Tipusmutató = 0;
            int index = 0;

            while (linesIndex < lines.Length)
            {
                string[] temp = lines[linesIndex].Split(',');
                if ((int)(Stílus)Enum.Parse(typeof(Stílus), temp[5].Replace(' ', '_')) == Tipusmutató)
                {
                    while (index < lines.Length)
                    {
                        string[] tempB = lines[index].Split(',');
                        if (item == "előétel")
                        {
                            if (tempB[0] == item)
                            {
                                ételTemp = Beszurás(new Eloetel(tempB[1], (Tipus)Enum.Parse(typeof(Tipus), tempB[4]), (Stílus)Enum.Parse(typeof(Stílus), tempB[5].Replace(' ', '_')), int.Parse(tempB[2]), int.Parse(tempB[3])));
                            }
                        }
                        else if(item == "főétel")
                        {
                            if (tempB[0] == item)
                            {
                                ételTemp = Beszurás(new Foetel(tempB[1], (Tipus)Enum.Parse(typeof(Tipus), tempB[4]), (Stílus)Enum.Parse(typeof(Stílus), tempB[5].Replace(' ', '_')), int.Parse(tempB[2]), int.Parse(tempB[3])));
                            }
                        }
                        else if(item == "sör")
                        {
                            if (tempB[0] == item)
                            {
                                ételTemp = Beszurás(new Sor(tempB[1], (Tipus)Enum.Parse(typeof(Tipus), tempB[4]), (Stílus)Enum.Parse(typeof(Stílus), tempB[5].Replace(' ', '_')), int.Parse(tempB[2]), int.Parse(tempB[3])));
                            }
                        }
                        else if(item == "desszert")
                        {
                            if (tempB[0] == item)
                            {
                                ételTemp = Beszurás(new Desszert(tempB[1], (Tipus)Enum.Parse(typeof(Tipus), tempB[4]), (Stílus)Enum.Parse(typeof(Stílus), tempB[5].Replace(' ', '_')), int.Parse(tempB[2]), int.Parse(tempB[3])));
                            }
                        }
                        index++;
                    }
                }
                if (fej != null)
                {
                    Ételek.Add(ételTemp);
                }
                Tipusmutató++;
                fej = null;
                linesIndex++;
            }
        }

        private ÉtelLista fej;
        private ÉtelLista Beszurás(Etel tartalom)
        {
            ÉtelLista uj = new ÉtelLista();

            uj.Tartalom = tartalom;
            uj.Következő = fej;

            ÉtelLista p = fej;
            ÉtelLista e = null;

            while (p != null && p.Tartalom.Ár < uj.Tartalom.Ár)
            {
                e = p;
                p = p.Következő;
            }
            if (e == null)
            {
                uj.Következő = fej;
                fej = uj;
            }
            else
            {
                uj.Következő = p;
                e.Következő = uj;
            }
            return fej;
        }

        public Etel[][] ÉtelMátrix;

        public Etel[][] MátrixotLétrehoz(ref List<ÉtelLista> ételLista)
        {
            List<Etel> előétel = new List<Etel>();           
            ÉtelMátrix = new Etel[4][];

                for (int i = 0; i < 4; i++)
                {
                    while (ételLista[i] != null)
                    {
                        előétel.Add(ételLista[i].Tartalom);
                        ételLista[i] = ételLista[i].Következő;
                    }
                    ÉtelMátrix[i] = előétel.ToArray();
                    előétel.Clear();
                }
                return ÉtelMátrix;
        }

        public event ÚJOptimálisMegoldás Eventecske;
        private int Összkeret = 0;
        private bool FK(Rendelések r)
        {
            bool helper = false;
            int k = 0;
            int y = 0;
            for (int j = 0; j < ÉtelMátrix.Length; j++)
            {
                if (ÉtelMátrix[j][0].ToString() == r.Fajta)
                {
                    for (int i = 0; i < ÉtelMátrix[j].Length; i++)
                    {
                        if (ÉtelMátrix[j][i].Tipus == r.Tipus && ÉtelMátrix[j][i].Stílus == r.Stílus)
                        {
                            if (ÉtelMátrix[j][i].Ár + Összkeret < vendégÁr)
                            {
                                k = j;
                                y = i;
                                helper = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (helper)
            {
                seged = ÉtelMátrix[k][y];
                Összkeret += ÉtelMátrix[k][y].Ár;
                return true;
            }
            else
            {
                seged = null;
                return helper;
            }
        }

        public void MennyiAzAnnyi(int annyi)
        {
            this.vendégÁr = annyi;
        }

        Etel seged;
        private int vendégÁr = 0;
        private void BTS(int szint, ref Etel[] E, List<Rendelések> r, ref Etel[] OPT)
        {
            while (szint < r.Count)
            {
                if (FK(r[szint]))
                {
                    if (seged.Mennyiség > 0)
                    {
                        seged.Mennyiség--;
                        E[szint] = seged;
                    }
                    if (szint == r.Count - 1)
                    {
                        if(Jóság(E) >= Jóság(OPT) && Jóság(E) <= vendégÁr)
                        {
                            Eventecske?.Invoke();
                            OPT = E.ToArray();
                        }                        
                    }
                    else
                    {
                        BTS(szint + 1, ref E, r, ref OPT);
                    }

                }
                szint++;
            }

            Megoldas = new Etel[r.Count];
            int szamolo = 0;
            for (int i = 0; i < OPT.Length; i++)
            {
                if(OPT[i] == null)
                {
                    szamolo++;
                }
            }
            if(szamolo == OPT.Length)
            {
                for (int i = 0; i < E.Length; i++)
                {
                    Megoldas[i] = E[i];
                }
            }
            else
            {
                for (int i = 0; i < E.Length; i++)
                {
                    Megoldas[i] = OPT[i];
                }
            }
        }

        public Etel[] Megoldas = null;

        private int Jóság(Etel[] E)
        {
            int összeg = 0;
            for (int i = 0; i < E.Length; i++)
            {
                if (E[i] != null)
                {
                    összeg += E[i].Ár;
                }
            }
            return összeg;
        }
        public void BTS(List<Rendelések> r, ref Etel[] E, ref Etel[] OPT)
        {
            E = new Etel[r.Count];
            OPT = new Etel[r.Count];
            BTS(0, ref E, r, ref OPT);
        }

    }
}
