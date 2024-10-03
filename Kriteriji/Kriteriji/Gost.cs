using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kriteriji
{
    public class Gost
    {
        private string _imePrezime;
        private string _emailAdresa;
        private string _brojPasosa;

        public Gost(string imePrezime, string emailAdresa, string brojPasosa)
        {
            _imePrezime = imePrezime;
            _emailAdresa = emailAdresa;
            _brojPasosa = Program.ValidirajBrojPasosa(brojPasosa) ? brojPasosa : "NOTSTET";
        }
        public Gost(Gost obj)
        {
            _imePrezime = obj._imePrezime;
            _emailAdresa = obj._emailAdresa;
            _brojPasosa = obj._brojPasosa;
        }

        public static bool operator ==(Gost g1, Gost g2)
        {
            if (ReferenceEquals(g1, g2)) return true;
            if (g1 is null || g2 is null) return false;

            return g1._imePrezime == g2._imePrezime &&
                   g1._emailAdresa == g2._emailAdresa &&
                   g1._brojPasosa == g2._brojPasosa;
        }
        public static bool operator !=(Gost g1, Gost g2)
        {
            return !(g1 == g2);
        }
        public string GetEmail()
        {
            return _emailAdresa;
        }

        public string GetBrojPasosa()
        {
            return _brojPasosa;
        }

        public string GetImePrezime()
        {
            return _imePrezime;
        }

        public override string ToString()
        {
            StringBuilder COUT = new StringBuilder();
            COUT.AppendLine($"{_imePrezime} {_emailAdresa} {_brojPasosa}");
            return COUT.ToString(); 
        }

    }
}
