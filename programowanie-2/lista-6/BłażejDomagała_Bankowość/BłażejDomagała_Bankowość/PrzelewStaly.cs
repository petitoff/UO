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
        private DateTime dateTransaction;
        private bool isCorrect = false;

        public PrzelewStaly()
        {

        }

        public PrzelewStaly(string endBankName, float amount, string currency, DateTime dateofTransaction,
            string description, string endUserFirstName, string endUserLastName, int endUserId) :
            base(endBankName, amount, currency, dateofTransaction, description, endUserFirstName, endUserLastName,
                endUserId)
        {
            this.dateTransaction = dateofTransaction;
        }

        public new void Write(ListBox listBox)
        {
            CheckingInHowManyDaysTransferIsToBeMade();
            if (!isCorrect)
            {
                listBox.Items.Add("Błąd w wypełnianiu formularza!");
                return;
            }

            base.WriteData(listBox);
            listBox.Items.Add($"Przelew odbęcie sie za {SubtrackDays()} dni");
        }

        private void CheckingInHowManyDaysTransferIsToBeMade()
        {
            if (SubtrackDays() == 0)
            {
                MessageBox.Show(@"Należy zaplanować przelew minimum z dwudniowym opóźnieniem!");
                return;
            }

            isCorrect = true;
        }

        private int SubtrackDays()
        {
            return dateTransaction.Day - DateTime.Now.Day;
        }
    }
}
