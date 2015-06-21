using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    class Dane
    {
        public string tekst { get; set; }
        //private int index { get; set; }
        public int dlugosc { get; set; } //dlugosc tekstu
        private char[] textChar { get; set; } //tablica znakow tekstu
        private int liczbaKodowa { get; set; }
        public bool error { get; set; } //flaga na blad
        public bool czyZnalazl { get; set; } //czy odnalzl znak do opisu
        public bool czyZnalazlCalkowita { get; set; } //czy odnalzl znak do opisu liczby calkowitej
        public bool czyZnalazlZmienno {get; set; } //czy znalazl przedrostek do kropki

        public Dane(string tekstAnaliza)
        {
            this.tekst = tekstAnaliza;
            //this.index = 0;
            this.dlugosc = tekstAnaliza.Length;
            //zamiana stringu na znaki
            textChar = new char[tekstAnaliza.Length];
            textChar = tekstAnaliza.ToCharArray();
            this.error = false;
            this.czyZnalazl = false;

        }

        public void Wyswietl()
        {
            Console.WriteLine("==");
            Console.WriteLine(tekst);
            //Console.WriteLine(index);
            Console.WriteLine(dlugosc);
            for (int i = 0; i < dlugosc; i++)
            {
                Console.WriteLine(textChar[i]);
            }
            KodZnaku('0');
            Console.WriteLine(liczbaKodowa);
            Console.WriteLine("==");
        }

        private void KodZnaku(char symbol)
        {
            this.liczbaKodowa = (int)symbol;
        } //ustawia liczbe kodowa

        public int ZnakPlus(int index)
        {
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else return index;

            if (liczbaKodowa == 43)
            {
                Console.WriteLine("Dodoawanie:                {0}", textChar[index]);
                this.czyZnalazl = true;

                index++;

                return index;
            }
            return index;
        }

        public int ZnakMinus(int index)
        {
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else return index;

            if (liczbaKodowa == 45)
            {
                Console.WriteLine("Odejmowanie:               {0}", textChar[index]);
                this.czyZnalazl = true;

                index++;

                return index;
            }
            return index;
        }

        public int ZnakMnozenie(int index)
        {
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else return index;

            if (liczbaKodowa == 42)
            {
                Console.WriteLine("Mnozenie:                  {0}", textChar[index]);
                this.czyZnalazl = true;

                index++;

                return index;
            }
            return index;
        }

        public int ZnakDzielenie(int index)
        {
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else return index;

            if (liczbaKodowa == 47)
            {
                Console.WriteLine("Dzielenie:                 {0}", textChar[index]);
                this.czyZnalazl = true;

                index++;

                return index;
            }
            return index;
        }

        public int ZnakNawiasOtwarty(int index)
        {
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else return index;

            if (liczbaKodowa == 40)
            {
                Console.WriteLine("Nawias otwarty:            {0}", textChar[index]);
                this.czyZnalazl = true;

                index++;

                return index;
            }
            return index;
        }

        public int ZnakNawiasZamkniety(int index)
        {
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else return index;

            if (liczbaKodowa == 41)
            {
                Console.WriteLine("Nawias zamkniety:          {0}", textChar[index]);
                this.czyZnalazl = true;

                index++;

                return index;
            }
            return index;
        }

        public int ZnakBialy(int index)
        {
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else return index;

            if (liczbaKodowa == 32)
            {
                Console.WriteLine("Znak bialy (spacja)        {0}", textChar[index]);
                this.czyZnalazl = true;

                index++;

                return index;
            }
            return index;
        }

        public int ZnakBialyNowaLinia(int index)
        {
            int indexBufor = index;
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else return index;

            if (liczbaKodowa == 13) // /r
            {
                index++;
                if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                {
                    KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                }
                else return indexBufor;
                if (liczbaKodowa == 10) // /n
                {
                    Console.WriteLine("Znak bialy (enter)         {0}", textChar[index]);
                    this.czyZnalazl = true;
                }
                index++;
                return index;
            }
            return index;
        }

        public int IdentyfikatorSprawdzenie(int index)
        {
            int indexBufor = index;
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else return index;

            //sprawdzenie czy identyfikator rozpoczyna sie od litery
            if ((liczbaKodowa > 64 && liczbaKodowa < 123) || (liczbaKodowa > 64 && liczbaKodowa < 91))
            {
            }
            else return index;

            index++;
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else return indexBufor;

            do
            {
                //litery male, duze, cyfry
                if ((liczbaKodowa > 64 && liczbaKodowa < 123) || (liczbaKodowa > 64 && liczbaKodowa < 91) || (liczbaKodowa > 47 && liczbaKodowa < 58))
                {
                    index++;
                    czyZnalazlCalkowita = true;
                    if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                    {
                        KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                    }
                    else break;
                }
                else
                {
                    czyZnalazl = false;
                    return indexBufor;
                }
                if (index == dlugosc)
                    break;
            } while ((liczbaKodowa > 64 && liczbaKodowa < 123) || (liczbaKodowa > 64 && liczbaKodowa < 91) || (liczbaKodowa > 47 && liczbaKodowa < 58));
            
            IdentyfikatorWyswietl(indexBufor);
            return index;
        }

        public int IdentyfikatorWyswietl(int index)
        {
            int indexBufor = index;
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else return index;

            Console.Write("Identyfikator:             {0}", textChar[index]);
            this.czyZnalazl = true;
            index++;

            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else return index;
            do
            {
                //litery male, duze, cyfry
                if ((liczbaKodowa > 64 && liczbaKodowa < 123) || (liczbaKodowa > 64 && liczbaKodowa < 91) || (liczbaKodowa > 47 && liczbaKodowa < 58))
                {
                    Console.Write("{0}", textChar[index]);
                    this.czyZnalazl = true;
                    index++;
                    
                    if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                    {
                        KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                    }
                    else return index;
                }
                if (index == dlugosc)
                    break;
            } while ((liczbaKodowa > 64 && liczbaKodowa < 123) || (liczbaKodowa > 64 && liczbaKodowa < 91) || (liczbaKodowa > 47 && liczbaKodowa < 58));
            Console.WriteLine();
            czyZnalazl = true;
            return index;
        }

        public int Litera(int index)
        {
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else return index;
            if ((liczbaKodowa > 64 && liczbaKodowa < 123) || (liczbaKodowa > 64 && liczbaKodowa < 91))
            {
                Console.WriteLine("Litera:                    {0}", textChar[index]);
                this.czyZnalazl = true;

                index++;

                return index;
            }
            return index;
        }

        public int LiczbaCalkowitaSprawdzenie(int index)
        {

            czyZnalazlCalkowita = false;
            int licznikPrzedKropka = 0;
            int indexBufor = index;
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else
            {
                return index;
            }
            if (licznikPrzedKropka == 46)
            {
                return indexBufor;
            }

            if (liczbaKodowa == 48)  //czy wyrazenie nie rozpoczyna sie od 0 (BLAD)
            {
                return index;
            }

            do
            {
                if (liczbaKodowa > 47 && liczbaKodowa < 58)
                {
                    index++;
                    licznikPrzedKropka++;
                    czyZnalazlCalkowita = true;
                    if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                    {
                        KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                    }
                    else break;
                }
                if (index == dlugosc)
                    break;
            } while ((liczbaKodowa > 47) && (liczbaKodowa < 58));

            if (liczbaKodowa == 46) //sprawdzenie kropki
            {
                index++;
                if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                {
                    KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                }
                else
                {
                    LiczbyCalkowiteWyswietl(indexBufor);
                    error = true;
                    return licznikPrzedKropka;
                }

                if (liczbaKodowa == 48) //zakres 0
                {
                    do //zera po kropce
                    {
                        LiczbyCalkowiteWyswietl(index);
                        index++;
                        if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                        {
                            KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                        }
                        else break;
                    } while (liczbaKodowa == 48);
                    if ((liczbaKodowa > 48 && liczbaKodowa < 58)) //jesli po kropce nie jest zero
                    {
                        czyZnalazl = false;
                        return indexBufor;
                    }
                }
                else
                {
                    LiczbyCalkowiteWyswietl(indexBufor);
                    return licznikPrzedKropka;
                }
            }

            LiczbyCalkowiteWyswietl(indexBufor);
            return index;
        } //Sprawdzenie czy liczba calkowita

        public int LiczbyCalkowiteWyswietl(int indexBufor)
        {
            int index = indexBufor;
            int licznikPrzedKropka = 0;
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else
            {
                return index;
            }
            if (liczbaKodowa == 48)  //czy wyrazenie nie rozpoczyna sie od 0 (BLAD)
            {
                return index;
            }
            if (liczbaKodowa > 48 && liczbaKodowa < 58) // zakres od 1-9
            {
                Console.Write("Liczba calkowita:          {0}", textChar[index]);
                this.czyZnalazl = true;

                index++;
                licznikPrzedKropka++;

                if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                {
                    KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                }
                else return index;
                do
                {
                    if (liczbaKodowa > 47 && liczbaKodowa < 58) //zakres od 0-9
                    {
                        Console.Write("{0}", textChar[index]);
                        czyZnalazl = true;
                        index++;
                        licznikPrzedKropka++;
                        if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                        {
                            KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                        }
                        else return index;
                    }
                    if (liczbaKodowa == 46) //sprawdzenie kropki
                    {
                        
                        //Console.Write("{0}", textChar[index]);
                        index++;
                        if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                        {
                            KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                        }
                        else
                        {
                            czyZnalazl = true;
                            index--;
                            return licznikPrzedKropka;
                        }
                        if (liczbaKodowa == 48) //zakres 0
                        {
                            index--;
                            Console.Write("{0}", textChar[index]);
                            index++;
                            do //zera po kropce
                            {
                                Console.Write("{0}", textChar[index]);
                                czyZnalazl = true;
                                index++;
                                if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                                {
                                    KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                                }
                                else return index;
                            } while (liczbaKodowa == 48);
                        }
                        else
                        {
                            czyZnalazl = true;
                            return licznikPrzedKropka;
                        }
                        czyZnalazl = true;
                        Console.WriteLine();
                        return index;
                    }
                }
                while ((liczbaKodowa > 47) && (liczbaKodowa < 58));
                Console.WriteLine();
                czyZnalazl = true;
                return index;
            }
            return index;
        }  //Odczytanie i wyswietlenie liczby calkowitej

        public int LiczbaZmiennoSprawdzenie(int index)
        {
            czyZnalazlZmienno = false;
            int indexBufor = index;
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else
            {
                return index;
            }

            do
            {
                if (liczbaKodowa > 47 && liczbaKodowa < 58)
                {
                    index++;
                    if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                    {
                        KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                    }
                    else break;
                }
                if (index == dlugosc)
                    break;
            } while ((liczbaKodowa > 47) && (liczbaKodowa < 58));

            if (liczbaKodowa == 46) //sprawdzenie kropki
            {
                index++;
                if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                {
                    KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                }
                else
                {
                    return index;
                }

                if (liczbaKodowa > 47 && liczbaKodowa < 58)
                {
                    do //liczby po kropce
                    {
                        index++;
                        if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                        {
                            KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                        }
                        else break;
                    } while (liczbaKodowa > 47 && liczbaKodowa < 58);
                }
                else
                {
                    czyZnalazl = false;
                    return indexBufor;
                }
            }
            else
            {
                czyZnalazl = false;
                return indexBufor;
            }

            LiczbaZmiennoWyswietl(indexBufor);
            return index;
        } //Sprawdzenie czy liczba zmiennoprzecinkowa

        public int LiczbaZmiennoWyswietl(int indexBufor) //Odczytanie i wyswietlenie liczby zmiennoprzecinkowej
        {
            int index = indexBufor;
            if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
            {
                KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
            }
            else
            {
                return index;
            }
           
            if (liczbaKodowa > 47 && liczbaKodowa < 58) // zakres od 0-9
            {
                Console.Write("Liczba zmiennoprzecinkowa: {0}", textChar[index]);
                index++;

                if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                {
                    KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                }
                else return index;
                do
                {
                    if (liczbaKodowa > 47 && liczbaKodowa < 58) //zakres od 0-9
                    {
                        Console.Write("{0}", textChar[index]);
                        index++;
                        if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                        {
                            KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                        }
                        else return index;
                    }
                    if (liczbaKodowa == 46) //sprawdzenie kropki
                    {
                        Console.Write("{0}", textChar[index]);
                        index++;
                        if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                        {
                            KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                        }
                        else
                        {
                            return index;
                        }
                        if (liczbaKodowa > 47 && liczbaKodowa < 58)
                        {
                            do //cyfry po kropce
                            {
                                Console.Write("{0}", textChar[index]);
                                czyZnalazl = true;
                                index++;
                                if (index < dlugosc) //sprawdzenie czy mozna czytac tablice
                                {
                                    KodZnaku(this.textChar[index]); //pobranie i wprowadzenie danych do zmeinnej liczbaKodowa
                                }
                                else return index;
                            } while (liczbaKodowa > 47 && liczbaKodowa < 58);
                        }
                        else
                        {
                            return index;
                        }
                        czyZnalazl = true;
                        Console.WriteLine();
                        return index;
                    }
                }
                while ((liczbaKodowa > 47) && (liczbaKodowa < 58));
                Console.WriteLine();
                czyZnalazl = true;
                return index;
            }
            return index;
        }

    }
}
