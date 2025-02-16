using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace AplikacjiaSzyfrowanie
{
    internal class SzyfrCezara
    {
        public string Koduj(string input, string _step)
        {
            char[] zaszyfrowaneZnaki = new char[input.Length];
            
            int step;
            bool konwersjia = int.TryParse(_step, out step);

            if (!konwersjia)
            {
                step = 3; //wewnętrzna wartość dla niepowodzenia konwersji
            }

            for (int i = 0; i < input.Length; i++)
            {
                char znak = input[i];

                if (char.IsLetter(znak))
                {
                    char offset = char.IsUpper(znak) ? 'A' : 'a';
                    zaszyfrowaneZnaki[i] = (char)((znak + step - offset) % 26 + offset);
                }
                else
                {
                    zaszyfrowaneZnaki[i] = znak; // pozostawienie innych znaków bez zmian
                }
            }

            return new string(zaszyfrowaneZnaki);
        }

        public string Dekoduj(string input, string _step)
        {
            char[] odszyfrowaneZnaki = new char[input.Length];

            int step;
            if (!int.TryParse(_step, out step))
            {
                step = 3; //wewnętrzna wartość dla niepowodzenia konwersji
            }

            for (int i = 0; i < input.Length; i++)
            {
                char znak = input[i];

                if (char.IsLetter(znak))
                {
                    char offset = char.IsUpper(znak) ? 'A' : 'a';
                    odszyfrowaneZnaki[i] = (char)((znak - step - offset + 26) % 26 + offset);
                }
                else
                {
                    odszyfrowaneZnaki[i] = znak; // pozostawienie innych znaków bez zmian
                }
            }

            return new string(odszyfrowaneZnaki);
            ;
        }
    }
}
