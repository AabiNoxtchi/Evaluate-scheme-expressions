using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateExpression2.Operations
{
    class SquareOperation : IOperation
    {
        public decimal DoOperation(List<string> values)
        {
            double value1 = 0;
            decimal total = 0;
            try
            {
                value1 = Convert.ToDouble(values[1]);               
                total= (decimal)Math.Sqrt(value1);

            }
            catch { }

            return total;
        }
    }
}
