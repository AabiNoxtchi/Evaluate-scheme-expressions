using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateExpression2.Operations
{
    public interface IOperation
    {
         decimal DoOperation(List<string> values);
    }
}
