using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    class Transakcja
    {
        // dane transakcji
        private string bankName = "eBank"; // nazwa banku z którego wychodzi przelew
        private string endBankName; // nazwa banku do którego idzie

        private float amount; // kwota realizacji przelewu
        private string currency; // symbol waluty w jakiej dociera przelew
        private static int id = 0; // id transakcji
        private DateTime dateofTransaction; // data wysłania przelewu
        private string description = ""; // opis przelewu od użytkownika
        private bool isCorrect = false;

        // dane użytkownika wyjściowego
        private float amountMoneyInAccount = 1000;
        private int userId; // id użytkownika wysyłającego przelew
        private string userFirstName; // imie użytkownika wyjściowego
        private string userLastName; // nazwisko użytkownika wyjściowego

        // dane użytkownika wejściowego
        private int endUserId;
        private string endUserFirstName;
        private string endUserLastName;

        public Transakcja()
        {
            this.endBankName = "eBank";

            this.amount = 0F;
            this.currency = "PLN";
            id += 1;
            this.dateofTransaction = DateTime.Now;
            this.description = "-";

            this.userId = 0;
            this.endUserId = userId;

            this.userFirstName = "-";
            this.userLastName = "-";
            this.endUserFirstName = "-";
            this.endUserLastName = "-";
        }

        public Transakcja(string userFirstName, string userLastName, float amountMoneyInAccount)
        {
            this.userFirstName = userFirstName;
            this.userLastName = userLastName;
            this.amountMoneyInAccount = amountMoneyInAccount;
        }

        public Transakcja(string endBankName, float amount, string currency, DateTime dateofTransaction, string description)
        {
            id += 1;
            //this.bankName = bankName;
            this.endBankName = endBankName;
            this.amount = amount;
            this.currency = currency;
            this.dateofTransaction = dateofTransaction;
            this.description = description;
        }

        public void Write(ListBox listBox)
        {
            // Funkcja odpowiedzialna za wypisywanie wartości pól do listbox'a

            listBox.Items.Clear();

            CheckIsCorrect();
            if (!isCorrect)
            {
                listBox.Items.Add("Błąd w wypełnianiu formularza!");
                MessageBox.Show("Błąd w wypełnianiu formularza!");
                return;
            }

            listBox.Items.Add($"Dzień dobry: {userFirstName} {userLastName}");
            listBox.Items.Add($"Ilość pieniędzy w twoim banku: {amountMoneyInAccount} PLN");

        }

        private void CheckIsCorrect()
        {
            //if (!CheckAmount()) return;
            //if (!CheckDescription()) return;

            if (!FormIsFellCorrect()) return;

            isCorrect = true;
        }

        private bool FormIsFellCorrect()
        {
            if (userFirstName != "" && userLastName != "")
            {
                return true;
            }

            return false;
        }

        private bool CheckAmount()
        {
            if (amount == 0F) return false;
            return true;
        }

        private bool CheckDescription()
        {
            if (description.Length == 0) return false;
            return true;
        }

        public static float ConvertToFloat(string s)
        {
            try
            {
                return float.Parse(s);
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd! Wprowadź liczby!");
                return 0;
            }
        }
    }
}
