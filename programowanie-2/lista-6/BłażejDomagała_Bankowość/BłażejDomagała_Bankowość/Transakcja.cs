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

        private string currency = "PLN"; // symbol waluty w jakiej dociera przelew
        private static int id = 0; // id transakcji
        private DateTime dateofTransaction; // data wysłania przelewu
        private string description; // opis przelewu od użytkownika
        private string isCompleted; // czy transakcja została już zrealizowana

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
            id += 1;
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
        }
    }
}
