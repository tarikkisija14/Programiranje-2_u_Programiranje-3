using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karakteristike
{
    public class ZadovoljstvoKupca
    {
        private int _ocjena { get; set; }
        private Kolekcija<Karakteristike,string>_komentariKarakteristika{ get; set; }

        public ZadovoljstvoKupca(int ocjena=0)
        {
            _ocjena = ocjena;
            _komentariKarakteristika = new Kolekcija<Karakteristike, string>(false);
        }
        public ZadovoljstvoKupca(ZadovoljstvoKupca obj)
        {
            _ocjena=obj._ocjena;
            _komentariKarakteristika=new Kolekcija<Karakteristike, string>(obj._komentariKarakteristika);
        }

        public static bool operator==(ZadovoljstvoKupca z1,ZadovoljstvoKupca z2)
        {
            if(z1._ocjena!=z2._ocjena) return false;
            if (z1._komentariKarakteristika.GetTrenutno() != z2._komentariKarakteristika.GetTrenutno()) return false;
            for (int i = 0; i < z1._komentariKarakteristika.GetTrenutno(); i++)
            {
                if (!z1._komentariKarakteristika.GetElement1(i).Equals(z2._komentariKarakteristika.GetElement1(i)) ||
              z1._komentariKarakteristika.GetElement2(i) != z2._komentariKarakteristika.GetElement2(i))
                    return false;
            }
            return true;
        }
        public static bool operator !=(ZadovoljstvoKupca z1, ZadovoljstvoKupca z2)
        {
            return !(z1 == z2);
        }

        public void DodajKomentarKarakteristike(Karakteristike k,string komentar)
        {
            for (int i = 0; i < _komentariKarakteristika.GetTrenutno(); i++)
            {
                if (_komentariKarakteristika.GetElement1(i).Equals(k))
                    throw new Exception("Karakteristika vec dodana");
            }
            _komentariKarakteristika.AddElement(k, komentar);
        }

        public int GetOcjena()
        {
            return _ocjena;
        }

        public Kolekcija<Karakteristike, string> GetKomentareKarakteristika()
        {
            return _komentariKarakteristika;
        }


        public override string ToString()
        {
            StringBuilder COUT = new StringBuilder();
            COUT.AppendLine($"Ocjena: {_ocjena}");
            COUT.AppendLine("Komentari:");
            for (int i = 0; i < _komentariKarakteristika.GetTrenutno(); i++)
            {
                COUT.AppendLine($"{_komentariKarakteristika.GetElement1(i)} --> {_komentariKarakteristika.GetElement2(i)}");
            }
            return COUT.ToString();
        }

    }
}
