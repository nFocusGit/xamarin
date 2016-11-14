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



            Console.ReadKey();
        }
    }
}
