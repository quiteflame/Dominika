using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {     
        static bool areTagsPairsMatching(string exp) {
            Stack<string> st = new Stack<string>();
            string tag = null;
            bool openingTag = true;

            foreach(var ch in exp) {
                
                if (ch == '<') {
                    if (tag != null) {
                        Console.WriteLine("błąd parsowania, program natrafił na nawias otwierający przed zamknięciem poprzedniego");
                        return false;
                    }
                    tag = "";
                    openingTag = true;
                }

                if (tag != null && ch != '<' && ch != '>' && ch != '/') {
                    tag += ch;
                }

                if (ch == '/') {
                    openingTag = false;
                }

                if (ch == '>' && openingTag) {
                    if (tag == null) {
                        Console.WriteLine("błąd parsowania, program natrafił na nawias zamykający przed otwarciem poprzedniego");
                        return false;
                    }

                    Console.WriteLine("Pushing tag: " + tag);
                    st.Push(tag);
                    tag = null;
                } else if (ch == '>') {
                    string lastTag = st.Pop();
                    Console.WriteLine("Poping tag: " + lastTag + " i porównanie z zamykającym: " + tag);
                    if (tag != lastTag) {
                        return false;
                    }
                    tag = null;
                }
            }
         
            if (st.Count == 0) {
                return true;
            } else {
                return false;
            } 
        } 

        static void Main()
        {
            Console.WriteLine("Podaj XML/HTML:");
            string s = Console.ReadLine();
            bool result = areTagsPairsMatching(s); 
            Console.Write("{0}", result);

            Console.ReadLine();
        }
    }
}
