using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FileSystem
{
    public partial class Main : Form
    {
        public static FileSystem FileSystem = new FileSystem( "FS.txt" );

        public Main()
        {
            InitializeComponent();
        }

        private void форматироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Formating();
            f.Show();
            f.Closed += (o, args) => UpdateForm();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            int tmp = rand.Next(1, 1000);
            string filename = "Файл " + Convert.ToString(tmp);


            FileSystem.CreateFile( filename );
            UpdateForm();

            
        }

        private void UpdateForm()
        {
            Size.Text = "Объём памяти: " + FileSystem.GetSize();
            SizeClusters.Text = "Размер кластера: " + FileSystem.GetSizeClusters();
            CountsClusters.Text = "Количеcтво кластеров: " + Convert.ToString(Convert.ToInt32(FileSystem.GetSize()) / Convert.ToInt32(FileSystem.GetSizeClusters()));
            freeClusters.Text = "Свободных кластеров: " + FileSystem.GetFreeClusters();
            freeMemory.Text = "Свободно памяти: " + FileSystem.GetFreeMemory();


            //   var e = _fileSystem.GetEntires();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSystem.Loaging();
            UpdateForm();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void каталогToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            int tmp = rand.Next(1, 1000);
            string dirname = "Папка " + Convert.ToString(tmp);
            FileSystem.CreateDir(dirname);
            UpdateForm();
        }

    }
}
