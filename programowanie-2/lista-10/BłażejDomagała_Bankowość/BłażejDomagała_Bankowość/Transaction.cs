using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    abstract class Transaction
    {
        private int id;
        private string UserFirstName = ""; // imie użytkownika wyjściowego
        private string UserLastName = ""; // nazwisko użytkownika wyjściowego
        private int UserId = 0;
        protected float AmountMoneyInAccount = 0; // ilość pieniędzy użytkownika wyjściowego

        // Dane odbiorcy
        private string endUserFirstName;
        private string endUserLastName;
        private int endUserId;

        // Dane transakcji
        private string description;
        protected bool IsCorrect;

        private Bitmap imageBitmap;

        protected Transaction()
        {
        }

        public Transaction(string endUserFirstName, string endUserLastName, int endUserId, string description, Bitmap imageBitmap)
        {
            this.endUserFirstName = endUserFirstName;
            this.endUserLastName = endUserLastName;
            this.endUserId = endUserId;
            this.description = description;
            this.imageBitmap = imageBitmap;
            this.AmountMoneyInAccount = Form1.AmountMoneyInAccount;
            this.UserFirstName = Form1.UserFirstName;
            this.UserLastName = Form1.UserLastName;
            Form1.Id++;
            this.id = Form1.Id;
        }

        public static void GetInfo(ListBox listBox, string UserFirstName, string UserLastName, int UserId, float AmountMoneyInAccount)
        {
            listBox.Items.Clear();
            listBox.Items.Add($"Dzień dobry: {UserFirstName} {UserLastName}");
            listBox.Items.Add($"Twoje ID: {UserId}");
            listBox.Items.Add($"Ilość pieniędzy w twoim banku: {AmountMoneyInAccount} PLN");
        }

        public static bool CheckIsField(string UserFirstName, string UserLastName)
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

        public virtual void CheckIsCorrect()
        {
            if (!CheckIdEndUser()) return;
            if (!CheckDescriptionNotEmpty()) return;
            if (!CheckIsImageLoaded()) return;

            IsCorrect = true;
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

        private bool CheckIsImageLoaded()
        {
            if (imageBitmap == null)
            {
                MessageTemplate(5);
                return false;
            }
            return true;
        }

        public virtual void Write(ListBox listBox)
        {
            if (!IsCorrect)
            {
                MessageTemplate(2);
                listBox.Items.Add("Przelew się nieodbyl! Pieniądze nie zostały pobrane!");
                listBox.Items.Add("");
                return;
            }

            listBox.Items.Add($"Imię i nazwisko: {UserFirstName} {UserLastName}");
            listBox.Items.Add($"Twoje ID: {UserId}");
            listBox.Items.Add($"Numer indentyfikacyjny transakcji: {id}");
            listBox.Items.Add($"Ilość pieniędzy w twoim banku: {AmountMoneyInAccount} PLN");
            listBox.Items.Add($"Imię i nazwisko odbiorcy: {endUserFirstName} {endUserLastName}");
            listBox.Items.Add($"Numer indentyfikacyjny odbiorcy: {endUserId}");
            listBox.Items.Add($"Opis do przelewu: {description}");
            listBox.Items.Add($"Data przelewu: {DateTime.Now:d}");
        }

        protected static void MessageTemplate(int n)
        {
            switch (n)
            {
                case 1:
                    MessageBox.Show(@"Nie posiadasz wystarczająco dużo pieniędzy aby wykonać przelew!");
                    break;
                case 2:
                    MessageBox.Show(@"Formularz nie został poprawnie wypełniony!");
                    break;
                case 3:
                    MessageBox.Show(@"Wartość transakcji musi być większa niż 0!");
                    break;
                case 4:
                    MessageBox.Show(@"Opis do przelewu nie może być pusty!");
                    break;
                case 5:
                    MessageBox.Show(@"Wczytaj zdjęcie do przelewu!");
                    break;
                case 6:
                    MessageBox.Show(@"Możesz zaplanować przelew z minimum jednodnowium opóźnieniem!");
                    break;
            }
        }

        public void LoadImage(PictureBox pb)
        {
            pb.Image = imageBitmap;
            IsCorrect = true;
        }

        public static void LoadImageDialog(PictureBox pb)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Bitmap f = new Bitmap(open.OpenFile());
                    pb.Image = f;
                }
            }
            catch (System.ArgumentException e)
            {
                MessageBox.Show($"Możliwe wczytywanie jest tylko zdjęć!\n\n Kod błędu: {e}");
            }
        }

        private void SaveImageToFile()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = @"JPG(*.JPG)|*.jpg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    imageBitmap.Save(saveFileDialog.FileName);
            }
            catch (System.Runtime.InteropServices.ExternalException e)
            {
                MessageBox.Show($"Bład podczas zapisu zdjęcia! Kod błędu: {e}");
            }
        }

        public virtual void WriteToFile(StreamWriter streamWriter)
        {
            SaveImageToFile();

            streamWriter.WriteLine(UserFirstName);
            streamWriter.WriteLine(UserLastName);
            streamWriter.WriteLine(UserId);
            streamWriter.WriteLine(id);
            streamWriter.WriteLine(AmountMoneyInAccount);
            streamWriter.WriteLine(endUserFirstName);
            streamWriter.WriteLine(endUserLastName);
            streamWriter.WriteLine(endUserId);
            streamWriter.WriteLine(description);
        }

        public virtual void ReadFromFile(List<string> stringList)
        {
            IsCorrect = true;

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = @"JPG(*.JPG)|*.jpg|PNG|*.png";
            open.Title = "Wczytaj zdjęcie";

            if (open.ShowDialog() == DialogResult.OK)
            {
                Bitmap f = new Bitmap(open.OpenFile());
                imageBitmap = f;
            }

            UserFirstName = stringList[1];
            UserLastName = stringList[2];
            UserId = ConvertToInt(stringList[3]);
            id = ConvertToInt(stringList[4]);
            AmountMoneyInAccount = ConvertToFloat(stringList[5]);
            endUserFirstName = stringList[6];
            endUserLastName = stringList[7];
            endUserId = ConvertToInt(stringList[8]);
            description = stringList[9];
        }
    }
}
