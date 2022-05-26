using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    class ScheduledTransfer : Transaction
    {
        private float amount;
        private bool isCorrectSt;
        private DateTime dateOfTransfer;

        public ScheduledTransfer(float amount, DateTime dateOfTransfer, string endUserFirstName, string endUserLastName, int endUserId, string description, Bitmap imageBitmap) : base(endUserFirstName, endUserLastName, endUserId, description, imageBitmap)
        {
            this.amount = amount;
            this.dateOfTransfer = dateOfTransfer;
        }
    }
}
