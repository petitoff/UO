using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    abstract class Transaction
    {
        // Global variables
        public static int id = -1; // id transakcji
        public static string UserFirstName = ""; // imie użytkownika wyjściowego
        public static string UserLastName = ""; // nazwisko użytkownika wyjściowego
        public static int UserId = 0;
        public static float AmountMoneyInAccount = 0; // ilośc pieniędzy użytkownika wyjściowego

        // Dane odbiorcy
        private string endUserFirstName;
        private string endUserLastName;
        private int endUserId;

        // Dane transakcji
        private string description;
        protected bool isCorrect;

        public Transaction()
        {
            id += 1;
        }

        public Transaction(string endUserFirstName, string endUserLastName, int endUserId, string description)
        {
            id += 1;
            this.endUserFirstName = endUserFirstName;
            this.endUserLastName = endUserLastName;
            this.endUserId = endUserId;
            this.description = description;
        }

        public static void GetInfo(ListBox listBox)
        {
            listBox.Items.Clear();
            listBox.Items.Add($"Dzień dobry: {UserFirstName} {UserLastName}");
            listBox.Items.Add($"Twoje ID: {UserId}");
            listBox.Items.Add($"Ilość pieniędzy w twoim banku: {AmountMoneyInAccount} PLN");
        }

        public static bool CheckIsField()
        {
            if (UserFirstName.Length != 0 && UserLastName.Length != 0)
            {
                return true;
            }
            MessageBox.Show(@"Wypełnij dane zanim przejdziesz do przelewu!");
            return false;
        }

        public static int ConvertToInt(string s)
        {
            try
            {
                return int.Parse(s);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Wprowadź liczbę!");
                return -1;
            }
        }

        public static float ConvertToFloat(string s)
        {
            try
            {
                return float.Parse(s);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Wprowadź liczbę!");
                return -1;
            }
        }

        protected bool CheckIsThereEnoughMoney(float amount)
        {
            if (AmountMoneyInAccount - amount < 0) return false;
            return true;
        }

        private bool CheckIsCorrect()
        {
            if (!CheckIdEndUser()) return false;
            if (!CheckDescriptionNotEmpty()) return false;

            return true;
        }

        private bool CheckIdEndUser()
        {
            if (UserId == endUserId)
            {
                MessageBox.Show(@"Nie można dokonać przelewu na to samo konto!");
                return false;
            }
            return true;
        }

        private bool CheckDescriptionNotEmpty()
        {
            if (description.Length == 0)
            {
                MessageTemplate(4);
                return false;
            }

            return true;
        }

        public virtual void Write(ListBox listBox)
        {
            if (!CheckIsCorrect())
            {
                MessageTemplate(2);
                listBox.Items.Add("Przelew się nieodbyl! Pieniądze nie zostały pobrane!");
                listBox.Items.Add("");
                return;
            }

            isCorrect = true;

            listBox.Items.Add($"Imię i nazwisko: {UserFirstName} {UserLastName}");
            listBox.Items.Add($"Twoje ID: {UserId}");
            listBox.Items.Add($"Numer indentyfikacyjny transakcji: {id}");
            listBox.Items.Add($"Ilość pieniędzy w twoim banku: {AmountMoneyInAccount} PLN");
            listBox.Items.Add($"Imię i nazwisko odbiorcy: {endUserFirstName} {endUserLastName}");
        public void MessageTemplate(int n)
        {
            if (n == 1) MessageBox.Show(@"Nie posiadasz wystarczająco dużo pieniędzy aby wykonać przelew!");
            if (n == 2) MessageBox.Show(@"Formularz nie został poprawnie wypełniony!");
            if (n == 3) MessageBox.Show(@"Wartość transakcji musi być większa niż 0!");
            if (n == 4) MessageBox.Show(@"Opis do przelewu nie może być pusty!");
        }
    }
}
