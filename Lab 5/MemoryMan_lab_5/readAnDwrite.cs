using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace MemoryMan_lab_5
{
    public partial class readAnDwrite : Form
    {
        Form1 Form;//ссылка на главную форму
        public readAnDwrite(Form1 f)
        {
            Form = f;
            
            InitializeComponent();
        }

        private void readAnDwrite_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Form.Parts.Length; i++)//Заполняется разделами выпадающий список
            {
                comboBox1.Items.Add(Form.Parts[i].Name);
            }
            comboBox1.SelectedIndex = 0;
            label1.Text = "Физическое адресное пространство: " + Form.Parts[0].StartSegmentAdress + "-" + Form.Parts[Form.Parts.Length-1].EndSegmentAdress;
        }

        private void button1_Click(object sender, EventArgs e)
        { //событие по нажатию на кнопку Запись
            //Записываем значение, находящееся в textBox2, в раздел comboBox1.SelectedIndex, по логическому адресу Convert.ToInt32(textBox1.Text)
            Form.Parts[comboBox1.SelectedIndex].memory[Convert.ToInt32(textBox1.Text)] = Convert.ToByte(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //событие по нажатию на кнопку Чтение
            //Читаем значение по логическому адресу Convert.ToInt32(textBox1.Text) в разделе Form.Parts[comboBox1.SelectedIndex]
            textBox2.Text = Form.Parts[comboBox1.SelectedIndex].memory[Convert.ToInt32(textBox1.Text)].ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //при изменеии значения логического адреса
            textBox2.Clear();
            if(textBox1.Text!="")
            label5.Text = "Физический адресс: " + (int.Parse(Form.Parts[comboBox1.SelectedIndex].StartSegmentAdress, NumberStyles.AllowHexSpecifier)+Convert.ToInt32(textBox1.Text)).ToString("X4");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
