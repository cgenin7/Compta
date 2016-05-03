using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ComptaCommun;
using System.Reflection;

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
                            TDisplayInfo info = Items[counter] as TDisplayInfo;
                            TDisplayInfo previousInfo = Items[counter - 1] as TDisplayInfo;
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
    }
}
