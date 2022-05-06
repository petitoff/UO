using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    class PrzelewStaly : Transakcja
    {
        private float amountMoneyInAccount;
        private string dateOfExecution;
        private bool isActive;

        public PrzelewStaly() : base()
        {
            this.amountMoneyInAccount = 0F;
            this.isActive = false;
        }

        public PrzelewStaly(string bankName, string endBankName, float amount, string currency, float amountMoneyInAccount, DateTime dateOfExecution, string description) : base(bankName, endBankName, amount, currency, dateOfExecution, description)
        {
            this.amountMoneyInAccount = amountMoneyInAccount;
            this.dateOfExecution = dateOfExecution.ToShortDateString(); ;
        }

        public new void Write(ListBox listBox)
        {
            CheckIsActive();

            base.Write(listBox);
            listBox.Items.Add($"Ilość pieniędzy w twoim banku: {amountMoneyInAccount}");
            listBox.Items.Add($"Data kiedy przelew ma zostać wykonany: {dateOfExecution}");
            listBox.Items.Add($"Czy przelew jest aktywny: {(isActive ? "tak" : "nie")}");
        }

        private void CheckIsActive()
        {
            if (!CheckIfDateIsCorrect())
            {
                isActive = false;
                return;
            }

            isActive = true;
        }

        private bool CheckIfDateIsCorrect()
        {
            DateTime tempDate1 = Convert.ToDateTime(dateOfExecution);
            DateTime tempDate2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan value = tempDate1.Subtract(tempDate2);
            if (value.TotalMinutes > 0) return true;
            return false;
        }
    }
}
