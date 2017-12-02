using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {

        static string Reverse(string znaki)
        {
            Stack<char> sztos = new Stack<char>();

            for (int i = 0; i < znaki.Length; i++)
                sztos.Push(znaki[i]);

            string wynik = "";

            while (sztos.Count != 0)
                wynik = wynik + sztos.Pop();

            return wynik;
        }

        static void Main()
        {

            Console.WriteLine("Podaj tekst do odwrócenia.");
            string s = Console.ReadLine();
            Console.Write("{0}", Reverse(s));

            Console.ReadLine();

        }
    }
}
