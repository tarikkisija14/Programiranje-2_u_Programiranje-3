using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predmeti
{
    public class Korisnik
    {
        public string _imePrezime { get; set; }
        public string _emailAdresa { get; set; }
        public string _lozinka { get; set; }
        public bool _aktivan { get; set; }

        public Korisnik(string imePrezime, string emailAdresa, string lozinka)
        {
            _imePrezime = imePrezime;
            _emailAdresa = emailAdresa;
            Program program = new Program();
            _lozinka = program.ValidirajLozinku(lozinka) ? lozinka : "Lozinka nije validna";

        }
        public Korisnik(Korisnik obj)
        {
            _imePrezime = obj._imePrezime;
            _emailAdresa = obj._emailAdresa;
            _lozinka = obj._lozinka;
            _aktivan = obj._aktivan;
        }
        public string GetEmail()
        { return _emailAdresa; }
        public string GetLozinka() { return _lozinka; }
        public string GetImePrezime()
        {
            return _imePrezime;
        }
        public bool GetAtivan()
        {
            return _aktivan;
        }
        public void SetAktivan(bool aktivan)
        {
            _aktivan = aktivan;
        }
        public override string ToString()
        {
            StringBuilder COUT = new StringBuilder();
            COUT.AppendLine($"Ime i prezime: {_imePrezime}");
            COUT.AppendLine($"email: {_emailAdresa}");
            COUT.AppendLine($"lozinka: {_lozinka}");
            COUT.AppendLine(_aktivan ? "aktivan" : "Nije aktivan");
            return COUT.ToString();
        }

    }
}
