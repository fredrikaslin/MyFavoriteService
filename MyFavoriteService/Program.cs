using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteService
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunDelegateTest1();
            //RunExpression();
            //DelegateTest2v2();
            DelegateTest2v1();
        }

        //expressions
        #region
        private static void RunExpression()
        {
            Expression<Func<string, string, string>> StringJoinExpr = (str1, str2) => string.Concat(str1, str2);

            var result = StringJoinExpr.Compile()("Smith", "Jones");
            Console.WriteLine(result);
            Console.ReadKey();
        }


        #endregion


        //delegates
        #region 
        public static void RunDelegateTest1()
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

        /*--------------------------------------------------------------------------------------------------*/

        delegate int anonymousDel(int i, int j);
        public static void DelegateTest2v1()
        {
            anonymousDel getBigInteger = (x, y) => { if (x > y) return x; else return y; };
            Console.WriteLine(getBigInteger(10, 15));
            Console.ReadKey();
        }

        public static void DelegateTest2v2()
        {
            Func<int, int, int> getBigInteger = (x, y) => { if (x > y) return x; else return y; };
            Console.WriteLine(getBigInteger(10, 15));
            Console.ReadKey();
        }


        delegate void doSomething();
        public static void DelegateTest3()
        {
            doSomething IamVoid = () => { Console.WriteLine("Hello there! I take nothing and return nothing"); };
            IamVoid();
            Console.ReadKey();
        }

        #endregion  

    }
}
