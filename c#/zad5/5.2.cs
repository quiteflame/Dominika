using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {

        static void Reverse(string znaki)
        {
            Stack<char> stos = new Stack<char>();

            for (int i = 0; i < znaki.Length; i++)
            {
                if (znaki[i] != ' ')
                    stos.Push(znaki[i]);

                else
                {
                    foreach (char znak in stos)
                        Console.Write("{0}", znak);

                    Console.Write(" ");

                    while (stos.Count != 0)
                        stos.Pop();
                }
            }
            foreach (char znak in stos)
                Console.Write("{0}", znak);

            while (stos.Count != 0)
                stos.Pop();
        }

        static void Main()
        {

            Console.WriteLine("Podaj tekst do odwrócenia.");
            string s = Console.ReadLine();
            Reverse(s);

            Console.ReadLine();

        }
    }
}
