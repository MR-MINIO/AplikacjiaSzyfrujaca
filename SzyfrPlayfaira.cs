using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjiaSzyfrowanie
{
    internal class SzyfrPlayfaira
    {

        private char[,] kluczMatryca;
        private const int RozmiarMatrycy = 5;

        public SzyfrPlayfaira(string klucz)
        {
            kluczMatryca = GenerujMatryceKlucza(klucz);
        }

        private char[,] GenerujMatryceKlucza(string klucz)
        {
            klucz = klucz.ToUpper().Replace("J", "I");
            HashSet<char> wykorzystaneZnaki = new HashSet<char>();
            char[,] matryca = new char[RozmiarMatrycy, RozmiarMatrycy];
            int index = 0;

            foreach (char c in klucz)
            {
                if (char.IsLetter(c) && !wykorzystaneZnaki.Contains(c))
                {
                    wykorzystaneZnaki.Add(c);
                    matryca[index / RozmiarMatrycy, index % RozmiarMatrycy] = c;
                    index++;
                }
            }

            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (c != 'J' && !wykorzystaneZnaki.Contains(c))
                {
                    wykorzystaneZnaki.Add(c);
                    matryca[index / RozmiarMatrycy, index % RozmiarMatrycy] = c;
                    index++;
                }
            }

            return matryca;
        }

        private (int, int) ZnajdzPozycje(char znak)
        {
            for (int i = 0; i < RozmiarMatrycy; i++)
            {
                for (int j = 0; j < RozmiarMatrycy; j++)
                {
                    if (kluczMatryca[i, j] == znak)
                        return (i, j);
                }
            }
            throw new Exception("Znak nie znaleziony w matrycy.");
        }

        private string PrzygotujTekst(string tekst)
        {
            tekst = tekst.ToUpper().Replace("J", "I");
            List<char> wynik = new List<char>();

            for (int i = 0; i < tekst.Length; i++)
            {
                if (char.IsLetter(tekst[i]))
                {
                    wynik.Add(tekst[i]);
                    if (i + 1 < tekst.Length && tekst[i] == tekst[i + 1])
                    {
                        wynik.Add('X');
                    }
                }
            }

            if (wynik.Count % 2 != 0)
                wynik.Add('X');

            return new string(wynik.ToArray());
        }

        public string Koduj(string input)
        {
            input = PrzygotujTekst(input);
            char[] zaszyfrowany = new char[input.Length];

            for (int i = 0; i < input.Length; i += 2)
            {
                char a = input[i];
                char b = input[i + 1];
                var (rowA, colA) = ZnajdzPozycje(a);
                var (rowB, colB) = ZnajdzPozycje(b);

                if (rowA == rowB)
                {
                    zaszyfrowany[i] = kluczMatryca[rowA, (colA + 1) % RozmiarMatrycy];
                    zaszyfrowany[i + 1] = kluczMatryca[rowB, (colB + 1) % RozmiarMatrycy];
                }
                else if (colA == colB)
                {
                    zaszyfrowany[i] = kluczMatryca[(rowA + 1) % RozmiarMatrycy, colA];
                    zaszyfrowany[i + 1] = kluczMatryca[(rowB + 1) % RozmiarMatrycy, colB];
                }
                else
                {
                    zaszyfrowany[i] = kluczMatryca[rowA, colB];
                    zaszyfrowany[i + 1] = kluczMatryca[rowB, colA];
                }
            }

            return new string(zaszyfrowany);
        }

        public string Dekoduj(string input)
        {
            char[] odszyfrowany = new char[input.Length];

            for (int i = 0; i < input.Length; i += 2)
            {
                char a = input[i];
                char b = input[i + 1];
                var (rowA, colA) = ZnajdzPozycje(a);
                var (rowB, colB) = ZnajdzPozycje(b);

                if (rowA == rowB)
                {
                    odszyfrowany[i] = kluczMatryca[rowA, (colA + RozmiarMatrycy - 1) % RozmiarMatrycy];
                    odszyfrowany[i + 1] = kluczMatryca[rowB, (colB + RozmiarMatrycy - 1) % RozmiarMatrycy];
                }
                else if (colA == colB)
                {
                    odszyfrowany[i] = kluczMatryca[(rowA + RozmiarMatrycy - 1) % RozmiarMatrycy, colA];
                    odszyfrowany[i + 1] = kluczMatryca[(rowB + RozmiarMatrycy - 1) % RozmiarMatrycy, colB];
                }
                else
                {
                    odszyfrowany[i] = kluczMatryca[rowA, colB];
                    odszyfrowany[i + 1] = kluczMatryca[rowB, colA];
                }
            }

            return new string(odszyfrowany);
        }


    }
}
