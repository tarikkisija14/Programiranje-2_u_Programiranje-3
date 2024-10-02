using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predmeti
{
    public class Pitanje
    {
        private string _sadrzaj { get; set; }
        private Kolekcija<int, Datum> _ocjeneRjesenja { get; set; }

        public Pitanje(string sadrzaj = "")
        {
            _sadrzaj = sadrzaj;
            _ocjeneRjesenja = new Kolekcija<int, Datum>();
        }
        public Pitanje(Pitanje obj)
        {
            _sadrzaj = obj._sadrzaj;
            _ocjeneRjesenja = new Kolekcija<int, Datum>(obj._ocjeneRjesenja);
        }


        public float ProsjekPitanje()
        {
            float sum = 0.0f;
            if (_ocjeneRjesenja.GetTrenutno() == 0)
                return 0.0f;
            for (int i = 0; i < _ocjeneRjesenja.GetTrenutno(); i++)
            {
                sum += _ocjeneRjesenja.GetElement1(i);
            }
            return sum / _ocjeneRjesenja.GetTrenutno();
        }

        public static bool operator ==(Pitanje p1, Pitanje p2)
        {
            if (p1._sadrzaj != p2._sadrzaj) return false;
            if (p1._ocjeneRjesenja.GetTrenutno != p2._ocjeneRjesenja.GetTrenutno) return false;
            for (int i = 0; i < p1._ocjeneRjesenja.GetTrenutno(); i++)
            {
                if (p1._ocjeneRjesenja.GetElement1(i) != p2._ocjeneRjesenja.GetElement1(i))
                    return false;
                if (p2._ocjeneRjesenja.GetElement2(i) != p2._ocjeneRjesenja.GetElement2(i))
                    return false;
            }
            return true;
        }

        public static bool operator !=(Pitanje p1, Pitanje p2)
        {
            return !(p1 == p2);
        }

        public bool AddOcjena(Datum d, int ocjena)
        {
            int trenutno = _ocjeneRjesenja.GetTrenutno();
            if (trenutno > 0)
            {
                Datum zadnji = _ocjeneRjesenja.GetElement2(trenutno - 1);

                if (d < zadnji) return false;
                if (d - zadnji < 3) return false;

            }
            _ocjeneRjesenja.AddElement(ocjena, d);
            return true;
        }

        public string GetSadrzaj()
        {
            return _sadrzaj;
        }

        public Kolekcija<int, Datum> GetOcjene()
        {
            return _ocjeneRjesenja;
        }

        public override string ToString()
        {
            StringBuilder COUT = new StringBuilder();
            COUT.AppendLine($"Sadrzaj pitanja: {_sadrzaj}");
            for (int i = 0; i < _ocjeneRjesenja.GetTrenutno(); i++)
            {
                COUT.Append($"Ocjena: {_ocjeneRjesenja.GetElement1(i)} --> Datum:  {_ocjeneRjesenja.GetElement2(i)}");
            }
            COUT.Append($"Prosjek ocjena : {ProsjekPitanje()}");
            return COUT.ToString();
        }

    }
}
