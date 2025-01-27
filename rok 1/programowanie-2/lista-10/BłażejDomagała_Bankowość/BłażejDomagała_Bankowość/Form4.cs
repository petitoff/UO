﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private int indexStart; // wielkość listy Program.Transactions
        private int index; // aktualny wybrany index z listy Program.Transactions

        private void UpdateIndex()
        {
            indexStart = Program.Transactions.Count - 1;
            index = indexStart;
        }

        private void Execute()
        {
            // metoda ładuje z listy Program.Transactions odpowiednie metody za pomocą polimorfizmu
            // metoda posiada walidacje dzięki której jeżeli dany index nie istnieje to nie powoduje to błędu programu
            try
            {
                listBox1.Items.Clear();
                Program.Transactions[index].Write(listBox1);
                Program.Transactions[index].LoadImage(pictureBox1);

                button2.Enabled = true;
                button3.Enabled = true;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show(@"Nie posiadasz żadych transakcji do wyświetlenia!");
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Execute();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index - 1 < 0)
            {
                button3.Enabled = true;
                MessageBox.Show("Nie posiadasz już więcej transakcji do przeglądania!");
                button2.Enabled = false;
                return;
            }
            index--;
            Execute();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (index + 1 > indexStart)
            {
                MessageBox.Show("Nie posiadasz już więcej transakcji do przeglądania!");
                button3.Enabled = false;
                return;
            }
            index++;
            Execute();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            UpdateIndex();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Plik tekstowy|*.txt";
            saveFileDialog.Title = "Podaj nazwę pliku do zapisu danych";

            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                foreach (Transaction transaction in Program.Transactions)
                {
                    transaction.WriteToFile(streamWriter);
                }
                streamWriter.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Plik tekstowy|*.txt";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            StreamReader streamReader = new StreamReader(openFileDialog.FileName);
            List<string> lineOfText = new List<string>();

            string line;
            bool first = true;
            bool temp1 = false;
            bool temp2 = false;
            bool temp3 = false;

            while ((line = streamReader.ReadLine()) != null)
            {
                if (first)
                {
                    first = false; continue;
                }

                if (line == "")
                {
                    temp1 = false;
                    if (temp2)
                    {
                        StandardTransfer standardTransfer = new StandardTransfer();
                        standardTransfer.ReadFromFile(lineOfText);
                        if (standardTransfer.isCorrectSt)
                            Program.Transactions.Add(standardTransfer);

                        lineOfText.Clear();
                    }
                }

                if (line == "")
                {
                    temp1 = false;
                    if (temp3)
                    {
                        ScheduledTransfer scheduledTransfer = new ScheduledTransfer();
                        scheduledTransfer.ReadFromFile(lineOfText);

                        if (scheduledTransfer.isCorrectSt)
                            Program.Transactions.Add(scheduledTransfer);

                        lineOfText.Clear();
                    }
                }

                if (line == "Standardowy transfer")
                {
                    temp1 = true;
                    temp2 = true;
                    temp3 = false;
                }

                if (line == "Zaplanowany transfer")
                {
                    temp1 = true;
                    temp2 = false;
                    temp3 = true;
                }

                if (temp1 && temp2)
                {
                    lineOfText.Add(line);
                }

                if (temp1 && temp3)
                {
                    lineOfText.Add(line);
                }


                //lineOfText.Add(line);


            }
            UpdateIndex();
            MessageBox.Show("Wczytywanie zakończone!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Program.Transactions.Count == 0)
            {
                MessageBox.Show("Brak obiektu do usunięcia!");
                return;
            }

            Program.Transactions.RemoveAt(index);
            UpdateIndex();
            listBox1.Items.Clear();
            pictureBox1.Image = null;
            MessageBox.Show("Pomyślnie usunięto obiekt!");
        }
    }
}
