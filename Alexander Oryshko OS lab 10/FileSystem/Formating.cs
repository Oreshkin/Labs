using System;
using System.Windows.Forms;

namespace FileSystem
{
    public partial class Formating : Form
    {
        public Formating()
        {
            InitializeComponent();
        }

        private void FormatingStart_Click(object sender, EventArgs e)
        {
            try
            {
                Main.FileSystem.Format(Convert.ToInt32(SizeBox.Text), Convert.ToInt32(SizeClusterBox.Text));
                Main.FileSystem.Clear();
                for (int i = 0; i < 100; i++)
                    progressBar1.Increment(1);
                MessageBox.Show("Форматирование выполнено!", "Завершено!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close(); 
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно введенные данные!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SizeClusterBox_Click(object sender, EventArgs e)
        {
            SizeClusterBox.Text = "2";
        }
        
    }
}
