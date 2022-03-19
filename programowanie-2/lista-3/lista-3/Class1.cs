using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lista_3
{
    class Class1
    {
        public int ConvertToInt(string str)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd! Wprowadzono niepoprawny typ danych!");
                return 0;
            }
        }
    }
}
