using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseBookCH2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Indivisibility";
            if (string.IsNullOrEmpty(str))
                Console.WriteLine("DSF");
            Dictionary<char, int> d = new Dictionary<char, int>();
            str = str.ToUpper();
            for (int i = 0; i < str.Length; i++)
            {
                try { d.Add(str[i], 1); }
                catch { d[str[i]]++; }
            }
            List<int> list = new List<int>(d.Values);
            int temp = 0;
            foreach (int i in list)
                temp = (i >= 2) ? temp += 1 : temp;
            Console.WriteLine(temp);

            var t = str.GroupBy(c => c).Where(a => a.Count() > 2);
            foreach (var v in t)
            {
                Console.WriteLine(v.Key);
            }
            Console.WriteLine();

            string num = "10011010010";
            Console.WriteLine(num.Count(c => c == '1'));


        }
    }
}
