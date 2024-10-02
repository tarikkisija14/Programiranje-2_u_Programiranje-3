using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predmeti
{
    public class Kandidat : Korisnik
    {
        private List<Ispit> _polozeniPredmeti;

        public Kandidat(string imePrezime, string emailAdresa, string lozinka) : base(imePrezime, emailAdresa, lozinka)
        {
            _polozeniPredmeti = new List<Ispit>();
            for (int i = 0; i <= 6; i++)
            {
                _polozeniPredmeti.Add(new Ispit((Predmet)i));
            }
        }
        public Kandidat(Kandidat obj) : base(obj)
        {
            _polozeniPredmeti = new List<Ispit>();
            for (int i = 0; i <= _polozeniPredmeti.Count; i++)
            {
                _polozeniPredmeti.Add(obj._polozeniPredmeti[i]);
            }
        }

        public float GetUkupno()
        {
            float sum = 0.0f;
            if (_polozeniPredmeti.Count == 0)
                return 0;
            for (int i = 0; i < _polozeniPredmeti.Count; i++)
            {
                sum += _polozeniPredmeti[i].ProsjekIspit();
            }
            return sum / _polozeniPredmeti.Count;

        }



        public bool AddPitanje(Predmet predmet, Pitanje pitanje)
        {
            for (int i = 0; i < _polozeniPredmeti[(int)predmet].GetPitanjaOdgovore().Count; i++)
            {
                if (_polozeniPredmeti[(int)predmet].GetPitanjaOdgovore().Equals(pitanje))
                { return false; }
            }
            if (predmet > Predmet.UIT)
            {
                if (_polozeniPredmeti[(int)predmet - 1].GetPitanjaOdgovore().Count < 3)
                    return false;
                if (_polozeniPredmeti[(int)predmet - 1].ProsjekIspit() <= 3.5f)
                    return false;
            }
            _polozeniPredmeti[(int)predmet].GetPitanjaOdgovore().Add(pitanje);
            if (GetAtivan())
            {
                for (int i = 0; i < pitanje.GetOcjene().GetTrenutno(); i++)
                {
                    int ocjena = pitanje.GetOcjene().GetElement1(i);
                    Thread mailThread = new Thread(() => PosaljiMail(ocjena, pitanje));
                    mailThread.Start();
                }
            }
            return true;
        }
        private static Mutex lo = new Mutex();

        public void PosaljiMail(int ocjena, Pitanje pitanje)
        {
            if (!GetAtivan())
                return;

            lo.WaitOne();
            try
            {
                Console.WriteLine("FROM: info@kursevi.ba");
                Console.WriteLine($"TO: {GetEmail()}");
                Console.WriteLine($"Postovani {GetImePrezime()}, evidentirana vam je ocjena {ocjena} za odgovor na pitanje {pitanje.GetSadrzaj()}.");
                Console.WriteLine($"Dosadasnji uspjeh (prosjek ocjena) za pitanje {pitanje.GetSadrzaj()} iznosi {pitanje.ProsjekPitanje()}.");
                Console.WriteLine($"Ukupni uspjeh: {GetUkupno()}.");
                Console.WriteLine("Pozdrav.");
                Console.WriteLine("//EDUTeam.\n");
                Thread.Sleep(2000);
            }
            finally
            {
                lo.ReleaseMutex(); // Release the mutex
            }


        }

        public override string ToString()
        {
            StringBuilder COUT = new StringBuilder();
            COUT.AppendLine(base.ToString());
            for (int i = 0; i < _polozeniPredmeti.Count; i++)
            {
                COUT.AppendLine(_polozeniPredmeti[i].ToString());
            }
            return COUT.ToString();
        }
        public List<Ispit> GetPolozeniPredmeti()
        {
            return _polozeniPredmeti;
        }

        public Kolekcija<Pitanje, float> GetPitanjaOdgovoreBetweenDates(Datum from, Datum to)
        {
            Kolekcija<Pitanje, float> obj = new Kolekcija<Pitanje, float>();
            for (int i = 0; i < _polozeniPredmeti.Count; i++)
            {
                for (int j = 0; j < _polozeniPredmeti[i].GetPitanjaOdgovore().Count; j++)
                {
                    for (int k = 0; k < _polozeniPredmeti[i].GetPitanjaOdgovore()[j].GetOcjene().GetTrenutno(); k++)
                    {
                        Datum datum = _polozeniPredmeti[i].GetPitanjaOdgovore()[j].GetOcjene().GetElement2(k);
                        if (datum > from && datum < to)
                        {
                            for (int l = 0; l < _polozeniPredmeti[i].GetPitanjaOdgovore()[j].GetOcjene().GetTrenutno(); l++)
                            {
                                if (_polozeniPredmeti[i].GetPitanjaOdgovore()[j].GetOcjene().GetElement1(k) >= 0)
                                {
                                    obj.AddElement(_polozeniPredmeti[i].GetPitanjaOdgovore()[j], _polozeniPredmeti[i].GetPitanjaOdgovore()[j].ProsjekPitanje());
                                }
                            }
                        }
                    }
                }
            }
            return obj;
        }




    }
}
