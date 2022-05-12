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
        private readonly List<string> categoriesList = new List<string> { "jedzenie", "zakupy", "paliwo" };
        private readonly string currency;
        private readonly float amount;
        private DateTime dateTransaction;
        private readonly int indexOfCategories;

        public PrzelewZwykly()
        {
        }

        public PrzelewZwykly(string endBankName, float amount, string currency, DateTime dateofTransaction, string description, string endUserFirstName, string endUserLastName, int endUserId, int indexOfCategories) : base(endBankName, amount, currency, dateofTransaction, description, endUserFirstName, endUserLastName, endUserId)
        {
            this.amount = amount;
            this.currency = currency;
            this.dateTransaction = dateofTransaction;
            this.indexOfCategories = indexOfCategories;
        }

        public new void Write(ListBox listBox)
        {
            base.WriteData(listBox);

            listBox.Items.Add($"Przewidywny czas realizacji przelewu {WhenTransferArrives()}");
            listBox.Items.Add($"Kategoria przelewu {categoriesList[indexOfCategories]}");
            if (currency != "PLN")
            {
                // jeżeli przelew odbywa się w walucie obcej to wyświetlamy przeliczenie walut użytkownikowi
                listBox.Items.Add($"Transfer w walucie obcej przeliczone na złotówki: {CurrencyConversion()} PLN");
            }
        }

        private string WhenTransferArrives()
        {
            // Wyświetlanie informacji, którego dnia użytkownik powinien otrzymać przelew
            return dateTransaction.AddDays(3).ToString("dd/MM/yyyy");
        }

        private float CurrencyConversion()
        {
            // Przeliczanie walut między PLN - EUR oraz PLN - USD

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
