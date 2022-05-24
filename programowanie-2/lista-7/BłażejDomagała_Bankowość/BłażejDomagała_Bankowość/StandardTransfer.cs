using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    class StandardTransfer : Transaction
    {
        //private List<string> Categories = new List<string> { "Jedzenie", "Zakupy", "Paliwo" };
        private float amount;
        private string currency;
        private float usdPrice = 3.5F;
        private float eurPrice = 4.3F;
        private string categories;
        private bool isCorrectSt = false;

        public StandardTransfer(string endUserFirstName, string endUserLastName, int endUserId, float amount, string currency, string description, string categories, Bitmap imageBitmap, float AmountMoneyInAccount) : base(endUserFirstName, endUserLastName, endUserId, description, imageBitmap, AmountMoneyInAccount)
        {
            this.amount = amount;
            this.currency = currency;
            this.categories = categories;
        }

        private bool ConvertCurrency()
        {

            if (currency == "PLN")
            {
                if (!base.CheckIsThereEnoughMoney(amount))
                {
                    MessageTemplate(1);
                    return false;
                }
                return true;
            }

            if (currency == "USD")
            {
                if (!base.CheckIsThereEnoughMoney(amount * usdPrice))
                {
                    MessageTemplate(1);
                    return false;
                }
                return true;
            }

            if (currency == "EUR")
            {
                if (!base.CheckIsThereEnoughMoney(amount * eurPrice))
                {
                    MessageTemplate(1);
                    return false;
                }
                return true;
            }

            return false;
        }

        public override void CheckIsCorrect()
        {
            if (amount == 0)
            {
                MessageTemplate(3);
                return false;
            }
            if (!ConvertCurrency()) return false;
            return true;
        }

        private DateTime WhenTransactionWillBeCompleted()
        {
            return  DateTime.Now.AddDays(2).Date;
        }

        public override void Write(ListBox listBox)
        {
            base.Write(listBox);
            if (!base.isCorrect) return;

            if (!CheckIsCorrect())
            {
                MessageTemplate(2);
                listBox.Items.Add("Przelew się nieodbyl! Pieniądze nie zostały pobrane!");
                return;
            }

            AmountMoneyInAccount -= amount;

            listBox.Items.Add($"Kwota transakcji: {amount} {currency}");
            listBox.Items.Add($"Przelew zostanie zrealizowany w ciągu 2 dni roboczych: {WhenTransactionWillBeCompleted():dd/MM/yyyy}");
            listBox.Items.Add($"Kategoria przelewu: {categories}");
            listBox.Items.Add("");
        }
    }
}
