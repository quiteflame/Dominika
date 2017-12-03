using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_b
{
    class Program
    {
        static void Kolejka(int n, int k, int d)
        {
          Queue<int>[] kolejki = new Queue<int>[k];

          for (int tura = 0; tura <= d; tura++) {
            Console.WriteLine("Tura " + tura + ":");
            if (tura == 0) {
              // tworzenie k kolejek i dodawanie ich do listy
              for (int i = 0; i < k; i++) {
                kolejki[i] = new Queue<int>();
              }

              // dodawanie osób do kolejek
              for (int i = 0; i < n; i++) {
                int indexKolejki = (int)(Math.Pow(i, 2)) % k;
                Queue<int> kolejka = kolejki[indexKolejki];
                kolejka.Enqueue(i);
                Console.WriteLine("Klient " + i + " trafia do kolejki: " + indexKolejki);
              }
              continue;
            }

            for (int i = 0; i < kolejki.Length; i++) {
              Queue<int> kolejka = kolejki[i];
              if (kolejka.Count == 0) {
                Console.WriteLine("Kolejka " + i + " jest pusta");
                continue;
              }

              int klient = kolejka.Dequeue();
              Console.WriteLine("Klient " + klient + " opuszcza kolejkę " + i);
            }
          }
        }

        static void Main()
        {
            Console.WriteLine("Ile ma być otwartych kas?");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Ile osób wpuścić do kolejki?");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Ile tur zasymulować?");
            int d = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            Kolejka(n, k, d);
            Console.ReadLine();
        }
    }
}
