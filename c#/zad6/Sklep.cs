using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_a
{
    class Program
    {
        static void Kolejka(int n, int k)
        {
            Queue<int> kolejka = new Queue<int>();

            if (k == 1)
            {
                //dodawanie elementów do kolejki
                for (int i = 0; i <= n; i++)
                {
                    kolejka.Enqueue(i);
                    Console.WriteLine("Do kolejki dodano " + i);
                }

                Console.WriteLine("\n");

                //usuwanie elementów z kolejki
                while (kolejka.Count != 0)
                {
                    int i = (int)kolejka.Dequeue();
                    Console.WriteLine("Kolejkę opuścił " + i);

                    //sprawdzanie czy kolejka jest pusta
                    if (kolejka.Count != 0)
                        Console.WriteLine("Kolejka nie jest pusta.");
                    else
                        Console.WriteLine("Kolejka jest pusta.");
                }
            }
            else
                Console.WriteLine("Nie mamy aż tylu kas.");
            Console.ReadLine();
        }

        static void Main()
        {
            Console.WriteLine("Ile ma być otwartych kas?");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Ile osób wpuścić do kolejki?");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            Kolejka(n, k);
        }
    }
}
