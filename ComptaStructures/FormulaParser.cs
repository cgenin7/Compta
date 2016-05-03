using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ComptaCommun
{
    public class FormulaParser
    {
        private FormulaParser()
        {
        }

        public static double Calculate(string formula)
        {
            if (formula.Length > 0 && (formula[0] == '+' || formula[0] == '-'))
            {
                formula = "0" + formula;
            }
            try
            {
                char[] separators = { '/', '*', '+', '-' };

                string[] monEquation = formula.Split(separators);

                double resultat = Convert.ToDouble(monEquation[0]);
                int operatorIndex = monEquation[0].Length;

                for (int i = 0; i < monEquation.Length - 1; i++)
                {
                    resultat = CalculerOperateur(resultat, Convert.ToDouble(monEquation[i + 1]), formula[operatorIndex]);
                    operatorIndex += monEquation[i + 1].Length + 1;
                }
                return resultat;
            }
            catch
            {
                return 0;
            }
        }

        private static double CalculerOperateur(double nombre1, double nombre2, char op)
        {
            if (op == '-')
            {
                return nombre1 - nombre2;
            }
            else if (op == '+')
            {
                return nombre1 + nombre2;
            }
            else if (op == '*')
            {
                return nombre1 * nombre2;
            }
            else if (op == '/')
            {
                return nombre1 / nombre2;
            }
            return 0;
        }
    }
}
