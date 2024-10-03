using System.Text.RegularExpressions;

namespace Kriteriji
{
    public enum Kriteriji { CISTOCA, USLUGA, LOKACIJA, UDOBNOST };
    

    internal class Program
    {
        public static bool ValidirajBrojPasosa(string pasos)
        {
            return Regex.IsMatch(pasos, @"^[A-Z]{1,2}[0-9]{3,4}([- ]?[0-9]{2,4})?$");
        }

        static void Main(string[] args)
        {
            Datum datum19062022 = new Datum(19, 6, 2022);
            Datum datum20062022 = new Datum(20, 6, 2022);
            Datum datum30062022 = new Datum(30, 6, 2022);
            Datum datum05072022 = new Datum(5, 7, 2022);


            int kolekcijaTestSize = 9;
            Kolekcija<int, int> kolekcija1 = new Kolekcija<int, int>(false);

            for (int i = 0; i <= kolekcijaTestSize; i++)
            {
                kolekcija1.AddElement(i, i);
            }

            try
            {
               
                kolekcija1.AddElement(3, 3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(kolekcija1.ToString());
            Kolekcija<int, int> kolekcija2 = kolekcija1.InsertAt(0, 10, 10);
            Console.WriteLine(kolekcija2.ToString());

            Komentar komentarRezervacija = new Komentar("Nismo pretjerano zadovoljni uslugom, a ni lokacijom.");
            komentarRezervacija.AddOcjenuKriterija(Kriteriji.CISTOCA, 7);
            komentarRezervacija.AddOcjenuKriterija(Kriteriji.USLUGA, 4);
            komentarRezervacija.AddOcjenuKriterija(Kriteriji.LOKACIJA, 3);
            komentarRezervacija.AddOcjenuKriterija(Kriteriji.UDOBNOST, 6);

            try
            {
                komentarRezervacija.AddOcjenuKriterija(Kriteriji.UDOBNOST, 6); // Kriterij udobnosti je već ocijenjen!
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            Console.WriteLine(komentarRezervacija);

            if (ValidirajBrojPasosa("BH235-532"))
                Console.WriteLine("Broj pasosa validan");
            if (ValidirajBrojPasosa("B123321"))
                Console.WriteLine("Broj pasosa validan");
            if (ValidirajBrojPasosa("B1252 521"))
                Console.WriteLine("Broj pasosa validan");
            if (!ValidirajBrojPasosa("H4521"))
                Console.WriteLine("Broj pasosa NIJE validan");
            if (!ValidirajBrojPasosa("b1252 521"))
                Console.WriteLine("Broj pasosa NIJE validan");

            Gost denis = new Gost("Denis Music", "denis@fit.ba", "BH235-532");
            Gost jasmin = new Gost("Jasmin Azemovic", "jasmin@fit.ba", "B123321");
            Gost adel = new Gost("Adel Handzic", "adel@edu.fit.ba", "B1252 521");
            Gost gostPasosNotValid = new Gost("Ime Prezime", "korisnik@klix.ba", "H4521"); // _brojPasosa = "NOTSTET"

            Rezervacija rezervacija = new Rezervacija(datum19062022, datum20062022, denis);

            if (rezervacija.AddGost(jasmin))
                Console.WriteLine("Gost uspješno dodan!");

            
            rezervacija.SetKomentar(komentarRezervacija);

           
            Console.WriteLine(rezervacija);

            
            Rezervacija rezervacijaSaAdelom = rezervacija;
            if (rezervacijaSaAdelom.AddGost(adel))
                Console.WriteLine("Gost uspješno dodan!");

            
            if (!rezervacijaSaAdelom.AddGost(denis))
                Console.WriteLine("Gost je već dodan na rezervaciju!");

            
            Console.WriteLine(rezervacijaSaAdelom);


        }
    }
}
