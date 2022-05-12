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
        public static float amountMoneyInAccount;
        private int userId; // id użytkownika wysyłającego przelew
        public static string userFirstName = ""; // imie użytkownika wyjściowego
        public static string userLastName = ""; // nazwisko użytkownika wyjściowego

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

            //this.userFirstName = "-";
            //this.userLastName = "-";
            this.endUserFirstName = "-";
            this.endUserLastName = "-";
        }

        public Transakcja(string userFirstNameArg, string userLastNameArg, float amountMoneyInAccountArg)
        {
            id += 1;
            userFirstName = userFirstNameArg;
            userLastName = userLastNameArg;
            amountMoneyInAccount = amountMoneyInAccountArg;
        }

        public Transakcja(string endBankName, float amount, string currency, DateTime dateofTransaction, string description)
        {
            id += 1;
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
            listBox.Items.Add($"Twój numer indentyfikacyjny: {userId}");
            listBox.Items.Add($"Ilość pieniędzy w twoim banku: {amountMoneyInAccount} PLN");
        }

        public void WriteData(ListBox listBox)
        {
            listBox.Items.Clear();
            CheckingWhetherTransferCanTakePlace();
            if (!isCorrect)
            {
                listBox.Items.Add("Błąd w wypełnianiu formularza!");
                MessageBox.Show("Błąd w wypełnianiu formularza!");
                return;
            }

            listBox.Items.Add($"Nazwa banku do którego wysyłany jest przelew: {endBankName}");
            listBox.Items.Add($"Kwota przelewu: {amount}");
            listBox.Items.Add($"Waluta przelewu: {currency}");
            listBox.Items.Add($"Data przelewu: {dateofTransaction}");
            listBox.Items.Add($"Opis przelewu: {description}");
        }

        private void CheckIsCorrect()
        {
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

        private void CheckingWhetherTransferCanTakePlace()
        {
            isCorrect = false;

            if (!CheckAmount()) return;
            if (!CheckDescription()) return;

            isCorrect = true;
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

        public static bool CheckTransaction()
        {
            if (userFirstName.Length == 0 && userLastName.Length == 0)
            {
                MessageBox.Show("Wypełnij dane do transakcji!");
                return false;
            }

            return true;
        }
    }
}
