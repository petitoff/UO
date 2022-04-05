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
        private string nameOfBank = "eBank";
        private string currency = "PLN";
        private float amount;
        private int id; // indentyfikator transakcji
        private int idUser; // indentyfikator użytkownika
        private string firstNameUser;
        private string lastNameUser;
        private string dateOfTransaction;
        private int idUserDestination;
        private string firstNameUserDestination;
        private string lastNameUserDestination;
        private string nameOfBankDestination;
        private string description;


        public Transakcja()
        {
            // Konstruktor bezargumentowy
            this.nameOfBank = "eBank";
            this.currency = "PLN";
            this.amount = 120.50F;
            this.id = 2;
            this.idUser = 37128;
            this.firstNameUser = "Jan";
            this.lastNameUser = "Kowalski";
            this.dateOfTransaction = CalcuteNow();
            this.idUserDestination = 27431;
            this.firstNameUserDestination = "Dariusz";
            this.lastNameUserDestination = "Nowak";
            this.nameOfBankDestination = "mBank";
            this.description = "Przelew";
        }

        public Transakcja(string nameOfBank, string currency, float amount, int id, int idUser, string firstNameUser,string lastNameUser, string dateOfTransaction, int idUserDestination, string firstNameUserDestination, string lastNameUserDestination, string nameOfBankDestination, string description)
        {
            // Konstruktor wieloargumentowy
            this.nameOfBank = nameOfBank;
            this.currency = currency;
            this.amount = amount;
            this.id = id;
            this.idUser = idUser;
            this.firstNameUser = firstNameUser;
            this.lastNameUser = lastNameUser;
            this.dateOfTransaction = dateOfTransaction;
            this.idUserDestination = idUserDestination;
            this.firstNameUserDestination = firstNameUserDestination;
            this.lastNameUserDestination = lastNameUserDestination;
            this.nameOfBankDestination = nameOfBankDestination;
            this.description = description;
        }

        public Transakcja(Transakcja t)
        {
            this.nameOfBank = t.nameOfBank;
            this.currency = t.currency;
            this.amount = t.amount;
            this.id = t.id;
            this.idUser = t.idUser;
            this.firstNameUser = t.firstNameUser;
            this.lastNameUser = t.lastNameUser;
            this.dateOfTransaction = t.dateOfTransaction;
            this.idUserDestination = t.idUserDestination;
            this.firstNameUserDestination = t.firstNameUserDestination;
            this.lastNameUserDestination = t.lastNameUserDestination;
            this.nameOfBankDestination = t.nameOfBankDestination;
            this.description = t.description;
        }

        public void Write(ListBox listBox)
        {
            listBox.Items.Add($"Nazwa banku: {nameOfBank}");
            listBox.Items.Add($"Nazwa waluty: {currency}");
            listBox.Items.Add($"Kwota transakcji: {amount}");
            listBox.Items.Add($"Numer indentyfikacyjny transakcji: {id}");
            listBox.Items.Add($"Numer indentyfikacyjny użytkownika wysyłającego: {idUser}");
            listBox.Items.Add($"Imię użytkownika wysyłającego: {firstNameUser}");
            listBox.Items.Add($"Nazwisko użytkownika wysyłającego: {firstNameUser}");
            listBox.Items.Add($"Data wykonania transakcji: {dateOfTransaction}");
            listBox.Items.Add($"Numer indentyfikacyjny użytkownika do którego ma dotrzeć przelew: {idUserDestination}");
            listBox.Items.Add($"Imię użytkownika do którego ma dotrzeć przelew: {firstNameUserDestination}");
            listBox.Items.Add($"Nazwisko użytkownika do którego ma dotrzeć przelew: {lastNameUserDestination}");
            listBox.Items.Add($"Nazwa banku użytkownika do którego ma dotrzeć przelew: {nameOfBankDestination}");
            listBox.Items.Add($"Opis do transakcji: {description}");
        }

        private string CalcuteNow()
        {
            string dateString1 = DateTime.Now.ToString("dd-MM-yyyy");
            return dateString1;
        }

        ~Transakcja()
        {
            MessageBox.Show("Likwidacja obiektu klasy Transakcja.");
        }
    }
}
