using System;
using System.Drawing;
using System.Windows.Forms;

namespace FileSystem
{
    public partial class Defrag : Form
    {
        public Defrag()
        {
            InitializeComponent();
            UpdateGraf(panel1);
        }

        private void check_Click(object sender, EventArgs e)
        {
            var count = GetFileCount(Main.FileSystem.GetRootDir(), 0);
            progressBar.Maximum = count;
            string s = Main.FileSystem.Defrag(Main.FileSystem.GetRootDir(), progressBar);
            info.Text = s;
            UpdateGraf(panel2);
            MessageBox.Show("Операция завершена!", "Defrag", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private int GetFileCount(FileEntry getRootDir, int i)
        {
            foreach (var fileEntry in getRootDir.Entires)
            {
                i += 1;
                if (fileEntry.IsDir)
                    GetFileCount(fileEntry, i);
            }
            return i;
        }

        private void UpdateGraf(Panel panel)
        {
            var tmp = FileSystem.GetBitBock();
            var bmp = new Bitmap(panel.Width, panel.Height);
            panel.BackgroundImage = bmp;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Brush free = new SolidBrush(Color.Chartreuse);
                Brush file = new SolidBrush(Color.CornflowerBlue);
                Brush dir = new SolidBrush(Color.Orange);
                int x = 0;
                int y = 0;
                int number = 0;
                foreach (var bit in tmp)
                {
                    switch (bit)
                    {
                        case 0:
                            g.FillRectangle(free, x, y, 10, 10);
                            break;
                        case 1:
                            g.FillRectangle(dir, x, y, 10, 10);
                            break;
                        case 2:
                            g.FillRectangle(file, x, y, 10, 10);
                            break;
                    }
                    x += 12;
                    number += 1;
                    if (number != 79) continue;
                    number = 0;
                    x = 0;
                    y += 12;
                }
                free.Dispose();
                file.Dispose();
                dir.Dispose();
            }
        }

    }
}
