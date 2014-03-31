using System;
using System.Windows.Forms;

namespace MemoryMan_lab_5
{
    public partial class NewProcess : Form
    {
        private Part[] Parts;

        public NewProcess(Part[] Parts)
        {
            InitializeComponent();
            this.Parts = Parts; //Инициализируем ссылку на массив разделов
            for (int i = 0; i < Parts.Length; i++)
                comboBox1.Items.Add(Parts[i].Name);
            comboBox1.SelectedIndex = 0;
        }

        public string GetInfo //свойство; возвращает строку с информацией о процессе
        {
            get
            {
                return textBox1.Text + "," + numericUpDown1.Value + "," + numericUpDown2.Value + "," + comboBox1.Text;
            }
        }


        public int GetPart
        {
            get { return comboBox1.Items.IndexOf(comboBox1.Text); }
        }

        private void NewProcess_Load(object sender, EventArgs e)
        {
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}