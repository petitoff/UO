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
            userFirstName = userFirstNameArg;
            userLastName = userLastNameArg;
            amountMoneyInAccount = amountMoneyInAccountArg;
        }

        public Transakcja(string endBankName, float amount, string currency, DateTime dateofTransaction, string description, string endUserFirstName, string endUserLastName, int endUserId)
        {
            id += 1;
            this.endBankName = endBankName;
            this.amount = amount;
            this.currency = currency;
            this.dateofTransaction = dateofTransaction;
            this.description = description;
            this.endUserFirstName = endUserFirstName;
            this.endUserLastName = endUserLastName;
            this.endUserId = endUserId;
        }

        public void UpdateData(ListBox listBox)
        {
            listBox.Items.Clear();
            listBox.Items.Add($"Dzień dobry: {userFirstName} {userLastName}");
            listBox.Items.Add($"Twój numer indentyfikacyjny: {userId}");
            listBox.Items.Add($"Ilość pieniędzy w twoim banku: {amountMoneyInAccount} PLN");
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

            UpdateData(listBox);
        }

        public void WriteData(ListBox listBox)
        {
            listBox.Items.Clear();
            CheckingWhetherTransferCanTakePlace();

            listBox.Items.Add($"Czy przelew może się odbyć: {(isCorrect ? "tak" : "nie")}");
            listBox.Items.Add($"Numer indentyfikacyjny transakcji: {id}");

            if (!isCorrect)
            {
                listBox.Items.Add("Błąd w wypełnianiu formularza!");
                MessageBox.Show("Błąd w wypełnianiu formularza!");
                return;
            }

            UpdatingMoneyInAccount();

            listBox.Items.Add($"Nazwa banku do którego wysyłany jest przelew: {endBankName}");
            listBox.Items.Add($"Kwota przelewu: {amount}");
            listBox.Items.Add($"Waluta przelewu: {currency}");
            listBox.Items.Add($"Stan konta po przelewie: {amountMoneyInAccount} PLN");
            listBox.Items.Add($"Data przelewu: {dateofTransaction}");
            listBox.Items.Add($"Opis przelewu: {description}");
            listBox.Items.Add($"Imię osoby do kótrej wysyłany jest przelew: {endUserFirstName}");
            listBox.Items.Add($"Nazwisko osoby do kótrej wysyłany jest przelew: {endUserLastName}");
            listBox.Items.Add($"Numer indentyfikacyjny osoby do której wysyłany jest przelew: {endUserId}");
        }

        public void UpdatingMoneyInAccount()
        {
            amountMoneyInAccount -= amount;
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
            if (!CheckIfIdIsSame()) return;

            isCorrect = true;
        }

        private bool CheckAmount()
        {
            if (amount == 0F) return false;

            if (currency == "EUR")
            {
                if (amountMoneyInAccount - amount * 4.5F < 0)
                {
                    MessageBox.Show(@"Podałeś kwotę większą niż posiadasz pieniędzy w banku!");
                    return false;
                }
            }

            if (currency == "USD")
            {
                if (amountMoneyInAccount - amount * 3.8F < 0)
                {
                    MessageBox.Show(@"Podałeś kwotę większą niż posiadasz pieniędzy w banku!");
                    return false;
                }
            }

            if (amountMoneyInAccount - amount < 0)
            {
                MessageBox.Show(@"Podałeś kwotę większą niż posiadasz pieniędzy w banku!");
                return false;
            }
            return true;
        }

        private bool CheckDescription()
        {
            if (description.Length == 0) return false;
            return true;
        }

        private bool CheckIfIdIsSame()
        {
            if (userId == endUserId)
            {
                MessageBox.Show(@"Nie możesz zrealizować przelewu na to samo konto!");
                return false;
            }

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

        public static int ConvertToInt(string s)
        {
            try
            {
                return int.Parse(s);
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
