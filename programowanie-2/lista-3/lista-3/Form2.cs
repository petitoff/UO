using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lista_3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //listBox1.Items.Add("ad");
            //listBox1.Items.Remove("ad");
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dodatki = new Class1();
            WypisywanieSzachownicy(dodatki.ConvertToInt(textBox1.Text));
        }

        private void WypisywanieSzachownicy(int a)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < a; i++)
            {
                var list = new List<int>();
                int znak;
                if (i % 2 == 0)
                {
                    znak = 0;
                }
                else
                {
                    znak = 1;
                }

                for (int j = 0; j < a; j++)
                {
                    if (znak == 0)
                    {
                        list.Insert(0, 0);
                        znak = 1;
                    }
                    else
                    {
                        list.Insert(0, 1);
                        znak = 0;
                    }

                }
                listBox1.Items.Add(string.Join<int>(" ", list));
            }
        }
    }
}
