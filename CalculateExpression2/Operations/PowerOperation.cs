using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateExpression2.Operations
{
    class PowerOperation : IOperation
    {
        public decimal DoOperation(List<string> values)
        {
            double value1 = 0;
            double value2 = 0;

            try
            {
                value1 = Convert.ToDouble(values[1]);
                value2 = Convert.ToDouble(values[2]);


            }
            catch { }

            return (decimal)Math.Pow(value1, value2);
        }
    }
}
