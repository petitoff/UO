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

        private int userId;
        private string userFirstName;
        private string userLastName;

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
    }
}
