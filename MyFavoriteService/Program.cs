using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteService
{
    class Program
    {
        static void Main(string[] args)
        {
            RunDelegateTest();

        }

        public static void RunDelegateTest()
        {
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);

            nc1(25);
            Console.WriteLine($"'num' är nu: {GetNum()}");

            nc2(5);
            Console.WriteLine($"'num' är nu: {GetNum()}");
            Console.ReadKey();
        }

        delegate int NumberChanger(int n);
        static int num = 10;

        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }

        public static int GetNum()
        {
            return num;
        }


    }
}
