using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    class ScheduledTransfer : Transaction
    {
        private float amount;
        public bool isCorrectSt;
        private DateTime dateOfTransfer;

        public ScheduledTransfer(float amount, DateTime dateOfTransfer, string endUserFirstName, string endUserLastName, int endUserId, string description, Bitmap imageBitmap) : base(endUserFirstName, endUserLastName, endUserId, description, imageBitmap)
        {
            this.amount = amount;
            this.dateOfTransfer = dateOfTransfer;
        }

        public override void CheckIsCorrect()
        {
            base.CheckIsCorrect();
            if (!base.IsCorrect) return; // jeżeli nie przebiegła pomyślnie to wstrzymaj działanie programu

            if (amount == 0)
            {
                // jeżeli użytkownik próbuje dokonać przelewu na kwotę 0 to wyrzuć wyjątek
                MessageTemplate(3);
                return;
            }

            if (!base.CheckIsThereEnoughMoney(amount))
            {
                MessageTemplate(1);
                return;
            }

            if (dateOfTransfer.Day - DateTime.Now.Day <= 1)
            {
                MessageTemplate(6);
                return;
            }

            base.AmountMoneyInAccount -= amount;
            Form1.AmountMoneyInAccount = base.AmountMoneyInAccount;
            isCorrectSt = true;
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
            listBox.Items.Add($"Kwota transakcji: {amount} PLN");
            listBox.Items.Add($"Typ przelewu: Przelew stały");
            listBox.Items.Add($"Data kiedy przelew zostanie zrealizowany: {dateOfTransfer:d}");
            listBox.Items.Add("");
        }

        public override void WriteToFile(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("--------------------");
            streamWriter.WriteLine("Zaplanowany transfer");

            base.WriteToFile(streamWriter);
            streamWriter.WriteLine($"Kwota transakcji: {amount} PLN");
            streamWriter.WriteLine($"Typ przelewu: Przelew stały");
            streamWriter.WriteLine($"Data kiedy przelew zostanie zrealizowany: {dateOfTransfer:d}");
            streamWriter.WriteLine("");
        }
    }
}
