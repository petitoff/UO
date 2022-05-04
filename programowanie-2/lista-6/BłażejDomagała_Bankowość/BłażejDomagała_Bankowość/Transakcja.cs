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
        private string description; // opis przelewu od użytkownika
        private string category;

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
            this.category = "";

            this.userId = 0;
            this.endUserId = userId;

            this.userFirstName = "-";
            this.userLastName = "-";
            this.endUserFirstName = "-";
            this.endUserLastName = "-";
        }

        public void Write(ListBox listbox)
        {
            // Funkcja odpowiedzialna za wypisywanie wartości pól do listbox'a

            listbox.Items.Add($"Nazwa banku z którego pochodzi przelew: {bankName}");
            listbox.Items.Add($"Nazwa banku do którego wysyłany jest przelew: {endBankName}");
            listbox.Items.Add($"Nazwa banku do którego wysyłany jest przelew: {endBankName}");
            listbox.Items.Add($"Kwota przelewu {amount}");
            listbox.Items.Add($"Waluta w jakiej realizowany jest przelew {currency}");
            listbox.Items.Add($"Numer indentyfikacyjny transakcji {id}");
            listbox.Items.Add($"Data wysłania przelewu {dateofTransaction}");
            listbox.Items.Add($"Opis przelewu {description}");
            listbox.Items.Add($"Numer indentyfikacyjny użytkownika wysyłającego przelew {userId}");
            listbox.Items.Add($"Imię użytkownika wysyłającego przelew {userFirstName}");
            listbox.Items.Add($"Nazwisko użytkownika wysyłającego przelew {userLastName}");
            listbox.Items.Add($"Numer indentyfikacyjny użytkownika odbierającego przelew {endUserId}");
            listbox.Items.Add($"Imię użytkownika odbierającego przelew {endUserFirstName}");
            listbox.Items.Add($"Nazwisko użytkownika odbierającego przelew {endUserLastName}");
        }
    }
}
