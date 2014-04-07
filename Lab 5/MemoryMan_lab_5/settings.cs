using System;
using System.Windows.Forms;
using System.Globalization;

namespace MemoryMan_lab_5
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        { //Событие при изменении значения NumericUpDown
            string startAdress = "0000";//Устанавливаем стартовый физ адрес
            dataGridView1.RowCount = Convert.ToInt32(numericUpDown1.Value);//Устанавливаем число строк в datagridView
            for (int i = 0; i < Convert.ToInt32(numericUpDown1.Value); i++)//Заполняем эти строки gridView
            {
                dataGridView1.Rows[i].Cells[0].Value = "Раздел " + i;
                dataGridView1.Rows[i].Cells[1].Value = "100";
                dataGridView1.Rows[i].Cells[2].Value = startAdress + "-"+(int.Parse(startAdress, NumberStyles.AllowHexSpecifier) + int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString(), NumberStyles.Integer)).ToString("X4");
                startAdress = (int.Parse(startAdress,NumberStyles.AllowHexSpecifier) + int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString(),NumberStyles.Integer)+1).ToString("X4");
            }
        }

        public Part[] GetMemStruct //Свойство возвращает массив созданых разделов памяти
        {
            get 
            {
                Part[] memParts = new Part[Convert.ToInt32(numericUpDown1.Value)];//Создаём массив разделов такой же размерности
                for (int i = 0; i < Convert.ToInt32(numericUpDown1.Value); i++)
                {
                    //Создаём i-тый раздел
                    memParts[i] = new Part(dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value), (Form1)Application.OpenForms["Form1"], dataGridView1.Rows[i].Cells[2].Value.ToString());
                }
                return memParts;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Событие срабатывает при окончании редактирования ячейки dataGridView
            //(для пересчёта адресов, если пользователь изменит размер раздела)
            string startAdress;
            //Пересчитываем логические адреса
            if(e.RowIndex-1<0)
                startAdress="0000";
            else
            {
            string[] dim=dataGridView1[2,e.RowIndex-1].Value.ToString().Split('-');
            startAdress =(int.Parse(dim[1],NumberStyles.AllowHexSpecifier)+1).ToString("X4");
            }
            for (int i = e.RowIndex; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = startAdress + "-" + (int.Parse(startAdress, NumberStyles.AllowHexSpecifier) + int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString(), NumberStyles.Integer)).ToString("X4");
                startAdress = (int.Parse(startAdress, NumberStyles.AllowHexSpecifier) + int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString(), NumberStyles.Integer) + 1).ToString("X4");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Part.IsTypeTimer = checkBox1.Checked;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.button8.Enabled = !Part.IsTypeTimer;
        }

    }
}