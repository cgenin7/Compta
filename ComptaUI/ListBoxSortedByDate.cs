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
                        int counter = 1;
                        swapped = false;

                        while (counter < Items.Count)
                        {
                            TDisplayInfo previousInfo = Items[counter - 1] as TDisplayInfo;
                            TDisplayInfo info = Items[counter] as TDisplayInfo;

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
                                // Increment the counter.
                                counter++;
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
                foreach (var item in Items)
                    totalAmount += (item as TDisplayInfo).WarningAmount;
            }

            return totalAmount;
        }
    }
}
