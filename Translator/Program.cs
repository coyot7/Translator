using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Translator
{
    class Program
    {
        public static void WysietlanieBledu(int indeks)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nBlad skladni, indeks: {0}", indeks);
            Console.ResetColor();
        }

        public static Dane Czytaj(string sciezka)
        {
            try
            {
                using (StreamReader sr = new StreamReader(sciezka))
                {
                    String tekst = sr.ReadToEnd();
                    Dane tekst1 = new Dane(tekst);
                    return tekst1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("BLAD !! Nie mozna odczytac pliku");
                Console.WriteLine(e.Message);
            }
            Dane tekstPusty = new Dane("");
            return tekstPusty;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Witam w translatorze, wprowadz sciezke:\n");
            string sciezka = Console.ReadLine();
            Console.Clear();

            Dane tekst1 = new Dane(Czytaj(sciezka).tekst);  
            Console.WriteLine(tekst1.tekst);
           
            for (int i = 0; i < tekst1.dlugosc; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine("\n");
            // Console.WriteLine("Dlugosc = {0}", tekst1.dlugosc);
            //Sprawdzenie znaku
            //SprawdzenieZnaku.Sprawdzarka('\n');

            int indeks = 0;
            do
            {
                tekst1.czyZnalazl = false; //ustawienie falgi wyszukania

                indeks = tekst1.IdentyfikatorSprawdzenie(indeks); //Identyfikator
                if (tekst1.error == true)
                {
                    WysietlanieBledu(indeks);
                    break;
                }
                
                indeks = tekst1.Litera(indeks); //litery
                if (tekst1.error == true)
                {
                    WysietlanieBledu(indeks);
                    break;
                }

                indeks = tekst1.LiczbaCalkowitaSprawdzenie(indeks); //liczby calkowite
                if (tekst1.error == true)
                {
                    WysietlanieBledu(indeks);
                    break;
                }
                //if (tekst1.czyZnalazlCalkowita == true)
                //{
                //    indeks = tekst1.LiczbyCalkowiteWyswietl(indeks);
                //}

                indeks = tekst1.LiczbaZmiennoSprawdzenie(indeks); //liczby zmiennoprzecinkowe
                if (tekst1.error == true)
                {
                    WysietlanieBledu(indeks);
                    break;
                }

                indeks = tekst1.ZnakPlus(indeks); //znak dodawanie
                if (tekst1.error == true)
                {
                    WysietlanieBledu(indeks);
                    break;
                }

                indeks = tekst1.ZnakMinus(indeks); //znak odejmowanie
                if (tekst1.error == true)
                {
                    WysietlanieBledu(indeks);
                    break;
                }

                indeks = tekst1.ZnakMnozenie(indeks); //znak mnozenie
                if (tekst1.error == true)
                {
                    WysietlanieBledu(indeks);
                    break;
                }

                indeks = tekst1.ZnakDzielenie(indeks); //znak dzielenie
                if (tekst1.error == true)
                {
                    WysietlanieBledu(indeks);
                    break;
                }

                indeks = tekst1.ZnakNawiasOtwarty(indeks); //znak nawias otwrty
                if (tekst1.error == true)
                {
                    WysietlanieBledu(indeks);
                    break;
                }

                indeks = tekst1.ZnakNawiasZamkniety(indeks); //znak nawias zamkniety
                if (tekst1.error == true)
                {
                    WysietlanieBledu(indeks);
                    break;
                }

                indeks = tekst1.ZnakBialy(indeks); //znak spacji
                if (tekst1.error == true)
                {
                    WysietlanieBledu(indeks);
                    break;
                }

                indeks = tekst1.ZnakBialyNowaLinia(indeks); //znak enter
                if (tekst1.error == true)
                {
                    WysietlanieBledu(indeks);
                    break;
                }


                if (tekst1.czyZnalazl == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nBlad skladni, indeks: {0}", indeks+1);
                    Console.ResetColor();
                    break;
                }
            }
            while (indeks < tekst1.dlugosc);


            
               
            Console.ReadLine();
        }
    }
}
