using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BłażejDomagała_Bankowość
{
    internal class Transakcja
    {
        private string bankName = "eBank";
        private string currency = "PLN";
        private float amount;
        protected static int id; // indentyfikator transakcji
        private bool isCompleted;
        private int userId; // indentyfikator użytkownika
        private string userFirstName;
        private string userLastName;
        private string dateOfTransaction;
        private int endUserId;
        private string endUserFirstName;
        private string endUserLastName;
        private string endBankName;
        private string description;

        public Transakcja()
        {
            // Konstruktor bezargumentowy
            this.bankName = "eBank";
            this.currency = "PLN";
            this.amount = 120.50F;
            id +=1;
            this.isCompleted = false;
            this.userId = 37128;
            this.userFirstName = "Jan";
            this.userLastName = "Kowalski";
            this.dateOfTransaction = "06-04-2022";
            this.endUserId = 27431;
            this.endUserFirstName = "Dariusz";
            this.endUserLastName = "Nowak";
            this.endBankName = "mBank";
            this.description = "Przelew";
        }

        public Transakcja(string bankName, string currency, float amount, bool isCompleted, int idUser, string firstNameUser, string lastNameUser, string dateOfTransaction, int idUserDestination, string firstNameUserDestination, string lastNameUserDestination, string nameOfBankDestination, string description)
        {
            // Konstruktor wieloargumentowy
            this.bankName = bankName;
            this.currency = currency;
            this.amount = amount;
            id +=1;
            this.isCompleted = isCompleted;
            this.userId = idUser;
            this.userFirstName = firstNameUser;
            this.userLastName = lastNameUser;
            this.dateOfTransaction = dateOfTransaction;
            this.endUserId = idUserDestination;
            this.endUserFirstName = firstNameUserDestination;
            this.endUserLastName = lastNameUserDestination;
            this.endBankName = nameOfBankDestination;
            this.description = description;
        }

        public Transakcja(Transakcja t)
        {
            this.bankName = t.bankName;
            this.currency = t.currency;
            this.amount = t.amount;
            id +=1;
            this.isCompleted = t.isCompleted;
            this.userId = t.userId;
            this.userFirstName = t.userFirstName;
            this.userLastName = t.userLastName;
            this.dateOfTransaction = t.dateOfTransaction;
            this.endUserId = t.endUserId;
            this.endUserFirstName = t.endUserFirstName;
            this.endUserLastName = t.endUserLastName;
            this.endBankName = t.endBankName;
            this.description = t.description;
        }

        public void Write(ListBox listBox)
        {
            CheckIfTheSameId();
            CheckOfDescriptionIsEmpty();

            listBox.Items.Add($"Nazwa banku: {bankName}");
            listBox.Items.Add($"Nazwa waluty: {currency}");
            listBox.Items.Add($"Kwota transakcji: {amount}");
            listBox.Items.Add($"Numer indentyfikacyjny transakcji: {id}");
            listBox.Items.Add($"Transakcja {(isCompleted == true ? "została" : "niezostała")} zrelizowana");
            listBox.Items.Add($"Numer indentyfikacyjny użytkownika wysyłającego: {userId}");
            listBox.Items.Add($"Imię użytkownika wysyłającego: {userFirstName}");
            listBox.Items.Add($"Nazwisko użytkownika wysyłającego: {userFirstName}");
            listBox.Items.Add($"Data wykonania transakcji: {dateOfTransaction}");
            listBox.Items.Add($"Numer indentyfikacyjny użytkownika do którego ma dotrzeć przelew: {endUserId}");
            listBox.Items.Add($"Imię użytkownika do którego ma dotrzeć przelew: {endUserFirstName}");
            listBox.Items.Add($"Nazwisko użytkownika do którego ma dotrzeć przelew: {endUserLastName}");
            listBox.Items.Add($"Nazwa banku użytkownika do którego ma dotrzeć przelew: {endBankName}");
            listBox.Items.Add($"Opis do transakcji: {description}");
        }

        private bool CheckIfTheSameId()
        {
            if (userId == endUserId)
            {
                MessageBox.Show("Nie można dokonać transakcji na to samo konto!");
                return true;
            }

            return false;
        }

        private bool CheckOfDescriptionIsEmpty()
        {
            if (description == "")
            {
                MessageBox.Show("Opis transakcji nie może być pusty!");
                return true;
            }

            return false;
        }

        public string TypeOfTransaction(string type)
        {
            return $"Typ przelewu: {type}";
        }

        ~Transakcja()
        {
            MessageBox.Show("Likwidacja obiektu klasy Transakcja.");
        }
    }
}
