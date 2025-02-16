using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjiaSzyfrowanie
{
    //internal class SzyfrVigenere
    //{
    //}

    internal class SzyfrVigenere
    {
        private string klucz = "";

        private string Klucz {
            set { klucz = PrzygotujKlucz(value); } 
        }

        private string PrzygotujKlucz(string klucz)
        {
            klucz = klucz.ToUpper();
            if (klucz.Any(c => !char.IsLetter(c)))
            {
                throw new ArgumentException("Klucz musi zawierać tylko litery.");
            }
            return klucz;
        }

        private string RozszerzKlucz(string tekst)
        {
            var rozszerzonyKlucz = new char[tekst.Length];
            int kluczIndex = 0;

            for (int i = 0; i < tekst.Length; i++)
            {
                if (char.IsLetter(tekst[i]))
                {
                    rozszerzonyKlucz[i] = klucz[kluczIndex % klucz.Length];
                    kluczIndex++;
                }
                else
                {
                    rozszerzonyKlucz[i] = tekst[i]; // Znak specjalny lub odstęp
                }
            }

            return new string(rozszerzonyKlucz);
        }

        public string Koduj(string input, string klucz)
        {
            input = input.ToUpper();
            klucz = klucz.ToUpper();
            Klucz = klucz;

            string rozszerzonyKlucz = RozszerzKlucz(input);
            char[] zaszyfrowanyTekst = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                char znak = input[i];
                if (char.IsLetter(znak))
                {
                    char offset = 'A';
                    zaszyfrowanyTekst[i] = (char)(((znak - offset + (rozszerzonyKlucz[i] - offset)) % 26) + offset);
                }
                else
                {
                    zaszyfrowanyTekst[i] = znak; // Pozostawienie innych znaków bez zmian
                }
            }

            return new string(zaszyfrowanyTekst);
        }

        public string Dekoduj(string input, string klucz)
        {
            input = input.ToUpper();
            klucz = klucz.ToUpper();
            Klucz = klucz;

            string rozszerzonyKlucz = RozszerzKlucz(input);
            char[] odszyfrowanyTekst = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                char znak = input[i];
                if (char.IsLetter(znak))
                {
                    char offset = 'A';
                    odszyfrowanyTekst[i] = (char)(((znak - offset - (rozszerzonyKlucz[i] - offset) + 26) % 26) + offset);
                }
                else
                {
                    odszyfrowanyTekst[i] = znak; // Pozostawienie innych znaków bez zmian
                }
            }

            return new string(odszyfrowanyTekst);
        }
    }

}
