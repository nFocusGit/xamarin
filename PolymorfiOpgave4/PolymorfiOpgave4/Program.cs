using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorfiOpgave4
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression exprPlus = new PlusExpression(
                left: new ConstantExpression(4),
                right: new PlusExpression(
                    left: new ConstantExpression(1),
                    right: new ConstantExpression(2)));

            Console.Write(exprPlus.ToString());
            Console.Write(" = ");
            Console.Write(exprPlus.Evaluate());
            Console.WriteLine();

            Expression exprMinus = new PlusExpression(
                left: new ConstantExpression(4),
                right: new MinusExpression(
                    left: new ConstantExpression(1),
                    right: new ConstantExpression(2)));

            Console.Write(exprMinus.ToString());
            Console.Write(" = ");
            Console.Write(exprMinus.Evaluate());
            Console.WriteLine();

            Console.ReadKey();
            /////////////////////////////////////////


            // Swap of two integers.
            //int a = 40, b = 60;
            //Console.WriteLine("Before swap: {0}, {1}", a, b);
            //Swap<int>(ref a, ref b);
            //Console.WriteLine("After swap: {0}, {1}", a, b);
            //Console.ReadKey();

            /////////////////////////////////////////
            List<int> numberList = new List<int>();
            Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            for (int i = 0; i < 10; i++)
            {
                int randomNumber = random.Next(0, 100);
                numberList.Add(randomNumber);
            }
            foreach (var item in numberList)
            {
                Console.WriteLine(item);
            }
            numberList.Sort();
            Console.WriteLine("Press to set order");
            Console.ReadKey();
            foreach (var item in numberList)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }


        //Generic method
        ////http://www.c-sharpcorner.com/UploadFile/84c85b/using-generics-with-C-Sharp/
        //static void Swap<T>(ref T a, ref T b)
        //{
        //    T temp;
        //    temp = a;
        //    a = b;
        //    b = temp;
        //}
        //static void MyReverse<T>(List<T> list)
        //{
        //    var newList = new List<T>();
        //    foreach (var item in list)
        //    {
        //        newList.Add(item);
        //    }
        //}
    }
}
