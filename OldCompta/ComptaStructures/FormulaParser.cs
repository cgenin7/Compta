using System;
using System.Globalization;

namespace ComptaCommun
{
    public static class FormulaParser
    {
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

                double resultat = ConvertToDouble(monEquation[0]);
                int operatorIndex = monEquation[0].Length;

                for (int i = 0; i < monEquation.Length - 1; i++)
                {
                    resultat = CalculerOperateur(resultat, ConvertToDouble(monEquation[i + 1]), formula[operatorIndex]);
                    operatorIndex += monEquation[i + 1].Length + 1;
                }
                return resultat;
            }
            catch
            {
                return 0;
            }
        }

        public static double ConvertToDouble(String sValue)
        {
            double result;

            if (NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator == ".")
                sValue = sValue.Replace(",", ".");
            else
                sValue = sValue.Replace(".", ",");

            if (double.TryParse(sValue, out result))
                return result;

            return 0;
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
