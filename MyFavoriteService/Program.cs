using System;
using System.Collections.Generic;
using System.Globalization;
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
            //DelegateTest2v1();
            ToUniversalTimeWithoutAMPM();
        }

        //TimeZoneTesing
        public static void ToUniversalTimeWithoutAMPM()
        {
            var timeoff = new DateTimeOffset();
            TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");


            Console.WriteLine(timeoff);
            Console.WriteLine(cst);
            Console.ReadKey();



            //DateTime? date = DateTime.Now;
            //var utc = date.Value.ToUniversalTime();
            //var fromDate = utc.ToString("yyyy-MM-d HH:mm:ss") + "z";


            //string dateString, format;
            //DateTime result;
            //CultureInfo provider = CultureInfo.InvariantCulture;

            //// Parse date-only value with invariant culture.
            //dateString = "12/3/2018 9:05:21PM";
            //format = "d";
            //try
            //{
            //    result = DateTime.ParseExact(dateString, format, provider);
            //    Console.WriteLine("{0} converts to {1}.", dateString, result.ToString());
            //    Console.ReadKey();
            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("{0} is not in the correct format.", dateString);
            //    Console.ReadKey();

            //}

            //DateTime date1 = new DateTime(2010, 3, 14, 2, 30, 0, DateTimeKind.Local);
            //Console.WriteLine("Invalid time: {0}",
            //                  TimeZoneInfo.Local.IsInvalidTime(date1));
            //Console.ReadKey();
            //DateTime utcDate1 = date1.ToUniversalTime();
            //DateTime date2 = utcDate1.ToLocalTime();
            //Console.WriteLine("{0} --> {1}", date1, date2);
            //Console.ReadKey();


            //string DateFormat = "yyyyMMdHHmmss";
            //CultureInfo provider = CultureInfo.InvariantCulture;

            //var d = DateTime.ParseExact("11/12/2008 04:20:00pm", DateFormat, provider);

            //Console.WriteLine("DateTime.Parse('16:20')" + d);
            //Console.ReadKey();



            //var date = d.ToUniversalTime() + "z";

            //Console.WriteLine("UTC" + date);
            //Console.ReadKey();

            //string fromDate = d.ToString(DateFormat);

            //Console.WriteLine("DateFormat" + fromDate);
            //Console.ReadKey();
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
