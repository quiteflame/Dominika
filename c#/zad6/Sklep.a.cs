using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_a
{
    class Program
    {
        static void Kolejka(int n, int d)
        {
          Queue<int> kolejka = new Queue<int>();

          for (int tura = 0; tura <= d; tura++) {
            Console.WriteLine("Tura " + tura + ":");
            if (tura == 0) {
              //dodawanie elementów do kolejki
              for (int i = 0; i < n; i++) {
                kolejka.Enqueue(i);
                Console.WriteLine("Klient " + i + " trafia do kolejki 0");
              }
              continue;
            }

            //usuwanie elementów z kolejki
            if (kolejka.Count == 0) {
              Console.WriteLine("Kolejka 0 jest pusta.");
              continue;
            }

            int i = (int)kolejka.Dequeue();
            Console.WriteLine("Klient " + i + " opuszcza kolejkę 0");
          }
        }

        static void Main()
        {
            Console.WriteLine("Licza otwartych kas: 1");
            Console.WriteLine("Ile osób wpuścić do kolejki?");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Ile tur zasymulować?");
            int d = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            Kolejka(n, d);
            Console.ReadLine();
        }
    }
}
