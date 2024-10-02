namespace Karakteristike
{
   public  enum Karakteristike { NARUDZBA, KVALITET, PAKOVANJE, ISPORUKA };
    internal class Program
    {
        static void Main(string[] args)
        {
            const int KolekcijaTestSize = 9;

            
            Kolekcija<int, int> Kolekcija1 = new Kolekcija<int, int>(false);

           
            for (int i = 0; i < KolekcijaTestSize - 1; i++)
                Kolekcija1.AddElement(i, i); 

            try
            {
                
                Kolekcija1.AddElement(3, 3);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

          
            Kolekcija1.AddElement(9, 9);

            Console.WriteLine(Kolekcija1);

            Kolekcija<int, int> Kolekcija2 = Kolekcija1.GetRange(2, 5);
           
            Console.WriteLine(Kolekcija2);

            Kolekcija<int, int> Kolekcija3 = Kolekcija1.GetRange(2, 5, true);
           
            Console.WriteLine(Kolekcija3);

            Kolekcija3 = Kolekcija2;
            Console.WriteLine(Kolekcija3);

            ZadovoljstvoKupca zadovoljstvoKupca = new ZadovoljstvoKupca(7);
            zadovoljstvoKupca.DodajKomentarKarakteristike(Karakteristike.NARUDZBA, "Nismo mogli odabrati sve potrebne opcije");
            zadovoljstvoKupca.DodajKomentarKarakteristike(Karakteristike.KVALITET, "Kvalitet je očekivan");

            try
            {
                
                zadovoljstvoKupca.DodajKomentarKarakteristike(Karakteristike.KVALITET, "Kvalitet je očekivan");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            zadovoljstvoKupca.DodajKomentarKarakteristike(Karakteristike.PAKOVANJE, "Pakovanje je bilo oštećeno");
            zadovoljstvoKupca.DodajKomentarKarakteristike(Karakteristike.ISPORUKA, "Mada su najavili da će proizvod biti isporučen u roku od 2 dana, čekali smo 5 dana");

            Console.WriteLine(zadovoljstvoKupca);

            const int maxKupaca = 3;
            Osoba[] kupci = new Osoba[maxKupaca];
            kupci[0] = new Kupac("Denis Music", new Datum(12, 1, 1980), "denis@fit.ba");
            kupci[1] = new Kupac("Jasmin Azemovic", new Datum(12, 2, 1980), "jasmin@fit.ba");
            kupci[2] = new Kupac("Adel Handzic", new Datum(12, 3, 1980), "adel@edu.fit.ba");

            Kupac denis = (Kupac)kupci[0];
            denis.DodajKupovinu(128, new ZadovoljstvoKupca(7));
            Console.WriteLine("Ukupno bodova -> " + denis.GetBodoviUkupno()); 

            ZadovoljstvoKupca zadovoljstvoKupca2 = new ZadovoljstvoKupca(4);
            zadovoljstvoKupca2.DodajKomentarKarakteristike(Karakteristike.KVALITET, "Jako lose, proizvod ostecen");
            denis.DodajKupovinu(81, zadovoljstvoKupca2);

            Console.WriteLine("Ukupno bodova -> " + denis.GetBodoviUkupno()); 

            
            denis.Info();

           Kolekcija<Karakteristike, string> osteceniProizvodi = denis.GetKupovineByKomentar("ostecen");
            Console.WriteLine(Environment.NewLine + "Rezultat pretrage -> " + Environment.NewLine + osteceniProizvodi + Environment.NewLine);

        }
    }
}
