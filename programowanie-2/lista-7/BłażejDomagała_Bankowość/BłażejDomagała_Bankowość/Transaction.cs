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

        public Transaction()
        {
            id += 1;
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

        public virtual void Write(ListBox listBox)
        {
            listBox.Items.Add($"Imię i nazwisko: {UserFirstName} {UserLastName}");
            listBox.Items.Add($"Twoje ID: {UserId}");
            listBox.Items.Add($"Numer indentyfikacyjny transakcji: {id}");
            listBox.Items.Add($"Ilość pieniędzy w twoim banku: {AmountMoneyInAccount} PLN");
        }
    }
}
