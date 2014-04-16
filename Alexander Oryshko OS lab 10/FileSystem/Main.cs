using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FileSystem
{
    public partial class Main : Form
    {
        public static FileSystem FileSystem = new FileSystem("FS.txt");

        public Main()
        {
            InitializeComponent();
            editFile.Enabled = false;
            saveFile.Enabled = false;
            deleting.Enabled = false;
        }

        private void форматироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Formating();
            f.Show();
            panel1.Invalidate();
            FileSystem.Clear();
            f.Closed += (o, args) => UpdateForm();
            f.Closed += (o, args) => Activate();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editFile.Enabled = false;
            editFile.Clear();
            var rand = new Random();
            int tmp = rand.Next(1, 1000);
            string filename = "Файл " + Convert.ToString(tmp);
            FileSystem.CreateFile(filename);
            UpdateForm();
        }

        private void UpdateForm()
        {
            UpdateGraf();
            UpdateInfoDir();
            Size.Text = "Объём памяти: " + FileSystem.GetSize();
            SizeClusters.Text = "Размер кластера: " + FileSystem.GetSizeClusters();
            CountsClusters.Text = "Количеcтво кластеров: " + Convert.ToString(Convert.ToInt32(FileSystem.GetSize()) / Convert.ToInt32(FileSystem.GetSizeClusters()));
            freeClusters.Text = "Свободных кластеров: " + FileSystem.GetFreeClusters();
            freeMemory.Text = "Свободно памяти: " + FileSystem.GetFreeMemory();
        }

        private void UpdateGraf()
        {
            int[] tmp = FileSystem.GetBitBock();
            using (Graphics g = panel1.CreateGraphics())
            {
                Brush free = new SolidBrush(Color.LightGreen);
                Brush file = new SolidBrush(Color.LightCoral);
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
                    if (number != 60) continue;
                    number = 0;
                    x = 0;
                    y += 12;
                }
                free.Dispose();
                file.Dispose();
                dir.Dispose();
            }
        }

        private void UpdateInfoDir()
        {
            listFile.Items.Clear();
            listFile.Clear();
            var dir = FileSystem.GetCurDir();
            List<FileEntry> tmp = dir.Entires;
            if (dir.Parent != null)
            {
                var backDir = listFile.Items.Add("Назад");
                backDir.Tag = dir.Parent;
            }
            foreach (FileEntry t in tmp)
            {
                var lvi = listFile.Items.Add(Convert.ToString(t.Name), Convert.ToString(t.IsDir));
                lvi.Tag = t;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSystem.Loaging();
            UpdateForm();
        }

        private void каталогToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            int tmp = rand.Next(1, 1000);
            string dirname = "Папка " + Convert.ToString(tmp);
            FileSystem.CreateDir(dirname);
            UpdateForm();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void listFile_DoubleClick_1(object sender, EventArgs e)
        {
            var item = listFile.SelectedItems[0];
            deleting.Enabled = true;
            var fe = (FileEntry)item.Tag;

            if (fe.IsDir)
            {
                editFile.Enabled = false;
                editFile.Clear();
                saveFile.Enabled = false;
                FileSystem.SetCurDir(fe);
                UpdateForm();
            }
            else
            {
                editFile.Enabled = true;
                saveFile.Enabled = true;
                var s = "";
                foreach (var clusterNum in fe.Clusters)
                {
                    s += FileSystem.GetClusterData(clusterNum);
                }
                editFile.Text = s;
            }
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            var file = listFile.SelectedItems[0];
            var fe = (FileEntry)file.Tag;

            if (fe.IsDir)
            {
                MessageBox.Show("Это папка!!!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            editFile.Enabled = true;

            var clusterLength = Convert.ToInt32(FileSystem.GetSizeClusters());
            int[] bitMask = FileSystem.GetBitBock();
            Cluster[] clusters = FileSystem.GetClusters();
            var curDir = FileSystem.GetCurDir();
            bool FirstBlock = true;

            ClearFile(curDir, fe, bitMask, clusters);

            for (int index = 0; index < editFile.Text.Length; index++)
            {
                string s = "";
                if (index + clusterLength <= editFile.Text.Length)
                {
                    s += editFile.Text.Substring(index, clusterLength);

                    if (FirstBlock)
                    {
                        WriteFirstBlock(curDir, fe, clusters, s);
                        FirstBlock = false;
                    }
                    else
                    {
                        WriteFile(curDir, fe, bitMask, clusters, s);                        
                    }

                    index += clusterLength;
                }
                else
                {
                    s += editFile.Text.Substring(index, editFile.Text.Length - index);

                    if (FirstBlock)
                    {
                        WriteFirstBlock(curDir, fe, clusters, s);
                        FirstBlock = false;
                    }
                    else
                    {
                        WriteFile(curDir, fe, bitMask, clusters, s);
                    }

                    index += editFile.Text.Length - index;
                }

            }
            editFile.Clear();
            editFile.Enabled = false;
            UpdateForm();
        }

        private void ClearFile(FileEntry curDir, FileEntry fe, int[] bitMask, Cluster[] clusters)
        {
            for (int i = 0; i < curDir.Entires.Count; i++)
            {
                if (curDir.Entires[i].Name == fe.Name)
                {
                    var tmpNumClu = new int[curDir.Entires[i].Clusters.Length];

                    Array.Copy(curDir.Entires[i].Clusters, tmpNumClu, curDir.Entires[i].Clusters.Length);

                    clusters[tmpNumClu[0]].Data = null;

                    for (int index = 1; index < tmpNumClu.Length; index++)
                    {
                        var bit = tmpNumClu[index];
                        bitMask[bit] = 0;
                        clusters[bit].Data = null;
                    }

                    tmpNumClu = new[] {tmpNumClu[0]};

                    Array.Resize(ref curDir.Entires[i].Clusters, tmpNumClu.Length);

                    Array.Copy(tmpNumClu, curDir.Entires[i].Clusters, tmpNumClu.Length);

                    break;
                }
            }
            UpdateForm();
        }

        private void WriteFirstBlock(FileEntry curDir, FileEntry fe, Cluster[] clusters, string s)
        {
            foreach (var fileEntry in curDir.Entires)
            {
                if (fileEntry.Name == fe.Name)
                {
                    var FC = fileEntry.Clusters[0];
                    clusters[FC].Data = s;
                    break;
                }
            }
        }

        private void WriteFile(FileEntry curDir, FileEntry fe, int[] bitMask, Cluster[] clusters, string s)
        {
            foreach (var fileEntry in curDir.Entires)
            {
                if (fileEntry.Name == fe.Name)
                {
                    for (int i = 0; i < bitMask.Length; i++)
                    {
                        var bit = bitMask[i];
                        if (bit == 0)
                        {
                            var tmpNumClu = new int[fileEntry.Clusters.Length + 1];
                            Array.Copy(fileEntry.Clusters, tmpNumClu, fileEntry.Clusters.Length);

                            tmpNumClu[tmpNumClu.Length - 1] = i;

                            clusters[i].Data = s;
                            bitMask[i] = 2;

                            Array.Resize(ref fileEntry.Clusters, tmpNumClu.Length);
                            
                            Array.Copy(tmpNumClu, fileEntry.Clusters, tmpNumClu.Length);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            editFile.Clear();
        }

        private void deleting_Click(object sender, EventArgs e)
        {
            var file = listFile.SelectedItems[0];
            var fe = (FileEntry)file.Tag;

            Cluster[] clusters = FileSystem.GetClusters();
            int[] bitMask = FileSystem.GetBitBock();
            var curDir = FileSystem.GetCurDir();

            for (int i = 0; i < curDir.Entires.Count; i++)
            {
                if (curDir.Entires[i].Name == fe.Name)
                {
                    var tmpNumClu = new int[curDir.Entires[i].Clusters.Length];

                    Array.Copy(curDir.Entires[i].Clusters, tmpNumClu, curDir.Entires[i].Clusters.Length);

                    for (int index = 0; index < tmpNumClu.Length; index++)
                    {
                        var bit = tmpNumClu[index];
                        bitMask[bit] = 0;
                        clusters[bit].Data = null;

                    }

                    curDir.Entires.Remove(curDir.Entires[i]);
                    break;
                }
            }
            deleting.Enabled = false;
            UpdateForm();
        }

    }
}