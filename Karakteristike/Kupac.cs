using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karakteristike
{
    public  class Kupac : Osoba
    {
        private string _emailAdresa;
        private Kolekcija<float, ZadovoljstvoKupca> _kupovine; 
        private List<int> _bodovi;

        public Kupac(string imePrezime = "", Datum datumRodjenja = null, string emailAdresa = ""): base(imePrezime, datumRodjenja)
        {
            _emailAdresa = emailAdresa;
            _kupovine = new Kolekcija<float, ZadovoljstvoKupca>(false);
            _bodovi = new List<int>();
        }
        public Kupac(Kupac obj) : base(obj)
        {
            _emailAdresa = obj._emailAdresa;
            _kupovine = new Kolekcija<float, ZadovoljstvoKupca>(obj._kupovine);
            _bodovi = new List<int>(obj._bodovi);
        }
        public void DodajKupovinu(int novac, ZadovoljstvoKupca zadovoljstvo)
        {
            if(novac>10)
            {
                _bodovi.Add(novac);
            }
            if ((novac / 10) > 8)
            {
                Thread.Sleep(3000); 
                Thread thread = new Thread(() => PosaljiMail(novac / 10));
                thread.Start();
            }
            _kupovine.AddElement(novac, zadovoljstvo);
        }
        private Mutex lo = new Mutex();
        public void PosaljiMail(int bodovi)
        {
            lo.WaitOne();
            try
            {
                Console.WriteLine($"TO: {GetEmail()}"); 
                Console.WriteLine("Subject: Osvareni bodovi");
                Console.WriteLine("Postovani,");
                Console.WriteLine($"Prilikom posljednje kupovine ste ostvarili {bodovi} bodova, " +
                                  $"tako da trenutno vas ukupan broj bodova iznosi {GetBodoviUkupno()}.");
                Console.WriteLine("Zahvaljujemo vam na kupovini.");
                Console.WriteLine("Puno pozdrava");
                Console.WriteLine(Environment.NewLine); 
            }
            finally
            {
                lo.ReleaseMutex(); 
            }
        }
        public string GetEmail()
        {
            return _emailAdresa;
        }
        public Kolekcija<float, ZadovoljstvoKupca> GetKupovine()
        {
            return _kupovine;
        }
        public List<int> GetBodovi()
        {
            return _bodovi;
        }
        public int GetBodoviUkupno()
        {
            int ukupno = 0;
            for (int i = 0; i < _bodovi.Count; i++)
            {
                ukupno += _bodovi[i];
            }
            return ukupno;

        }
        public override string ToString()
        {
            StringBuilder COUT=new StringBuilder();
            COUT.AppendLine($"{GetImePrezime()} {GetDatumRodjenja()} {GetEmail()}");
            COUT.AppendLine("KUPOVINE -> ");
            for (int i = 0; i < _kupovine.GetTrenutno(); i++)
            {
                COUT.AppendLine($"Iznos racuna: {_kupovine.GetElement1(i)}KM, zadovoljstvo kupca: {_kupovine.GetElement2(i)}");
            }
            COUT.AppendLine("BODOVI -> ");
            for (int i = 0; i < _bodovi.Count; i++)
            {
                COUT.Append($"{_bodovi[i]}, ");
            }
            return COUT.ToString();

        }

        public Kolekcija<Karakteristike,string>GetKupovineByKomentar(string komentar)
        {
            var obj= new Kolekcija<Karakteristike, string>(false);
            for (int i = 0; i < _kupovine.GetTrenutno(); i++)
            {
                for (int j = 0; j < _kupovine.GetElement2(i).GetKomentareKarakteristika().GetTrenutno(); j++)
                {
                    if (_kupovine.GetElement2(i).GetKomentareKarakteristika().GetElement2(j).Contains(komentar))
                    {
                        obj.AddElement(_kupovine.GetElement2(i).GetKomentareKarakteristika().GetElement1(j),
                                      _kupovine.GetElement2(i).GetKomentareKarakteristika().GetElement2(j));
                    }
                }
            }
            return obj;
        }




        public override void Info()
        {
            Console.WriteLine(this);
        }
    }
}
