using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    internal class PrzelewZwykly : Transakcja
    {
        private float amount;
        private float amountMoneyInAccount;
        bool isCorrect;
        string typeOfTransaction;

        public PrzelewZwykly() : base()
        {
            amount = 200;
            amountMoneyInAccount = 2000;
            isCorrect = true;
            typeOfTransaction = "przelew zwykły";
        }

        public PrzelewZwykly(float amount, float amountMoneyInAccount, string typeOfTransaction) : base()
        {
            this.amount = amount;
            this.amountMoneyInAccount = amountMoneyInAccount;
            //this.isCorrect = isCorrect;
            this.typeOfTransaction = typeOfTransaction;
        }

        public PrzelewZwykly(PrzelewZwykly pz)
        {
            this.amount = pz.amount;
            this.amountMoneyInAccount = pz.amountMoneyInAccount;
            this.isCorrect = pz.isCorrect;
        }

        public new void Write(ListBox listBox)
        {
            var transakcja = new Transakcja();

            isCorrect = IfThereIsEnoughMoney();
            if (!IsCorrectValidation()) return;

            base.Write(listBox);

            listBox.Items.Add($"kwota transakcji {amount}");
            listBox.Items.Add($"ilość pieniędzy na twoim koncie {amountMoneyInAccount}");
            listBox.Items.Add($"czy transakcja może zostać wykonana {(isCorrect ? "tak" : "nie")}");
            listBox.Items.Add(transakcja.TypeOfTransaction(typeOfTransaction));
        }

        private bool IsCorrectValidation()
        {
            if (!isCorrect)
            {
                MessageBox.Show("Przelew nie może zostać wykonany!");
                return false;
            }

            return true;
        }

        private bool IfThereIsEnoughMoney()
        {
            if (amount > amountMoneyInAccount)
                return false;
            return true;
        }
    }
}
