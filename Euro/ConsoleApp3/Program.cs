using System.Text;

namespace ConsoleApp3
{

    public enum Drzava
    {
        ENGLESKA,
        SPANIJA,
        HOLANDIJA,
        FRANCUSKA,
        BOSNA_I_HERCEGOVINA
    }
    public class Program
    {
        public static string GenerisiID(string imePrezime, int broj)
        {
            StringBuilder id = new StringBuilder();
            id.Append(char.ToUpper(imePrezime[0]));

            string obrnuti = broj.ToString();
            char[] obrnutiArray = obrnuti.ToCharArray();
            Array.Reverse(obrnutiArray);
            obrnuti = new string(obrnutiArray);

            if (broj < 10)
                id.Append("000");
            else if (broj < 100)
                id.Append("00");
            else if (broj < 1000)
                id.Append("0");

            int inicijali = imePrezime.IndexOf(' ') + 1;
            if (inicijali > 0 && inicijali < imePrezime.Length)
            {
                id.Append(char.ToUpper(imePrezime[inicijali]));
            }

            id.Append(obrnuti);
            return id.ToString();
        }

        public static int BrojCifara(string broj)
        {
            int brojac = 0;
            for (int i = 0; i < broj.Length; i++)
            {
                if (char.IsDigit(broj[i]))
                {
                    brojac++;
                }
            }
            return brojac;
        }
        
        public static bool ValidirajID(string id)
        {
            var regex = new System.Text.RegularExpressions.Regex("^[A-Z][0]{0,4}[A-Z][0-9]{1,4}$");
            return regex.IsMatch(id) && BrojCifara(id) == 4;
        }


        static void Main(string[] args)
        {
            Console.WriteLine(GenerisiID("Denis Music", 3));         
            Console.WriteLine(GenerisiID("Jasmin Azemovic", 14));    
            Console.WriteLine(GenerisiID("Goran Skondric", 156));     
            Console.WriteLine(GenerisiID("emina junuz", 1798));

            if (ValidirajID("D000M3"))
                Console.WriteLine("ID VALIDAN");
            if (ValidirajID("J00A41"))
                Console.WriteLine("ID VALIDAN");
            if (!ValidirajID("G00S651"))
                Console.WriteLine("ID NIJE VALIDAN");
            if (!ValidirajID("Ej8971"))
                Console.WriteLine("ID NIJE VALIDAN");


            Kolekcija<int, int> kolekcija1 = new Kolekcija<int, int>(10);
            kolekcija1.AddElement(1, 100);
            kolekcija1.AddElement(2, 200);
            kolekcija1.AddElement(3, 300);
            kolekcija1.AddElement(4, 400);
            Console.WriteLine(kolekcija1);
            Console.WriteLine("---------");

            Kolekcija<int, int> kolekcija2 = kolekcija1.InsertAt(10, 10, 0);
            Console.WriteLine(kolekcija2);
            Console.WriteLine("---------");


            Kolekcija<int, int> kolekcija3 = kolekcija1.RemoveRange(1, 3);
            Console.WriteLine(kolekcija3);
            Console.WriteLine("---------");

            Console.WriteLine(kolekcija1);
            Console.WriteLine("---------");
            kolekcija1 = kolekcija3;
            Console.WriteLine(kolekcija1);

            Vrijeme prviPogodakVrijeme = new Vrijeme(20, 16, 33);
            Vrijeme drugiPogodakVrijeme = new Vrijeme(20, 23, 19);
            Vrijeme treciPogodakVrijeme = new Vrijeme(20, 51, 8);
            Vrijeme cetvrtiPogodakVrijeme = new Vrijeme(21, 6, 54);

            Pogodak prviPogodak = new Pogodak(prviPogodakVrijeme, "Podaci o prvom pogotku");
            Pogodak drugiPogodak = new Pogodak(drugiPogodakVrijeme, "Podaci o drugom pogotku");
            Pogodak treciPogodak = new Pogodak(treciPogodakVrijeme, "Podaci o trećem pogotku");
            Pogodak cetvrtiPogodak = new Pogodak(cetvrtiPogodakVrijeme, "Podaci o četvrtom pogotku");

            Igrac denis = new Igrac("Denis Music");
            Igrac jasmin = new Igrac("Jasmin Azemovic");
            Igrac goran = new Igrac("Goran Skondric");
            Igrac adil = new Igrac("Adil Joldic");

            if (denis.GetID() == "D000M1" && jasmin.GetID() == "J000A2")
            {
                Console.WriteLine("ID se uspjesno generise!");
            }

            Reprezentacija BIH = new Reprezentacija(Drzava.BOSNA_I_HERCEGOVINA);
            Reprezentacija ENG = new Reprezentacija(Drzava.ENGLESKA);

            BIH.AddIgrac(denis);
            BIH.AddIgrac(jasmin);
            ENG.AddIgrac(goran);
            ENG.AddIgrac(adil);

            try
            {
              
                BIH.AddIgrac(denis); // onemoguciti dodavanje istih igraca - provjeravati ID
            }
            catch (Exception ex)
            {
                // Ispis poruke o grešci
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            Prventstvo euro2024 = new Prventstvo();
            euro2024.AddUtakmicu(BIH, ENG);
            try
            {
                euro2024.AddUtakmicu(BIH, ENG); 
            }
            catch (Exception obj)
            {
                Console.WriteLine(obj.Message);
            }
            Console.WriteLine();
            if (euro2024.AddPogodak(Drzava.BOSNA_I_HERCEGOVINA, Drzava.ENGLESKA, "D000M1", prviPogodak))
            {
                Console.WriteLine("Pogodak uspjesno dodat");
            }
            if (!euro2024.AddPogodak(Drzava.BOSNA_I_HERCEGOVINA, Drzava.ENGLESKA, "Denis Music", prviPogodak))
            {
                Console.WriteLine("Pogodak NIJE uspjesno dodat");
            }
            if (euro2024.AddPogodak(Drzava.BOSNA_I_HERCEGOVINA, Drzava.ENGLESKA, "J000A2", drugiPogodak))
            {
                Console.WriteLine("Pogodak uspjesno dodat");
            }
            if (euro2024.AddPogodak(Drzava.BOSNA_I_HERCEGOVINA, Drzava.ENGLESKA, "Jasmin Azemovic", treciPogodak))
            {
                Console.WriteLine("Pogodak uspjesno dodat");
            }
            if (euro2024.AddPogodak(Drzava.BOSNA_I_HERCEGOVINA, Drzava.ENGLESKA, "Goran Skondric", cetvrtiPogodak))
            {
                Console.WriteLine("Pogodak uspjesno dodat");
            }
            Console.WriteLine(euro2024);
            List<Igrac> igraci = euro2024[2];
            for (int i = 0; i < igraci.Count; i++)
            {
                Console.WriteLine(igraci[i].GetImePrezime());
            }
        }
    }
}
