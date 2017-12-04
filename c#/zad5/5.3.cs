using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {

        static int execute(int a, int b, char op) {
            switch (op) {
                case '-':
                    return b - a;
                case '+':
                    return b + a;
                case '*':
                    return b * a;
                case '/':
                    return b / a;
                case '%':
                    return b % a;
                case '^':
                    return (int)Math.Pow(b, a);
                default:
                    throw new Exception("Unsupported operator: " + op);

            }
        }

        static int ONP_Result(object[] onp)
        {
            Stack<int> sztos = new Stack<int>();

            foreach (var ch in onp) {
                if (ch is int) {
                    sztos.Push((int)ch);
                } else {
                    int a = sztos.Pop();
                    int b = sztos.Pop();
                    sztos.Push(execute(a, b, (char)ch));
                }
            }

            return sztos.Pop();
        }

        static void Main()
        {
            object[] onp = new object[]{12, 2, 3, 4, '*', 10, 5, '/', '+', '*', '+'};
            Console.Write("{0}\n", ONP_Result(onp));
            Console.ReadLine();

        }
    }
}
