using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {

        static bool isPair(char character1, char character2) {
            if (character1 == '(' && character2 == ')')
                return true;
            else if (character1 == '{' && character2 == '}')
                return true;
            else if (character1 == '[' && character2 == ']')
                return true;
            else
                return false;
        }
     
        static bool areParenthesisBalanced(string exp) {
            Stack<char> st = new Stack<char>();
      
            foreach(var ch in exp) {
                if (ch == '{' || ch == '(' || ch == '[') {
                    st.Push(ch);
                }
          
                if (ch == '}' || ch == ')' || ch == ']') {
                    if (st.Count == 0) {
                       return false;
                    } else if (!isPair(st.Pop(), ch)) {
                       return false;
                    }
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
            Console.WriteLine("Podaj ciąg nawiasów do sprawdzenia.");
            string s = Console.ReadLine();
            bool result = areParenthesisBalanced(s); 
            Console.Write("{0}", result);

            Console.ReadLine();
        }
    }
}
