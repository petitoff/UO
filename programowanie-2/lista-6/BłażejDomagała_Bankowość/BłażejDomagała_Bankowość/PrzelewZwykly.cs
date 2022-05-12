using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    class PrzelewZwykly : Transakcja
    {
        private List<string> categoriesList = new List<string> { "jedzenie", "zakupy", "paliwo" };
        private string currency;
        private float amount;
        private DateTime dateTransaction;

        public PrzelewZwykly()
        {
        }

        public PrzelewZwykly(string endBankName, float amount, string currency, DateTime dateofTransaction, string description, string endUserFirstName, string endUserLastName, int endUserId) : base(endBankName, amount, currency, dateofTransaction, description, endUserFirstName, endUserLastName, endUserId)
        {
            this.amount = amount;
            this.currency = currency;
            this.dateTransaction = dateofTransaction;
        }

        public new void Write(ListBox listBox)
        {
            base.WriteData(listBox);

            listBox.Items.Add($"Przewidywny czas realizacji przelewu {WhenTransferArrives()}");
            if (currency != "PLN")
            {
                listBox.Items.Add($"Transfer w walucie obcej przeliczone na złotówki: {CurrencyConversion()} PLN");
            }
        }

        public void WriteWidget(ListBox listBox)
        {
            base.Write(listBox);
        }

        private string WhenTransferArrives()
        {
            return dateTransaction.AddDays(3).ToString("dd/MM/yyyy");
        }

        private float CurrencyConversion()
        {
            if (currency == "EUR")
            {
                return (float)Math.Round((amount * 4.5F), 2);
            }

            if (currency == "USD")
            {
                return (float)Math.Round((amount * 3.8F), 2);
            }

            return 0;
        }
    }
}
