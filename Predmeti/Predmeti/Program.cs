using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Predmeti
{
    public enum Predmet { UIT, PRI, PRII, PRIII, RSI, RSII };
    public class Program
    {

        public bool ValidirajLozinku(string lozinka)
        {
            return Regex.IsMatch(lozinka, @"(?=.{7,})(?=.*[A-Z]{1,})(?=.*[a-z]{1,})(?=.*[0-9]{1,})(?=.*\W{1,})");
        }


        static void Main(string[] args)
        {
            int kolekcijaTestSize = 10;

            Kolekcija<int, int> kolekcija1 = new Kolekcija<int, int>(kolekcijaTestSize);
            for (int i = 0; i < kolekcijaTestSize - 2; i++)
            {
                kolekcija1.AddElement(i, i);
            }


            Console.WriteLine(kolekcija1);

            Console.WriteLine(Environment.NewLine);

            try
            {

                kolekcija1.AddElement(11, 11);
            }
            catch (Exception err)
            {
                Console.WriteLine("\n--- Greska -> " + err.Message + "\n");
            }

            Console.WriteLine(kolekcija1);

            Console.WriteLine(Environment.NewLine);
            kolekcija1.AddElement(9, 9, 2);

            Console.WriteLine(kolekcija1);


            Kolekcija<int, int> kolekcija2 = new Kolekcija<int, int>(kolekcija1);

            Console.WriteLine(kolekcija1);
            Console.WriteLine(Environment.NewLine);
            try
            {

                kolekcija1[9] = 2;


                Console.WriteLine(kolekcija1);
            }
            catch (Exception err)
            {
                Console.WriteLine("\nError: " + err.Message);
            }
            Console.WriteLine(Environment.NewLine);


            Kolekcija<int, int> kolekcija3 = kolekcija1.GetRange(1, 3);
            Console.WriteLine(kolekcija3);

            Datum datum19062023 = new Datum(19, 6, 2023);
            Datum datum20062023 = new Datum(20, 6, 2023);
            Datum datum30062023 = new Datum(30, 6, 2023);
            Datum datum05072023 = new Datum(5, 7, 2023);

            Console.WriteLine(datum19062023);
            Console.WriteLine(datum20062023);
            Console.WriteLine(datum30062023);
            Console.WriteLine(datum05072023);

            Pitanje sortiranjeNiza = new Pitanje("Navedite algoritme za sortiranje clanova niza?");
            Pitanje dinamickaMemorija = new Pitanje("Navedite pristupe za upravljanje dinamickom memorijom?");
            Pitanje visenitnoProgramiranje = new Pitanje("Na koji se sve nacin moze koristiti veci broj niti tokom izvrsenja programa?");
            Pitanje regex = new Pitanje("Navedite par primjera regex validacije podataka?");
            Pitanje polimorfizam = new Pitanje("Na koji nacin se realizuje polimorfizam?");


            if (sortiranjeNiza.AddOcjena(datum19062023, 1))
            {
                Console.WriteLine("Ocjena evidentirana!");
            }

            if (!sortiranjeNiza.AddOcjena(datum20062023, 5))
            {
                Console.WriteLine("Ocjena NIJE evidentirana!");
            }

            if (sortiranjeNiza.AddOcjena(datum30062023, 5))
            {
                Console.WriteLine("Ocjena evidentirana!");
            }

            if (polimorfizam.AddOcjena(datum19062023, 5))
            {
                Console.WriteLine("Ocjena evidentirana!");
            }

            Console.WriteLine(sortiranjeNiza.ToString());
            Console.WriteLine();

            Program program = new Program();

            if (program.ValidirajLozinku("john4Do*e"))
                Console.WriteLine("Lozinka :: OK :)");
            if (!program.ValidirajLozinku("john4Doe"))
                Console.WriteLine("Lozinka :: Specijalni znak?");
            if (!program.ValidirajLozinku("jo*4Da"))
                Console.WriteLine("Lozinka :: 7 znakova?");
            if (!program.ValidirajLozinku("4jo-hnoe"))
                Console.WriteLine("Lozinka :: Veliko slovo?");
            if (program.ValidirajLozinku("@john2Doe"))
                Console.WriteLine("Lozinka :: OK :)");

            Korisnik jasmin = new Kandidat("Jasmin Azemovic", "jasmin@kursevi.ba", "j@sm1N*");
            Korisnik adel = new Kandidat("Adel Handzic", "adel@edu.kursevi.ba", "4Ade1*H");
            Korisnik lozinkaNijeValidna = new Kandidat("John Doe", "john.doe@google.com", "johndoe");

            Console.WriteLine(jasmin);
            Console.WriteLine(adel);
            Console.WriteLine(lozinkaNijeValidna);


            Kandidat jasminPolaznik = jasmin as Kandidat;



            if (jasminPolaznik != null)
            {
                // Attempt to add Pitanje to Kandidat
                if (jasminPolaznik.AddPitanje(Predmet.PRI, dinamickaMemorija))
                    Console.WriteLine("Pitanje uspjesno dodano!");

                // Shouldn't add visenitnoProgramiranje because there are not 3 questions for PRI
                if (!jasminPolaznik.AddPitanje(Predmet.PRII, visenitnoProgramiranje))
                    Console.WriteLine("Pitanje NIJE uspjesno dodano!");

                if (jasminPolaznik.AddPitanje(Predmet.PRI, visenitnoProgramiranje))
                    Console.WriteLine("Pitanje uspjesno dodano!");

                if (jasminPolaznik.AddPitanje(Predmet.PRI, regex))
                    Console.WriteLine("Pitanje uspjesno dodano!");

                if (jasminPolaznik.AddPitanje(Predmet.PRI, sortiranjeNiza))
                    Console.WriteLine("Pitanje uspjesno dodano!");

                // Sorting should not be added again
                if (!jasminPolaznik.AddPitanje(Predmet.PRI, sortiranjeNiza))
                    Console.WriteLine("Pitanje NIJE uspjesno dodano!");

                // Disable the candidate and try to add a question (should fail since the candidate is not active)
                jasmin.SetAktivan(false);
                if (!jasminPolaznik.AddPitanje(Predmet.PRII, polimorfizam))
                    Console.WriteLine("Pitanje NIJE uspjesno dodano!");

                // Print all details about Kandidat
                Console.WriteLine(jasminPolaznik.ToString());
            }

            void SendEmailWithDelay(string emailContent)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(2000); // 2 seconds delay
                    Console.WriteLine(emailContent); // Simulate sending email
                });
            }

            Datum ocijenjenOD = new Datum(19, 6, 2023);
            Datum ocijenjenDO = new Datum(1, 7, 2023);

            Kolekcija<Pitanje, float> pretraga = jasminPolaznik.GetPitanjaOdgovoreBetweenDates(ocijenjenOD, ocijenjenDO);

            Console.WriteLine($"U periodu od {ocijenjenOD} - {ocijenjenDO} ocijenjeno {pretraga.GetTrenutno()} pitanja.");
            for (int i = 0; i < pretraga.GetTrenutno(); i++)
            {
                Console.WriteLine(pretraga.GetElement1(i));
                Console.WriteLine(pretraga.GetElement2(i));
            }

        }
    }
}
