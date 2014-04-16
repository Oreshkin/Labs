using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystem
{
    public partial class Formating : Form
    {
        private Main m = new Main();
        public Formating()
        {
            InitializeComponent();

        }

        private void FormatingStart_Click(object sender, EventArgs e)
        {
            Main.FileSystem.Format(Convert.ToInt32(SizeBox.Text), Convert.ToInt32(SizeClusterBox.Text));
            MessageBox.Show("Форматирование выполнено!", "Завершено!", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }
        
    }
}
