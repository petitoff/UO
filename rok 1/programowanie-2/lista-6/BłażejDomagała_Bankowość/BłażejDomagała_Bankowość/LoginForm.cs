using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    public partial class LoginForm : Form
    {
        public string login = "Błażej";
        public string password = "Domagala";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckLogin())
            {
                LoginCorrect();
            }
            else
            {
                LoginNotCorrect();
            }
        }

        private bool CheckLogin()
        {
            if(textBox1.Text == login && textBox2.Text == password)
            {
                return true;
            }
            return false;
        }

        private void LoginCorrect()
        {
            label4.ForeColor = System.Drawing.Color.Green;
            label4.Text = "Login Poprawny!";

            Form form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void LoginNotCorrect()
        {
            label4.ForeColor = System.Drawing.Color.Red;
            label4.Text = "Niepoprawny!";
        }
    }
}
