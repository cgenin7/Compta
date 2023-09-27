using Comptability;
using ComptaCommun;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Compta
{
    public class Utils
    {
        public static void FillComboBudgetName(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            string[] budgets = Directory.GetFiles(Environment.CurrentDirectory + "\\Data", "*.mdb");
            if (budgets != null)
            {
                foreach (string budget in budgets)
                {
                    int index = budget.LastIndexOf("\\");
                    if (index > 0)
                    {
                        string budgetFileName = budget.Substring(index + 1);
                        int budgetYear;
                        if (budget.Length >= 4 && int.TryParse(budgetFileName.Substring(0, 4), out budgetYear))
                        {
                            string budgetName = budgetFileName.Replace(".mdb", "");
                            if (!budgetName.Contains("Backup"))
                                comboBox.Items.Add(budgetName.Trim());
                        }
                        
                    }
                }
            }
            comboBox.Text = LocalSettings.DatabaseName.Trim();
        }

        public static void FillComboCategories(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            List<TCategoryInfo> infos = ClassTransactions.GetTransactions().Categories;
            if (infos != null)
                foreach (TCategoryInfo info in infos)
                    comboBox.Items.Add(info.Name);
        }

        public static void SetResultFromFormula(TextBox textBoxWithFormula)
        {
            textBoxWithFormula.Tag = textBoxWithFormula.Text.Trim();
            textBoxWithFormula.Text = ClassTools.ConvertDoubleToString(FormulaParser.Calculate(textBoxWithFormula.Text.Trim()));
        }

        public static void SetBackFormula(TextBox textBoxWithFormula)
        {
            if (textBoxWithFormula.Tag != null)
            {
                textBoxWithFormula.Text = textBoxWithFormula.Tag.ToString();
            }
        }

        public static int GetDayFromComboText(string comboText)
        {
            comboText = comboText.Trim();
            if (string.Compare(comboText, "1er", true) == 0)
                return 1;
            if (string.Compare(comboText, "dernier jour", true) == 0)
                return Util.LAST_DAY_OF_MONTH;
            int day = 1;
            if (!int.TryParse(comboText, out day))
            {
                MessageBox.Show("Le jour entré n'est pas valide.");
                day = 1;
            }

            return day;
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
            
            MessageBox.Show("La valeur entrée n'est pas valide.");
            return 0;
        }

        public static int ConvertToInt(String sValue)
        {
            int result;
            if (int.TryParse(sValue, out result))
                return result;
            MessageBox.Show("La valeur entrée n'est pas valide.");
            return 0;
        }

        public const string ACCELERATED_PAIEMENTS = "sem. en accéléré";
    }
}
