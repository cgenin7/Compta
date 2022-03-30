using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Drawing;
using ComptaCommun;
using Comptability;

namespace Compta
{
    public class ComptaCharts
    {
        public ComptaCharts(FormMain mainForm)
        {
            m_mainForm = mainForm;
        }

        public static TAnnualRepartitionInfo InitializeChartAnnuals(Chart chartAnnuals, int year, int accountId, bool zoomedVersion)
        {
            try
            {
                TAnnualRepartitionInfo info = ClassTransactions.GetTransactions().CalculateAnnualTransactions(LocalSettings.BudgetYear, accountId);

                chartAnnuals.Visible = true;
                chartAnnuals.ChartAreas.Clear();
                chartAnnuals.Legends.Clear();
                chartAnnuals.Series.Clear();

                chartAnnuals.Series.Add(new Series());

                int serieNb = 0;
                CreateChartArea(chartAnnuals, 0, "Area1", zoomedVersion);
                chartAnnuals.Series[serieNb].ChartType = SeriesChartType.Doughnut;
                chartAnnuals.Series[serieNb]["PieDrawingStyle"] = "SoftEdge";

                chartAnnuals.Series[serieNb].ChartArea = "Area1";
                chartAnnuals.Series[serieNb]["DoughnutRadius"] = "35";

                chartAnnuals.Legends.Add(new Legend());
                chartAnnuals.Legends[0].BackColor = Color.Transparent;
                chartAnnuals.Legends[0].IsDockedInsideChartArea = false;

                double total = info.TotalIncomes + info.TotalExpenses;

                HSLColor greenColor = new HSLColor(CustomColors.DarkGreen);
                HSLColor redColor = new HSLColor(CustomColors.DarkRed);

                serieNb = 0;
                int pointNb = 0;

                double percentageIncome = 0;
                double percentageExpense = 0;
                
                if (total > 0)
                {
                    percentageIncome = info.TotalIncomes * 100 / total;
                    percentageExpense = info.TotalExpenses * 100 / total;
                }

                chartAnnuals.Series[serieNb].Points.Clear();

                string sLegend = FormatTooltip(info.TotalIncomes, "Revenu total", percentageIncome);
                chartAnnuals.Series[serieNb].Points.AddXY("Revenu total: " + ClassTools.ConvertCurrencyToString(info.TotalIncomes), percentageIncome);
                chartAnnuals.Series[serieNb].Points[pointNb].LabelToolTip = sLegend;
                chartAnnuals.Series[serieNb].Points[pointNb].IsVisibleInLegend = false;
                chartAnnuals.Series[serieNb].Points[pointNb].Color = greenColor;

                chartAnnuals.Series[serieNb].Points[pointNb].LabelAngle = SetOutsideLabelAngle((percentageIncome / 2) + percentageExpense);

                pointNb++;

                sLegend = FormatTooltip(info.TotalExpenses, "Dépenses totales", percentageExpense);
                chartAnnuals.Series[serieNb].Points.AddXY("Dépenses totales: " + ClassTools.ConvertCurrencyToString(info.TotalExpenses), percentageExpense);
                chartAnnuals.Series[serieNb].Points[pointNb].LabelToolTip = sLegend;
                chartAnnuals.Series[serieNb].Points[pointNb].IsVisibleInLegend = false;
                chartAnnuals.Series[serieNb].Points[pointNb].Color = redColor;

                chartAnnuals.Series[serieNb].Points[pointNb].LabelAngle = SetOutsideLabelAngle(percentageExpense / 2);

                // Details
                chartAnnuals.Series.Add(new Series());

                serieNb = 1;

                CreateChartArea(chartAnnuals, 1, "Area2", zoomedVersion);
                chartAnnuals.Series[serieNb].ChartType = SeriesChartType.Doughnut;
                chartAnnuals.Series[serieNb].ChartArea = "Area2";
                chartAnnuals.Series[serieNb]["DoughnutRadius"] = "99";

                pointNb = 0;
                chartAnnuals.Series[serieNb].Points.Clear();

                ClassTools.SortDictionaryOnAmount(ref info.CategoryDetails);

                double totalPercentage = 0;
                greenColor.Luminosity += 10;
                AddDetailedEntries(chartAnnuals, info, zoomedVersion, EType.e_Income, ref totalPercentage, ref pointNb, ref greenColor);

                redColor.Luminosity += 10;
                AddDetailedEntries(chartAnnuals, info, zoomedVersion, EType.e_Expense, ref totalPercentage, ref pointNb, ref redColor);

                return info;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
            return new TAnnualRepartitionInfo();
        }
        
        public static void InitializeChartPredictedBalances(FormMain main, Chart chartPredictedBalances, DateTime startDate, DateTime endDate, double soldeActuel, EPeriodLength period)
        {
            try
            {
                InitializeChartInfo(chartPredictedBalances);

                int entryNb = 0;
                DateTime startPredictionDate = startDate;
                DateTime endPredictionDate = startDate;

                while (endPredictionDate.Date <= endDate.Date)
                {
                    double soldePredit = 0;

                    if (main.CurrentAccountId == -1)
                    {
                        foreach (TAccountInfo account in ClassAccounts.GetAccounts().AccountsInfo.Values)
                        {
                            TPredictedBalance predictedBalanceInfo = new TPredictedBalance(account.AccountId, startPredictionDate, endPredictionDate);
                            soldePredit += main.GetPredictedBalanceAtSpecificDate(account.Balance, ref predictedBalanceInfo);
                        }
                    }
                    else
                    {
                        DateTime predictionDate = new DateTime(endPredictionDate.Year, endPredictionDate.Month, 1).AddMonths(1).AddDays(-1);
                        TPredictedBalance predictedBalanceInfo = new TPredictedBalance(main.CurrentAccountId, startPredictionDate, endPredictionDate);
                        soldePredit = main.GetPredictedBalanceAtSpecificDate(soldeActuel, ref predictedBalanceInfo);
                    }

                    AddEntryInPredictionChart(chartPredictedBalances, startPredictionDate, endPredictionDate, soldePredit, ref entryNb);
                    if (period == EPeriodLength.e_PerDay)
                        endPredictionDate = new DateTime(endPredictionDate.Year, endPredictionDate.Month, endPredictionDate.Day).AddDays(1);
                    else if (period == EPeriodLength.e_PerWeek)
                        endPredictionDate = new DateTime(endPredictionDate.Year, endPredictionDate.Month, endPredictionDate.Day).AddDays(7);
                    else
                        endPredictionDate = new DateTime(endPredictionDate.Year, endPredictionDate.Month, 1).AddMonths(1).AddDays(-1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        public static void InitializeChartInvestissement(Chart chart, TTransactionInfo info, bool annualChart = false)
        {
            if (info != null)
            {
                try
                {
                    chart.Series.Clear();

                    if (info.m_PretAmortissementList == null)
                        chart.Visible = false;
                    else
                    {
                        chart.Visible = true;

                        TTransactionInfo newInfo = new TTransactionInfo(info);
                        if (!annualChart)
                        {
                            newInfo.m_PretAmortissementList = new List<TPretAmortissement>();
                            newInfo.m_PeriodLength = EPeriodLength.e_PerMonth;
                            newInfo.m_Period = 1;
                            newInfo.m_PretAmountPerPaiement = ClassMortgage.GetAmountPerMonth(info.m_PretAmountPerPaiement, info);
                            ClassMortgage.CalculateFixPret(new DateTime(LocalSettings.BudgetYear, 1, 1), new DateTime(LocalSettings.BudgetYear, 12, 31), ref newInfo);
                        }

                        chart.AntiAliasing = AntiAliasingStyles.Text;

                        if (annualChart)
                        {
                            AddSerie(chart, 0, Color.Black, Color.Gray);
                            chart.Series[0].LabelToolTip += " - Solde";
                            AddSerie(chart, 1, Color.Black, Color.Blue);
                            chart.Series[1].LabelToolTip += " - Paiement";
                            AddSerie(chart, 2, Color.Black, Color.DarkGreen);
                            chart.Series[2].LabelToolTip += " - Capital";
                            AddSerie(chart, 3, Color.Black, Color.DarkRed);
                            chart.Series[3].LabelToolTip += " - Intérêts";
                            
                            chart.Series[0]["PixelPointWidth"] = "60";
                            chart.Series[1]["PixelPointWidth"] = "60";
                            chart.Series[2]["PixelPointWidth"] = "60";
                            chart.Series[3]["PixelPointWidth"] = "60";
                        }
                        else
                        {
                            AddSerie(chart, 0, Color.Black, Color.Gray);
                            chart.Series[0].LabelToolTip += " - Paiement";
                            AddSerie(chart, 1, Color.Black, Color.DarkGreen);
                            chart.Series[1].LabelToolTip += " - Capital";
                            AddSerie(chart, 2, Color.Black, Color.DarkRed);
                            chart.Series[2].LabelToolTip += " - Intérêts";

                            chart.Series[0]["PixelPointWidth"] = "40";
                            chart.Series[1]["PixelPointWidth"] = "40";
                            chart.Series[2]["PixelPointWidth"] = "40";

                        }

                        chart.ChartAreas[0].BackColor = CustomColors.LightGrey;
                        chart.ChartAreas[0].BackSecondaryColor = Color.White;
                        chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                        chart.ChartAreas[0].BackGradientStyle = GradientStyle.TopBottom;

                        
                        int nbEntries = 0;
                        int lastYearEntered = newInfo.m_StartDate.Year;

                        double capitalPaied = 0;
                        double interestPaied = 0;
                        foreach (TPretAmortissement pretAm in newInfo.m_PretAmortissementList)
                        {
                            capitalPaied += pretAm.CapitalPaied;
                            interestPaied += pretAm.InterestPaied;

                            if (annualChart)
                            {
                                if (pretAm.PaiementDate.Year > lastYearEntered)
                                {
                                    chart.Series[0].Points.AddXY(pretAm.PaiementDate.ToString("MM-yyyy"), (int)pretAm.RemainingAmount);
                                    
                                    double totalPaied = capitalPaied + interestPaied;
                                    if (totalPaied > pretAm.RemainingAmount)
                                    {
                                        capitalPaied = capitalPaied * pretAm.RemainingAmount / totalPaied;
                                        interestPaied = interestPaied * pretAm.RemainingAmount / totalPaied;
                                        totalPaied = pretAm.RemainingAmount;
                                    }
                                    chart.Series[1].Points.AddXY(pretAm.PaiementDate.ToString("MM-yyyy"), (int)totalPaied);
                                    chart.Series[2].Points.AddXY(pretAm.PaiementDate.ToString("MM-yyyy"), (int)capitalPaied);
                                    chart.Series[3].Points.AddXY(pretAm.PaiementDate.ToString("MM-yyyy"), (int)interestPaied);
                                    
                                    lastYearEntered = pretAm.PaiementDate.Year;
                                    capitalPaied = 0;
                                    interestPaied = 0;
                                    nbEntries++;
                                }
                            }
                            else 
                            {
                                if (pretAm.PaiementDate.Year == LocalSettings.BudgetYear)
                                {
                                    chart.Series[0].Points.AddXY(pretAm.PaiementDate.ToString("MM-yyyy"), (int)capitalPaied + interestPaied);
                                    chart.Series[0].Points[chart.Series[0].Points.Count - 1].LabelToolTip =  (int)(capitalPaied + interestPaied) + " $ - Paiement / " + (int)pretAm.RemainingAmount + " $ - Solde";
                                    
                                    chart.Series[1].Points.AddXY(pretAm.PaiementDate.ToString("MM-yyyy"), (int)capitalPaied);
                                    chart.Series[2].Points.AddXY(pretAm.PaiementDate.ToString("MM-yyyy"), (int)interestPaied);
                                    
                                    nbEntries++;
                                }
                                capitalPaied = 0;
                                interestPaied = 0;
                            }
                        }

                        if (nbEntries >= 13)
                            chart.Series[0].LabelAngle = -10;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
                }
            }
        }

        private static void InitializeChartInfo(Chart chartPredictedBalances)
        {
            chartPredictedBalances.Visible = true;

            chartPredictedBalances.Series.Clear();
            chartPredictedBalances.Series.Add(new Series());

            chartPredictedBalances.AntiAliasing = AntiAliasingStyles.Text;

            chartPredictedBalances.Series[0].ChartType = SeriesChartType.Column;
            chartPredictedBalances.Series[0]["DrawingStyle"] = "Cylinder";
            chartPredictedBalances.Series[0]["PointWidth"] = "0.6";
            chartPredictedBalances.Series[0].SmartLabelStyle.Enabled = true;
            chartPredictedBalances.Series[0].LabelAngle = 0;
            chartPredictedBalances.Series[0].LabelBackColor = CustomColors.MediumGrey;

            chartPredictedBalances.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            chartPredictedBalances.ChartAreas[0].AxisY.LabelStyle.Format = "0 $";

            chartPredictedBalances.ChartAreas[0].BackColor = CustomColors.LightGrey;
            chartPredictedBalances.ChartAreas[0].BackSecondaryColor = Color.White;
            chartPredictedBalances.ChartAreas[0].BackGradientStyle = GradientStyle.TopBottom;

            chartPredictedBalances.Series[0].Font = new Font("Arial", (float)8, FontStyle.Regular);
            chartPredictedBalances.Series[0]["MaxPixelPointWidth"] = "10";

            chartPredictedBalances.Series[0].Points.Clear();
        }

        private static void AddEntryInPredictionChart(Chart chartPredictedBalances, DateTime startPredictionDate, DateTime endPredictionDate, double soldePredit, ref int entryNb)
        {
            int predictedBalance = (int)soldePredit;

            chartPredictedBalances.Series[0].Points.AddXY(endPredictionDate.ToString("dd MMMM"), predictedBalance);
            chartPredictedBalances.Series[0].Points[entryNb].Label = ClassTools.ConvertCurrencyToString(predictedBalance);
            chartPredictedBalances.Series[0].Points[entryNb].LabelToolTip = ClassTools.ConvertCurrencyToString(predictedBalance);
            entryNb++;
            int curPoint = chartPredictedBalances.Series[0].Points.Count - 1;
            if (predictedBalance >= 0)
                chartPredictedBalances.Series[0].Points[curPoint].Color = Color.DarkGreen;
            else
                chartPredictedBalances.Series[0].Points[curPoint].Color = Color.DarkRed;
        }

        private static void AddSerie(Chart chart, int serieNb, Color labelColor, Color barColor)
        {
            chart.Series.Add(new Series());

            chart.Series[serieNb].ChartType = SeriesChartType.Column;
            chart.Series[serieNb]["DrawingStyle"] = "Cylinder";
            //chart.Series[serieNb]["PointWidth"] = "0.6";
            chart.Series[serieNb].IsValueShownAsLabel = true;
            chart.Series[serieNb].LabelAngle = 0;
            chart.Series[serieNb].LabelFormat = "{C0}";
            chart.Series[serieNb].LabelToolTip = "#VALY{C0}";
            chart.Series[serieNb].SmartLabelStyle.Enabled = true;
            chart.Series[serieNb].Color = barColor;
            chart.Series[serieNb].LabelForeColor = labelColor;
            chart.Series[serieNb].LabelBackColor = Color.Transparent;
            chart.Series[serieNb].Font = new Font("Arial", (float)8, FontStyle.Regular);
            chart.Series[serieNb].Points.Clear();
        }
        private static int SetOutsideLabelAngle(double middlePoint)
        {
            int angle = 0;

            if (middlePoint >= 0 && middlePoint <= 20)
                angle = (int)(90.0 / 25.0 * (25-middlePoint));
            else if (middlePoint > 30 && middlePoint <= 50)
                angle = (int)(90.0 / 25.0 * (middlePoint-25) * -1);
            else if (middlePoint > 50 && middlePoint <= 70)
                angle = (int)(90.0 / 25.0 * (75-middlePoint));
            else if (middlePoint >= 80)
                angle = (int)(90.0 / 25.0 * (middlePoint - 75) * -1);
            if (angle >= -90 && angle <= 90)
                return angle;
            return 0;
        }

        private static void CreateChartArea(Chart chart, int level, string AreaName, bool zoomedVersion)
        {
            chart.ChartAreas.Add(AreaName);
            chart.ChartAreas[AreaName].BackColor = Color.Transparent;

            chart.ChartAreas[AreaName].InnerPlotPosition.Auto = false;
            chart.ChartAreas[AreaName].InnerPlotPosition.Height = 100;
            chart.ChartAreas[AreaName].InnerPlotPosition.Width = 100;
            chart.ChartAreas[AreaName].InnerPlotPosition.X = 0;
            chart.ChartAreas[AreaName].InnerPlotPosition.Y = 0;

            float smallHeight = 34;
            chart.ChartAreas[AreaName].Position.Auto = false;
            chart.ChartAreas[AreaName].Position.X = 0;
            chart.ChartAreas[AreaName].Position.Y = 0 + level * smallHeight / 2;
            chart.ChartAreas[AreaName].Position.Height = 100 - level * smallHeight;

            chart.ChartAreas[AreaName].Position.Width = chart.ClientRectangle.Height * 100 / chart.ClientRectangle.Width;

            //chart.ChartAreas[AreaName].Area3DStyle.Enable3D = true;
            //chart.ChartAreas[AreaName].Area3DStyle.Inclination = 0;
        }

        private static void AddExplodedValue(Series chartSerie, EType type, double amount, double percentage, double legendPercentage, ref int pointNb)
        {
            string categoryName = "Divers";

            chartSerie.Points.AddXY(categoryName, percentage);

            chartSerie.Points[pointNb].CustomProperties = "Exploded=true";
            chartSerie.Points[pointNb].Color = Color.Gray;

            string sLegend = FormatTooltip(amount, categoryName, legendPercentage);
            chartSerie.Points[pointNb].LabelToolTip += sLegend;
            chartSerie.Points[pointNb].LegendText += sLegend;
            pointNb++;    
        }

        private static void AddDetailedEntries(Chart chartAnnuals, TAnnualRepartitionInfo info, bool zoomedVersion, EType type, ref double totalPercentage, ref int pointNb, ref HSLColor color)
        {
            double percentage;
            int serieNb = 1;
            double total = info.TotalIncomes + info.TotalExpenses;
            bool moreThanOneExplodedEntry = false; // Do not explode if one entry only

            TCategoryDetails explodedDetail = new TCategoryDetails();
            foreach (TCategoryDetails detail in info.CategoryDetails.Values)
            {
                if (detail.Type == type)
                {
                    double legendPercentage = detail.CategoryAmount * 100 / (detail.Type == EType.e_Income ? info.TotalIncomes : info.TotalExpenses);
                    percentage = detail.CategoryAmount * 100 / total;
                    if (!zoomedVersion && percentage <= EXPLODED_THRESHOLD)
                    {
                        if (explodedDetail.CategoryAmount == 0)
                            explodedDetail = detail;
                        else
                        {
                            moreThanOneExplodedEntry = true;
                            explodedDetail.CategoryAmount += detail.CategoryAmount;
                        }
                    }
                    else
                        AddDetailedValuesInChartSerie(chartAnnuals.Series[serieNb], detail, percentage, legendPercentage, zoomedVersion, ref totalPercentage,ref pointNb, ref color);
                }
            }
            if (explodedDetail.CategoryAmount > 0)
            {
                double legendPercentage = explodedDetail.CategoryAmount * 100 / (explodedDetail.Type == EType.e_Income ? info.TotalIncomes : info.TotalExpenses);
                percentage = explodedDetail.CategoryAmount * 100 / total;
                if (moreThanOneExplodedEntry)
                    AddExplodedValue(chartAnnuals.Series[serieNb], type, explodedDetail.CategoryAmount, percentage, legendPercentage, ref pointNb);
                else
                    AddDetailedValuesInChartSerie(chartAnnuals.Series[serieNb], explodedDetail, percentage, legendPercentage, zoomedVersion, ref totalPercentage, ref pointNb, ref color);
            }
            
        }

        private static void AddDetailedValuesInChartSerie(Series chartSerie, TCategoryDetails info, double percentage, double legendPercentage, bool zoomedVersion, ref double totalPercentage, ref int pointNb, ref HSLColor color)
        {
            string categoryName = ClassTools.GetCategory(info.CategoryId, ClassTransactions.GetTransactions().Categories);
            string sLegend = FormatTooltip(info.CategoryAmount, categoryName, legendPercentage);

            chartSerie.Points.AddXY(categoryName, percentage);

            chartSerie.Points[pointNb].Color = color;

            int middlePoint = (int)(totalPercentage + percentage / 2);

            totalPercentage += percentage;

            if (percentage < 15)
            {
                int angle = 0;
                if (middlePoint <= 25)
                    angle = middlePoint * 90 / 25;
                else if (middlePoint <= 50)
                    angle = (middlePoint - 25) * 90 / 25 - 90;
                else if (middlePoint <= 75)
                    angle = (middlePoint - 50) * 90 / 25;
                else
                    angle = (middlePoint - 75) * 90 / 25 - 90;
                
                if (angle >= -90 && angle <= 90)
                    chartSerie.Points[pointNb].LabelAngle = angle;
            }

            color.Luminosity += 10;

            chartSerie.Points[pointNb].LabelToolTip += sLegend;
            chartSerie.Points[pointNb].LegendText += sLegend;
            pointNb++;
        }

        private static string FormatTooltip(double value, string categoryName, double percentage)
        {
            return categoryName + " " + ClassTools.ConvertCurrencyToString(value) + " (" + ClassTools.ConvertDoubleToString(percentage) + "%)";
        }

        private FormMain m_mainForm;
        private static int EXPLODED_THRESHOLD = 2;
    }
}
