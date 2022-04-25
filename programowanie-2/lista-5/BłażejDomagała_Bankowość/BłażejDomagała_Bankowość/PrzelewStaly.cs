using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    internal class PrzelewStaly : Transakcja
    {
        //private string bankName = "eBank";
        //private string currency = "PLN";
        //private float amount;
        //private int id; // indentyfikator transakcji
        //private bool isCompleted;
        //private int userId; // indentyfikator użytkownika
        //private string userFirstName;
        //private string userLastName;
        //private string dateOfTransaction;

        string dateWhenTransactionHasToBePerformed;
        string timeWhenTransactionHasToBePerformed;
        string timeZoneGmt;
        bool isActive;

        //private int endUserId;
        //private string endUserFirstName;
        //private string endUserLastName;
        //private string endBankName;
        //private string description;

        public PrzelewStaly() : base()
        {
            dateWhenTransactionHasToBePerformed = "25-04-2022";
            timeWhenTransactionHasToBePerformed = "10.10";
            timeZoneGmt = "+2";
        }

        public new void Write(ListBox listBox)
        {
            base.Write(listBox);
            listBox.Items.Add(dateWhenTransactionHasToBePerformed);
            listBox.Items.Add(timeWhenTransactionHasToBePerformed);
            listBox.Items.Add(timeZoneGmt);
        }
    }
}
