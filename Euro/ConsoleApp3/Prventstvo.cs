using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Prventstvo
    {
        Kolekcija<Reprezentacija, Reprezentacija> _utakmica;
        Mutex lo = new Mutex();

        public Prventstvo()
        {
            _utakmica = new Kolekcija<Reprezentacija, Reprezentacija>(20);
        }

        public Prventstvo(Prventstvo obj)
        {
            _utakmica = obj._utakmica;
        }

        public void PosaljiMail(Pogodak pogodak, string pretraga)
        {
            lo.WaitOne();
            try
            {
                Console.WriteLine("TO: ");
                for (int i = 0; i < _utakmica.GetTrenutno(); i++)
                {
                    for (int j = 0; j < _utakmica.GetElementi1(i).GetIgraci().Count; j++)
                    {
                        Console.WriteLine(_utakmica.GetElementi1(i).GetIgraci()[j].GetID() + "@euro2024.com, ");
                    }
                    for (int k = 0; k < _utakmica.GetElementi2(i).GetIgraci().Count; k++)
                    {
                        Console.WriteLine(_utakmica.GetElementi2(i).GetIgraci()[k].GetID() + "@euro2024.com, ");
                    }

                }
                Console.WriteLine();
                Console.WriteLine("From: info@euro2024.com");
                Console.WriteLine("Subject: Informacija");
                Console.WriteLine("Postovani, ");
                Console.WriteLine("U " + pogodak.GetVrijemePogotka() + " sati, igrac " + pretraga + " je zabiljezio svoj " + pogodak.GetNapomena() + " na ovoj utakmici");
                Console.WriteLine("Trenutni rezultat je : ");
                for (int i = 0; i < _utakmica.GetTrenutno(); i++)
                {
                    Console.WriteLine(_utakmica.GetElementi1(i).GetDrzava() + " " + _utakmica.GetElementi1(i).GetbrojPogodaka() + " : " + _utakmica.GetElementi2(i).GetbrojPogodaka() + " " + _utakmica.GetElementi2(i).GetDrzava());
                }
                Console.WriteLine("Puno srece u nastavku susreta.");
                Console.WriteLine("Neka bolji tim pobijedi.");
                Console.WriteLine(Environment.NewLine); // Replace with your variable `crt`
            }
            finally
            {
                lo.ReleaseMutex();
            }
        }

        public void AddUtakmicu(Reprezentacija r1,Reprezentacija r2)
        {
            for (int i = 0; i < _utakmica.GetTrenutno(); i++)
            {
                if((_utakmica.GetElementi1(i)==r1 && _utakmica.GetElementi2(i) == r2)) 
                {
                    throw new Exception("utakmica vec odigrana");
                }
            }
            _utakmica.AddElement(r1, r2);
        }

        public bool AddPogodak(Drzava d1,Drzava d2,string pretraga,Pogodak pogodak)
        {
            for(int i = 0; i < _utakmica.GetTrenutno(); i++)
            {
                if (_utakmica.GetElementi1(i).GetDrzava() == d1 && _utakmica.GetElementi2(i).GetDrzava() == d2)
                {
                    for (int j = 0; j < _utakmica.GetElementi1(i).GetIgraci().Count; j++)
                    {
                        var igraci = _utakmica.GetElementi1(i).GetIgraci()[j];
                        if(igraci.GetID()==pretraga||igraci.GetImePrezime()==pretraga)
                        {
                            if(igraci.AddGol(pogodak))
                            {
                                Thread tred = new Thread(() => PosaljiMail(pogodak, pretraga));
                                tred.Start();
                                tred.Join();
                                return true;
                            }
                        }
                    }

                    for (int j = 0; j < _utakmica.GetElementi2(i).GetIgraci().Count; j++)
                    {
                        var igraci = _utakmica.GetElementi2(i).GetIgraci()[j];
                        if (igraci.GetID() == pretraga || igraci.GetImePrezime() == pretraga)
                        {
                            if (igraci.AddGol(pogodak))
                            {
                                Thread tred = new Thread(() => PosaljiMail(pogodak, pretraga));
                                tred.Start();
                                tred.Join();
                                return true;
                            }
                        }
                    }


                }
            }


            return false;


        }

        public override string ToString()
        {
            var COUT =new System.Text.StringBuilder();
            COUT.AppendLine(Environment.NewLine);
            for (int i = 0; i < _utakmica.GetTrenutno(); i++)
            {
                COUT.AppendLine($"{_utakmica.GetElementi1(i).GetDrzava()}   {_utakmica.GetElementi1(i).GetbrojPogodaka()} : {_utakmica.GetElementi2(i).GetbrojPogodaka()} {_utakmica.GetElementi2(i).GetDrzava()}");

            }
            COUT.AppendLine(Environment.NewLine);

            COUT.AppendLine("strijelci za tim BiH: ");

            for (int i = 0; i < _utakmica.GetTrenutno(); i++)
            {
                for (int j = 0; j < _utakmica.GetElementi1(i).GetStrijelci().Count; j++)
                {
                    COUT.AppendLine(_utakmica.GetElementi1(i).GetStrijelci()[j].GetImePrezime());
                }
            }
            COUT.AppendLine();
            COUT.AppendLine("strijelci za tim ENG: ");
            for (int i = 0; i < _utakmica.GetTrenutno(); i++)
            {
                for (int j = 0; j < _utakmica.GetElementi2(i).GetStrijelci().Count; j++)
                {
                    COUT.AppendLine(_utakmica.GetElementi2(i).GetStrijelci()[j].GetImePrezime());
                }
            }
            return COUT.ToString();
        }

       public List<Igrac> this[int broj]
        {
            get
            {
                List<Igrac> Pichichi = new List<Igrac>();
                for (int i = 0; i < _utakmica.GetTrenutno(); i++)
                {
                    var repka1 = _utakmica.GetElementi1(i);
                    var repka2 = _utakmica.GetElementi2(i);

                    for (int j = 0; j < repka1.GetIgraci().Count; j++)
                    {
                        if (repka1.GetIgraci()[j].GetPogoci().Count >= broj)
                            Pichichi.Add(repka1.GetIgraci()[i]);

                    }
                    for (int j = 0; j < repka2.GetIgraci().Count; j++)
                    {
                        if (repka2.GetIgraci()[j].GetPogoci().Count >= broj)
                            Pichichi.Add(repka2.GetIgraci()[i]);

                    }
                }
                return Pichichi;
            }
           
        }


    }
}
