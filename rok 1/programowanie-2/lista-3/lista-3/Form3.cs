using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace lista_3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Rysuj(int n)
        {
            listBox1.Items.Clear();
            int poziom = 0;
            for (int i = 1; i <= n; i++)
            {
                var list = new List<int>();
                for(int j = 0; j <= poziom; j++)
                {
                    list.Add(i);
                }
                listBox1.Items.Add(string.Join<int>(" ", list));
                poziom++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dodatki = new Class1();
            Rysuj(dodatki.ConvertToInt(textBox1.Text));
        }
    }
}
