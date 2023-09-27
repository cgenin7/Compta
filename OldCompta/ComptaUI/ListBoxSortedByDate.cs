using ComptaCommun;
using System;
using System.Windows.Forms;

namespace Compta
{
    public class ListBoxSortedByDate : ListBox
    {
        protected override void Sort()
        {
            try
            {
                if (Items.Count > 1)
                {
                    bool swapped;
                    do
                    {
                        int counter = Items.Count - 1;
                        swapped = false;

                        while (counter > 0)
                        {
                            var info = Items[counter] as TToComeInfo;
                            var previousInfo = Items[counter - 1] as TToComeInfo;
                            // Compare the items' date
                            if (info != null && previousInfo != null)
                            {
                                if (info.Date < previousInfo.Date)
                                {
                                    // Swap the items.
                                    object temp = Items[counter];
                                    Items[counter] = Items[counter - 1];
                                    Items[counter - 1] = temp;
                                    swapped = true;
                                }
                                // Decrement the counter.
                                counter -= 1;
                            }
                        }
                    }
                    while ((swapped == true));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        public double GetTotalAmount()
        {
            double totalAmount = 0;

            if (Items.Count > 0)
            {
                foreach (TToComeInfo item in Items)
                {
                    totalAmount += item.NextPaymentAmount;
                }
            }
            return totalAmount;
        }
    }
}
