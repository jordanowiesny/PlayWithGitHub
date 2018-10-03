using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEstApp
{
    class Program
    {
        static void Print(List<int> n, List<string> l)
        {
            int num = 0;
            Console.WriteLine("  1 2 3 4");
            var arr = new char[4] { 'a', 'b', 'c', 'd' };
            int s = 0;
            while (num < 16)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (num == 0 || num % 4 == 0)
                    {
                        Console.Write(arr[s] + " ");
                        s++;
                    }
                    Console.Write(n[num] + " ");
                    num++;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            num = 0;
            Console.WriteLine("  1 2 3 4");
            s = 0;
            while (num < 16)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (num == 0 || num % 4 == 0)
                    {
                        Console.Write(arr[s] + " ");
                        s++;
                    }
                    Console.Write(l[num] + " ");
                    num++;
                }
                Console.WriteLine();
            }
        }

        static int MATCH(int[] choice, List<string> l, List<int> n)
        {
            int temp = 0;
            temp = (l[choice[0]] == "*") ? temp=1 : temp;
            l[choice[0]] = n[choice[0]].ToString();
            l[choice[1]] = n[choice[1]].ToString();
            Print(n, l);
            return temp;
        }

        static int choice(List<int> n, List<string> l)
        {
            int[] choice = new int[] { 0, 0 };
            List<char> c1 = new List<char>();

            for (int i = 0; i < 2; i++)
            {
                Console.Write("Choice " + i + ": ");
                var foo = Console.ReadLine();

                c1.Add(' ');
                c1.Add(' ');
                c1[0] = foo[0];
                c1[1] = foo[1];

                int i1 = 0;
                if (c1[0] == 'b')
                    i1 = 4;
                else if (c1[0] == 'c')
                    i1 = 8;
                else if (c1[0] == 'd')
                    i1 = 12;
                i1 += int.Parse(c1[1].ToString()) - 1;
                choice[i] = i1;
            }

            if (n[choice[0]] == n[choice[1]])
            {
                Console.WriteLine("SICK");
                return MATCH(choice, l, n);
            }
            else
                return 0;
        }

        static void Main(string[] args)
        {
            List<int> n = new List<int>();
            List<string> l = new List<string>();
            for (int i = 1; i < 9; i++)
            {
                n.Add(i);
                n.Add(i);
                l.Add("*");
                l.Add("*");
            }
            Random r = new Random();

            for (int i = n.Count - 1; i > 0; i--)
            {
                int j = r.Next(0, i);
                int temp = n[i];
                n[i] = n[j];
                n[j] = temp;
            }

            int count = 8;
            Print(n, l);
            while (count > 0)
            {
                count -= choice(n, l);
                Console.WriteLine("COUNT + " + count);
            }
            Console.WriteLine("Exiting...");
        }
    }
}