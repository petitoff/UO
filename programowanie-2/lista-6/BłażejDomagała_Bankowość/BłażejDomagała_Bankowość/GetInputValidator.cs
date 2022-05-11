using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    class GetInputValidator
    {
        public static float ConvertToFloat(string s)
        {
            try
            {
                return Single.Parse(s);

            }
            catch (Exception)
            {
                MessageBox.Show("Błąd! Wprowadź liczby zamiast tekstu!");
                return 0;
            }
        }

        public static DateTime GetOnlyDDMMYYY(DateTimePicker dateTimePicker)
        {
            return Convert.ToDateTime(dateTimePicker.Value.ToShortDateString()); ;
        }
    }
}
