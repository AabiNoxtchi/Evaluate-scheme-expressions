using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateExpression2.Operations
{
    class MultiplyOperation : IOperation
    {

        public decimal DoOperation(List<string> values)
        {
           

            decimal value1 = 0;
            decimal value2 = 0;

            try
            {
                value1 = Convert.ToDecimal(values[1]);
                value2 = Convert.ToDecimal(values[2]);


            }
            catch { }

            return value1 * value2;
        }
    }
}
