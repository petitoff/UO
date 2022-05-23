using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    class StandardTransfer : Transaction
    {
        private List<string> Categories = new List<string>{"Jedzenie", "Zakupy","Paliwo"};
        public StandardTransfer(string endUserFirstName, string endUserLastName) : base(endUserFirstName, endUserLastName)
        private List<string> Categories = new List<string> { "Jedzenie", "Zakupy", "Paliwo" };
        private float amount;
        private string currency;
        private float usdPrice = 3.5F;
        private float eurPrice = 4.3F;

        public StandardTransfer(string endUserFirstName, string endUserLastName, int endUserId, float amount, string currency, string description) : base(endUserFirstName, endUserLastName, endUserId, description)
        {
            this.amount = amount;
            this.currency = currency;
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
                    base.MessageTemplate(1);
                    return false;
                }
                return true;
            }

            return false;
        }
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
            listBox.Items.Add("");
        }
    }
}
