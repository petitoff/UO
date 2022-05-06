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
        private string bankName; // nazwa banku z którego wychodzi przelew
        private string endBankName; // nazwa banku do którego idzie

        private float amount; // kwota realizacji przelewu
        private string currency; // symbol waluty w jakiej dociera przelew
        private static int id = 0; // id transakcji
        private DateTime dateofTransaction; // data wysłania przelewu
        private string description = ""; // opis przelewu od użytkownika
        private bool isCorrect = false;
        //private string category; // to będzie lista

        // dane użytkownika wyjściowego
        private int userId; // id użytkownika wysyłającego przelew
        private string userFirstName; // imie użytkownika wyjściowego
        private string userLastName; // nazwisko użytkownika wyjściowego

        // dane użytkownika wejściowego
        private int endUserId;
        private string endUserFirstName;
        private string endUserLastName;

        public Transakcja()
        {
            this.bankName = "eBank";
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

        public Transakcja(string bankName, string endBankName, float amount, string currency, DateTime dateofTransaction, string description)
        {
            this.bankName = bankName;
            this.endBankName = endBankName;
            this.amount = amount;
            this.currency = currency;
            this.dateofTransaction = dateofTransaction;
            this.description = description;
        }

        public void Write(ListBox listBox)
        {
            // Funkcja odpowiedzialna za wypisywanie wartości pól do listbox'a


            listBox.Items.Add($"Nazwa banku z którego pochodzi przelew: {bankName}");
            listBox.Items.Add($"Nazwa banku do którego wysyłany jest przelew: {endBankName}");
            listBox.Items.Add($"Kwota przelewu: {amount}");
            listBox.Items.Add($"Waluta w jakiej realizowany jest przelew: {currency}");
            listBox.Items.Add($"Numer indentyfikacyjny transakcji: {id}");
            listBox.Items.Add($"Data wysłania przelewu: {dateofTransaction}");
            listBox.Items.Add($"Opis przelewu: {description}");
            listBox.Items.Add($"Czy transakcja może zostać wykoana: {(isCorrect? "Tak" : "Nie")}");
            listBox.Items.Add($"Numer indentyfikacyjny użytkownika wysyłającego przelew: {userId}");
            listBox.Items.Add($"Imię użytkownika wysyłającego przelew: {userFirstName}");
            listBox.Items.Add($"Nazwisko użytkownika wysyłającego przelew: {userLastName}");
            listBox.Items.Add($"Numer indentyfikacyjny użytkownika odbierającego przelew: {endUserId}");
            listBox.Items.Add($"Imię użytkownika odbierającego przelew: {endUserFirstName}");
            listBox.Items.Add($"Nazwisko użytkownika odbierającego przelew: {endUserLastName}");
        }
        }
    }
}
