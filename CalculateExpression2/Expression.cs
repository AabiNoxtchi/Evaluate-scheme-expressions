using CalculateExpression2.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateExpression2
{
    class Expression
    {
        private readonly string _expression="";
        private Dictionary<string, IOperation> operationDictionary = new Dictionary<string, IOperation>()
                                            {
                                                {"+", new AddOperation()} ,
                                                {"-", new MinusOperation()},
                                                {"*",new MultiplyOperation()},
                                                {"/",new DivisionOperation()},
                                                {"^",new PowerOperation()},
                                                {"sqrt", new SquareOperation() }
                                            };

        public Expression(string expression, ref bool valid)
        {
            if (IsBalancedBrackets(expression))
            {
                this._expression = expression;
            }

            else
            {

                Console.WriteLine("Invalid format expression");
                valid = false;
            }
        }

        public decimal Calculate (decimal x)
        {
            decimal total = 0;

            string s = _expression.Replace("x",x.ToString());


            while (s.IndexOf(")") != -1) {

                string inner_s = FindInnerExpression(s);

                List<string> values = FindValues(inner_s);


                // if(values!=null) sent Inner expression for evaluation

                if (values != null && (values.Count==2||values.Count==3))
                {
                    total = EvaluateInnerExpression(values);
                } else {
                    Console.WriteLine("Invalid expression format !!!");
                    return 0;
                }


                //replace Inner expression with its value
                s = s.Replace(inner_s, total.ToString());


            }

            return total;
        }

        private bool IsBalancedBrackets(string expression)
        {
            char openBracket = '(';
            char closeBracket = ')';
            int countOpenBrackets = 0, countCloseBrackets = 0;

            for(int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == openBracket) { countOpenBrackets++; }
                else if (expression[i] == closeBracket) { countCloseBrackets++; }
            }

            if (countOpenBrackets == countCloseBrackets) return true;
            else return false;
        }

        private string FindInnerExpression(string s)
        {

            int firstCloseBracket = s.IndexOf(")");
            int openBracket = s.LastIndexOf("(", firstCloseBracket);
            int length = firstCloseBracket +1 - openBracket;
            return s.Substring(openBracket, length);

        }

        private List<string> FindValues(string s)
        {
            char[] charsToTrim = { '(', ')'};           
            string result = s.Trim(charsToTrim);
           // result = result.Trim();

            List<string> values = new List<string>();
           
            SchemeList(values,result);              
                  
            return values;
        }

        private void SchemeList(List<string> values,string result)
        {           

            string[] splittedS = result.Split(' ');

            if ((splittedS.Length == 2 || splittedS.Length == 3) )
            {

                values.Add(splittedS[0]);
                values.Add(splittedS[1]);
                if (splittedS.Length == 3)
                {
                    values.Add(splittedS[2]);

                }
            }     
        }

        private decimal EvaluateInnerExpression(List<string> values)
        {

            decimal total = 0;

            if (operationDictionary.ContainsKey(values[0].ToLower()))
            {
                IOperation operation = operationDictionary[values[0]];
                total = operation.DoOperation(values);
            }

            return total;


        }
    }
}
