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
        string dateWhenTransactionHasToBePerformed;
        string timeWhenTransactionHasToBePerformed;
        string timeZoneGmt;
        bool isActive;
        string typeOfTransaction;
        float amount;

        private List<int> idList = new List<int>();

        public PrzelewStaly() : base()
        {
            amount = 123.9F;
            dateWhenTransactionHasToBePerformed = "25-04-2022";
            timeWhenTransactionHasToBePerformed = "10.10";
            timeZoneGmt = "+2";
            isActive = true;
            typeOfTransaction = "przelew stały";
        }

        public PrzelewStaly(string dateWhenTransactionHasToBePerformed, string timeWhenTransactionHasToBePerformed, string timeZoneGmt, bool isActive, string typeOfTransaction, float amount) : base()
        {
            this.dateWhenTransactionHasToBePerformed = dateWhenTransactionHasToBePerformed;
            this.timeWhenTransactionHasToBePerformed = timeWhenTransactionHasToBePerformed;
            this.timeZoneGmt = timeZoneGmt;
            this.isActive = isActive;
            this.typeOfTransaction = typeOfTransaction;
            this.amount = amount;
        }

        public PrzelewStaly(PrzelewStaly ps)
        {
            this.dateWhenTransactionHasToBePerformed = ps.dateWhenTransactionHasToBePerformed;
            this.timeWhenTransactionHasToBePerformed = ps.timeWhenTransactionHasToBePerformed;
            this.timeZoneGmt = ps.timeZoneGmt;
            this.isActive = ps.isActive;
            this.typeOfTransaction = ps.typeOfTransaction;
            this.amount = ps.amount;
        }

        public new void Write(ListBox listBox)
        {
            var transakcja = new Transakcja();

            if (CheckValidation()) return;

            base.Write(listBox);
            listBox.Items.Add($"kwota transakcji {amount}");
            listBox.Items.Add(dateWhenTransactionHasToBePerformed);
            listBox.Items.Add(timeWhenTransactionHasToBePerformed);
            listBox.Items.Add(timeZoneGmt);
            listBox.Items.Add(CheckIsActive(isActive));
            listBox.Items.Add(transakcja.TypeOfTransaction(typeOfTransaction));
        }

        private string CheckIsActive(bool isActiveArg)
        {
            if (isActiveArg)
            {
                return "Przelew stały jest aktywny";
            }
            return "Przelew stały jest nieaktywny";
        }

        private bool CheckValidation()
        {
            if (dateWhenTransactionHasToBePerformed.Length == 0 || timeWhenTransactionHasToBePerformed.Length == 0)
            {
                MessageBox.Show("Błąd! Podałeś pustą wartość!");
                return true;
            }

            return false;
        }
    }
}
