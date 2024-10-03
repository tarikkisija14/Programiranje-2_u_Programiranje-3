using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kriteriji
{
    public class Komentar
    {
        private string _sadrzajKomentara;
        private Kolekcija<Kriteriji, int> _ocjeneKriterija;

        public Komentar(string sadrzajKomentara = "")
        {
            _sadrzajKomentara = sadrzajKomentara;
            _ocjeneKriterija = new Kolekcija<Kriteriji, int>();
        }

        public Komentar(Komentar obj)
        {
            _sadrzajKomentara = obj._sadrzajKomentara;
            _ocjeneKriterija = new Kolekcija<Kriteriji, int>(obj._ocjeneKriterija);
        }

        public void AddOcjenuKriterija(Kriteriji kriterij, int ocjena)
        {
            for (int i = 0; i < _ocjeneKriterija.GetTrenutno(); i++)
            {
                if (_ocjeneKriterija.GetElement1(i).Equals(kriterij))
                    throw new Exception("Kriterij je već ocijenjen.");
            }
            _ocjeneKriterija.AddElement(kriterij, ocjena);
        }

        public float GetProsjekKomentara()
        {
            if (_ocjeneKriterija.GetTrenutno() == 0)
                return 0;

            float sum = 0;
            for (int i = 0; i < _ocjeneKriterija.GetTrenutno(); i++)
            {
                sum += _ocjeneKriterija.GetElement2(i);
            }
            return sum / _ocjeneKriterija.GetTrenutno();
        }

        public static bool operator ==(Komentar k1, Komentar k2)
        {
            if (ReferenceEquals(k1, k2))
                return true;
            if (ReferenceEquals(k1, null) || ReferenceEquals(k2, null))
                return false;

            if (!k1._sadrzajKomentara.Equals(k2._sadrzajKomentara))
                return false;

            if (k1._ocjeneKriterija.GetTrenutno() != k2._ocjeneKriterija.GetTrenutno())
                return false;

            for (int i = 0; i < k1._ocjeneKriterija.GetTrenutno(); i++)
            {
                if (!k1._ocjeneKriterija.GetElement1(i).Equals(k2._ocjeneKriterija.GetElement1(i)) ||
                    k1._ocjeneKriterija.GetElement2(i) != k2._ocjeneKriterija.GetElement2(i))
                    return false;
            }
            return true;
        }

        public static bool operator !=(Komentar k1, Komentar k2)
        {
            return !(k1 == k2);
        }

        public Kolekcija<Kriteriji, int> GetOcjeneKriterija()
        {
            return _ocjeneKriterija;
        }

        public override string ToString()
        {
            StringBuilder COUT = new StringBuilder();
            COUT.AppendLine($"Sadržaj komentara: {_sadrzajKomentara}");
            COUT.AppendLine("Ocjene:");
            for (int i = 0; i < _ocjeneKriterija.GetTrenutno(); i++)
            {
                COUT.AppendLine($"{_ocjeneKriterija.GetElement1(i)}: {_ocjeneKriterija.GetElement2(i)}");
            }
            COUT.AppendLine($"Prosjek ocjena: {GetProsjekKomentara()}");
            return COUT.ToString();
        }

    }
}
