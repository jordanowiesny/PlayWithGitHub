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
            if (n[choice[0]] == n[choice[1]] && l[choice[0]] == "*" && l[choice[1]] == "*")
            {
                l[choice[0]] = n[choice[0]].ToString();
                l[choice[1]] = n[choice[1]].ToString();
                Print(n, l);
                return 1;
            }
            return 0;
        }

        static int choice(List<int> n, List<string> l)
        {
            int[] choice = new int[] { 0, 0 };
            int num = 0;
            string foo;

            for (int i = 0; i < 2; i++)
            {
                Console.Write("Choice " + i + ": ");
                foo = Console.ReadLine();
                num = (int)foo[0];
                num = (((num - 97) *4) + int.Parse(foo[1].ToString()) - 1);
                choice[i] = num;
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
            Console.WriteLine("IM IN MASTER");
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
                Console.WriteLine("COUTN = " + count);
            }
        }
    }
}