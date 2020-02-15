using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateExpression2
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();

                bool valid = true;
                Console.WriteLine("Expression format : (* (+ 7 (- 20 x)) 3)");
                Console.WriteLine("enter expression");
                string s = Console.ReadLine();
                Expression expression = new Expression(s,ref valid);


                if (valid == true)
                {

                    while (true)
                    {
                        Console.Write("X = ");
                        decimal x = 0;
                        try
                        {
                            x = Convert.ToDecimal(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid value for x !");                            
                            continue;
                        }

                        Console.WriteLine(expression.Calculate(x));


                        Console.WriteLine("Press esc for new expression , or any key to continue with this expression .");
                         if (Console.ReadKey(true).Key == ConsoleKey.Escape) { break; }
                         else { continue; }


                    }
                }
            }
        }
    }
}
