using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_a
{
    class Klient {
      public int id;
      public Queue<int> zakupy = new Queue<int>();

      public Klient(int idx, int m) {
        id = idx;
        for (int i = 0; i < m; i++ ) {
          zakupy.Enqueue(i);
        }
      }
    }

    class Program
    {
        static void Kolejka(int n, int k, int m, int d)
        {
            Queue<Klient>[] kolejki = new Queue<Klient>[k];

            for (int tura = 0; tura <= d; tura++) {
              Console.WriteLine("Tura " + tura + ":");
              if (tura == 0) {
                // tworzenie k kolejek i dodawanie ich do listy
                for (int i = 0; i < k; i++) {
                  kolejki[i] = new Queue<Klient>();
                }

                // dodawanie osób do kolejek
                for (int i = 0; i < n; i++) {
                  int indexKolejki = (int)(Math.Pow(i, 2)) % k;
                  Queue<Klient> kolejka = kolejki[indexKolejki];
                  Klient klient = new Klient(i, m);
                  kolejka.Enqueue(klient);
                  Console.WriteLine("Klient " + klient.id + " trafia do kolejki: " + indexKolejki);
                }
                continue;
              }

              for (int i = 0; i < kolejki.Length; i++) {
                Queue<Klient> kolejka = kolejki[i];
                if (kolejka.Count == 0) {
                  Console.WriteLine("Kolejka " + i + " jest pusta");
                  continue;
                }

                Klient klient = kolejka.Peek();
                if (klient.zakupy.Count != 0) {
                  int produkt = klient.zakupy.Dequeue();
                  Console.WriteLine("Produkt " + produkt + " opuszcza klienta " + klient.id);
                }

                if (klient.zakupy.Count == 0) {
                  kolejka.Dequeue();
                  Console.WriteLine("Klient " + klient.id + " opuszcza kolejkę " + i);
                }
              }
            }
        }

        static void Main()
        {
            Console.WriteLine("Ile ma być otwartych kas?");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Ile osób wpuścić do kolejki?");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Ile produktów na klienta?");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Ile tur zasymulować?");
            int d = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            Kolejka(n, k, m, d);
            Console.ReadLine();
        }
    }
}
