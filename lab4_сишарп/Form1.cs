using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4_сишарп
{
    public partial class Form1 : Form
    {

        List<string> split_text = new List<string>();

        public Form1()
        {
            InitializeComponent();

            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd1 = new OpenFileDialog();
            ofd1.Filter = "Text files(*.txt)|*.txt";
            if (ofd1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Необходимо выбрать файл");
                return;
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(ofd1.FileName);
            //добавляем разделители
            char[] separators = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };
            //получаем список слов
            string[] split_text_temp = fileText.Split(separators);
            //убираем дубликаты
            
            foreach (string str in split_text_temp)
            {
                if (!split_text.Contains(str))
                    split_text.Add(str);
            }

            stopWatch.Stop();
            this.textBox1.Text = stopWatch.Elapsed.ToString();
            //this.textBoxFileReadCount.Text = list.Count.ToString();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

       


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //определяем слово для поиска в нижнем регистре
            string word = this.textBox2.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(word) || split_text.Count == 0)
            {
                MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
                return;
            }

            //Временные результаты поиска
            List<string> find_list = new List<string>();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (string str in split_text)
            {
                if (str.ToLower().Contains(word))
                {
                    find_list.Add(str);
                }
            }
            stopWatch.Stop();
            this.textBox3.Text = stopWatch.Elapsed.ToString();

            this.listBox1.BeginUpdate();

            //Очистка списка
            this.listBox1.Items.Clear();

            //Вывод результатов поиска 
            foreach (string str in find_list)
            {
                this.listBox1.Items.Add(str);
            }
            this.listBox1.EndUpdate();


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
