using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjiaSzyfrowanie
{
    internal class SzyfrPolibiusza
    {
        private static readonly char[,] tablicaPolibiusza = new char[5, 5]
        {
            { 'A', 'B', 'C', 'D', 'E' },
            { 'F', 'G', 'H', 'I', 'K' },  // 'J' traktowane jako 'I'
            { 'L', 'M', 'N', 'O', 'P' },
            { 'Q', 'R', 'S', 'T', 'U' },
            { 'V', 'W', 'X', 'Y', 'Z' }
        };

        private static (int, int) ZnajdzPozycje(char znak)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (tablicaPolibiusza[i, j] == znak)
                        return (i, j);
                }
            }
            throw new Exception("Znak nie znaleziony w matrycy.");
        }

        private string PrzygotujTekst(string tekst)
        {
            tekst = tekst.ToUpper().Replace("J", "I"); // Traktowanie 'J' jako 'I'
            StringBuilder wynik = new StringBuilder();

            for (int i = 0; i < tekst.Length; i++)
            {
                if (char.IsLetter(tekst[i]))
                {
                    wynik.Append(tekst[i]);
                    // Dodajemy 'X' pomiędzy powtórzonymi literami
                    if (i + 1 < tekst.Length && tekst[i] == tekst[i + 1])
                    {
                        wynik.Append('X');
                    }
                }
            }

            // Jeśli liczba znaków jest nieparzysta, dodajemy 'X' na końcu
            if (wynik.Length % 2 != 0)
            {
                wynik.Append('X');
            }

            return wynik.ToString();
        }

        public string Koduj(string input)
        {
            input = PrzygotujTekst(input);
            char[] zaszyfrowanyTekst = new char[input.Length];

            for (int i = 0; i < input.Length; i += 2)
            {
                char a = input[i];
                char b = input[i + 1];
                var (rowA, colA) = ZnajdzPozycje(a);
                var (rowB, colB) = ZnajdzPozycje(b);

                if (rowA == rowB)
                {
                    // Jeśli litery są w tym samym wierszu, przesuwamy je w prawo
                    zaszyfrowanyTekst[i] = tablicaPolibiusza[rowA, (colA + 1) % 5];
                    zaszyfrowanyTekst[i + 1] = tablicaPolibiusza[rowB, (colB + 1) % 5];
                }
                else if (colA == colB)
                {
                    // Jeśli litery są w tej samej kolumnie, przesuwamy je w dół
                    zaszyfrowanyTekst[i] = tablicaPolibiusza[(rowA + 1) % 5, colA];
                    zaszyfrowanyTekst[i + 1] = tablicaPolibiusza[(rowB + 1) % 5, colB];
                }
                else
                {
                    // Jeśli litery są w różnych wierszach i kolumnach, zamieniamy je na przeciwnych rogach prostokąta
                    zaszyfrowanyTekst[i] = tablicaPolibiusza[rowA, colB];
                    zaszyfrowanyTekst[i + 1] = tablicaPolibiusza[rowB, colA];
                }
            }

            return new string(zaszyfrowanyTekst);
        }

        public string Dekoduj(string input)
        {
            char[] odszyfrowanyTekst = new char[input.Length];

            for (int i = 0; i < input.Length; i += 2)
            {
                char a = input[i];
                char b = input[i + 1];
                var (rowA, colA) = ZnajdzPozycje(a);
                var (rowB, colB) = ZnajdzPozycje(b);

                if (rowA == rowB)
                {
                    // Jeśli litery są w tym samym wierszu, przesuwamy je w lewo
                    odszyfrowanyTekst[i] = tablicaPolibiusza[rowA, (colA + 4) % 5];
                    odszyfrowanyTekst[i + 1] = tablicaPolibiusza[rowB, (colB + 4) % 5];
                }
                else if (colA == colB)
                {
                    // Jeśli litery są w tej samej kolumnie, przesuwamy je w górę
                    odszyfrowanyTekst[i] = tablicaPolibiusza[(rowA + 4) % 5, colA];
                    odszyfrowanyTekst[i + 1] = tablicaPolibiusza[(rowB + 4) % 5, colB];
                }
                else
                {
                    // Jeśli litery są w różnych wierszach i kolumnach, zamieniamy je na przeciwnych rogach prostokąta
                    odszyfrowanyTekst[i] = tablicaPolibiusza[rowA, colB];
                    odszyfrowanyTekst[i + 1] = tablicaPolibiusza[rowB, colA];
                }
            }

            return new string(odszyfrowanyTekst);
        }
    }
}
