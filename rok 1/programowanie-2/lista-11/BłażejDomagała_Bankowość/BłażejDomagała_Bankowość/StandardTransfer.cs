﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    class StandardTransfer : Transaction
    {
        //private List<string> Categories = new List<string> { "Jedzenie", "Zakupy", "Paliwo" };
        private float amount;
        private string currency;
        private float usdPrice = 3.5F;
        private float eurPrice = 4.3F;
        private string categories;
        public bool isCorrectSt;

        public float a;
        public bool b;

        public bool FileCorrectOperation;
        public StandardTransfer()
        {

        }

        public StandardTransfer(float a)
        {
            this.a = a;
        }

        public StandardTransfer(string endUserFirstName, string endUserLastName, int endUserId, float amount, string currency, string description, string categories, Bitmap imageBitmap, float AmountMoneyInAccount) : base(endUserFirstName, endUserLastName, endUserId, description, imageBitmap)
        {
            this.amount = amount;
            this.currency = currency;
            this.categories = categories;
        }

        public override float GetAmount()
        {
            return amount;
        }

        private bool ConvertCurrency()
        {

            if (currency == "PLN")
            {
                if (!base.CheckIsThereEnoughMoney(amount))
                {
                    MessageTemplate(1);
                    return false;
                }
                return true;
            }

            if (currency == "USD")
            {
                if (!base.CheckIsThereEnoughMoney(amount * usdPrice))
                {
                    MessageTemplate(1);
                    return false;
                }
                return true;
            }

            if (currency == "EUR")
            {
                if (!base.CheckIsThereEnoughMoney(amount * eurPrice))
                {
                    MessageTemplate(1);
                    return false;
                }
                return true;
            }

            return false;
        }

        public override void CheckIsCorrect()
        {
            base.CheckIsCorrect(); // walidacja z kalsy bazowej
            if (!base.IsCorrect) return; // jeżeli nie przebiegła pomyślnie to wstrzymaj działanie programu

            if (amount == 0)
            {
                // jeżeli użytkownik próbuje dokonać przelewu na kwotę 0 to wyrzuć wyjątek
                MessageTemplate(3);
                return;
            }
            if (!ConvertCurrency()) return;

            if (currency == "USD") amount *= usdPrice;
            if (currency == "EUR") amount *= eurPrice;
            base.AmountMoneyInAccount -= amount;
            Form1.AmountMoneyInAccount = base.AmountMoneyInAccount;
            isCorrectSt = true;
        }

        private DateTime WhenTransactionWillBeCompleted()
        {
            return DateTime.Now.AddDays(2).Date;
        }

        public override void Write(ListBox listBox)
        {
            if (!isCorrectSt)
            {
                MessageTemplate(2);
                listBox.Items.Add("Przelew się nieodbyl! Pieniądze nie zostały pobrane!");
                return;
            }

            if (!base.IsCorrect) return;
            base.Write(listBox);
            listBox.Items.Add($"Kwota transakcji: {amount} {currency}");
            listBox.Items.Add($"Przelew zostanie zrealizowany w ciągu 2 dni roboczych: {WhenTransactionWillBeCompleted():dd/MM/yyyy}");
            listBox.Items.Add($"Kategoria przelewu: {categories}");
            listBox.Items.Add($"Typ przelewu: Przelew zwykły");
            listBox.Items.Add("");
        }

        public static StandardTransfer operator ==(StandardTransfer standardTransfer1,
            StandardTransfer standardTransfer2)
        {
            StandardTransfer standardTransfer = new StandardTransfer();
            if (standardTransfer1.a == standardTransfer2.a) standardTransfer.b = false;
            else standardTransfer.b = true;

            return standardTransfer;
        }

        public static StandardTransfer operator !=(StandardTransfer standardTransfer1,
            StandardTransfer standardTransfer2)
        {
            float usdPrice = 3.5f;
            StandardTransfer standardTransfer = new StandardTransfer();

            if ((standardTransfer1.a * usdPrice) == standardTransfer2.a) standardTransfer.b = true;
            else standardTransfer.b = false;

            return standardTransfer;
        }

        public static StandardTransfer operator *(StandardTransfer standardTransfer1,
            StandardTransfer standardTransfer2)
        {
            StandardTransfer sum = new StandardTransfer();
            sum.a = standardTransfer1.a * (standardTransfer2.a / 100);

            return sum;
        }

        public override void WriteToFile(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("--------------------");
            streamWriter.WriteLine("Standardowy transfer");

            base.WriteToFile(streamWriter);

            streamWriter.WriteLine(amount);
            streamWriter.WriteLine(currency);
            streamWriter.WriteLine(categories);

            streamWriter.WriteLine("");
        }

        public override void ReadFromFile(List<string> stringList)
        {
            try
            {
                base.ReadFromFile(stringList);
                amount = ConvertToFloat(stringList[10]);
                currency = stringList[11];
                categories = stringList[12];

                if (amount == -1) return;
                isCorrectSt = true;
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                MessageBox.Show($"Błąd przy wczytywaniu pliku!\n\n Kod błędu {e}");
            }
        }
    }
}
