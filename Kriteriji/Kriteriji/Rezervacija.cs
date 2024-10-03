using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kriteriji
{
    public class Rezervacija
    {
        private Datum _OD;
        private Datum _DO;
        private List<Gost> _gosti;
        private Komentar _komentar;

        public Rezervacija(Datum od, Datum doDatum, Gost gost)
        {
            _OD = od;
            _DO = doDatum;
            _gosti = new List<Gost> { gost };
        }
        public Rezervacija(Rezervacija obj)
        {
            _OD = obj._OD;
            _DO = obj._DO;
            _gosti = new List<Gost>(obj._gosti);
            _komentar = obj._komentar;
        }
        public bool AddGost(Gost obj)
        {

            for (int i = 0; i < _gosti.Count; i++)
            {
                if (_gosti[i].Equals(obj))
                    return false;
            }

            _gosti.Add(obj);
            return true;
        }
        public void SetKomentar(Komentar komentar)
        {
            int brojac = 0;
            for (int i = 0; i < komentar.GetOcjeneKriterija().GetTrenutno(); i++)
            {
                if (komentar.GetOcjeneKriterija().GetElement2(i) > 5)
                    brojac++;
            }

            if (brojac >= 2)
            {
                Thread tread = new Thread(() => PosaljiMail(komentar));
                tread.Start();
                tread.Join();
            }
            _komentar = komentar;
        }
        private readonly object lo = new object();
        private void PosaljiMail(Komentar komentar)
        {
            lock (lo)
            {
                Console.WriteLine("TO: ");
                for (int i = 0; i < _gosti.Count; i++)
                {
                    Console.WriteLine(_gosti[i].GetEmail() + ",");
                }
                Console.WriteLine();
                Console.WriteLine("Subject: Informacija");
                Console.WriteLine();
                Console.WriteLine("Poštovani,");
                Console.WriteLine();
                Console.WriteLine("Zaprimili smo vaše ocjene, a njihova prosječna vrijednost je " + komentar.GetProsjekKomentara());
                Console.WriteLine("Žao nam je zbog toga, te će vas u najkraćem periodu kontaktirati naša Služba za odnose sa gostima.");
                Console.WriteLine();
                Console.WriteLine("Ugodan boravak vam želimo");
                Console.WriteLine("Puno pozdrava");
            }
        }

        public List<Gost> GetGosti()
        { return _gosti; }
        public Komentar GetKomentar() {  return _komentar; }

        public override string ToString()
        {
            StringBuilder COUT= new StringBuilder();
            COUT.AppendLine($"Rezervacija {_OD}-{_DO} za goste \n");
            for (int i = 0; i < _gosti.Count; i++)
            {
                COUT.Append($"\t{+1} {_gosti[i]}\n");
            }
            COUT.AppendLine($"Komentar rezervacije:\n{_komentar}\n");
            return COUT.ToString();
        }



    }
}
