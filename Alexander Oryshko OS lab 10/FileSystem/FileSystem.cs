using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystem
{
    public class FileSystem
    {
        private int _clusterSize;
        private int _clusterCount;
        private string _fileName;
        private Cluster[] clusters;
        private int[] bitMask;

        List<FileEntry> Entries = new List<FileEntry>();

        public FileSystem(string fileName)
        {
            _fileName = fileName;
        }

        public void Format(int clusterCount, int clusterSize)
        {
            _clusterCount = clusterCount;
            _clusterSize = clusterSize;
            clusters = new Cluster[_clusterCount / _clusterSize];
            for (int i = 0; i < clusters.Length; i++)
            {
                clusters[i] = new Cluster();
            }
            bitMask = new int[_clusterCount / _clusterSize];
            for (int i = 0; i < bitMask.Length; i++)
            {
                bitMask[i] = 0;
            }
            Serialize();
        }

        void Deserialize()
        {
            var reader = new StreamReader("1.txt");
            string s = reader.ReadLine(); ;
            while (s != "Files&Dirs")
            {
                var lines = s.Split(new[] { ':' });
                switch (lines[0])
                {
                    case "File":
                        _fileName = lines[1];
                        break;
                    case "Size_Memory":
                        _clusterCount = Convert.ToInt32(lines[1]);
                        break;
                    case "Size_Clusters":
                        _clusterSize = Convert.ToInt32(lines[1]);
                        break;
                }
                s = reader.ReadLine();
            }
            clusters = new Cluster[_clusterCount / _clusterSize];
            while (s != "Files&Dirs_END")
            {
                //test not work
                s = reader.ReadLine();
            }
            s = reader.ReadLine();
            int i;
            while (s != "DataSegment")
            {
                s = reader.ReadLine();
                var lines = s.Split(new[] { ' ' });
                bitMask = new int[lines.Length];
                for (i = 0; i < bitMask.Length; i++)
                {
                    bitMask[i] = Convert.ToInt32(lines[i]);
                }
                s = reader.ReadLine();
            }
            i = 0;
            while (s != "DataSegment_END")
            {
                if (s != "null" && s != "DataSegment")
                {
                    clusters[i].Data = s;
                }
                i += 1;
                s = reader.ReadLine();
            }
            reader.Close();
        }

        void Serialize()
        {
            var f = new StreamWriter("1.txt");

            f.WriteLine("InfoFileSystem");
            f.WriteLine("File:{0}", _fileName);
            f.WriteLine("Size_Memory:{0}", _clusterCount);
            f.WriteLine("Size_Clusters:{0}", _clusterSize);
            f.WriteLine("Counter_Clusters:{0}", _clusterCount / _clusterSize);

            f.WriteLine("Files&Dirs");
            foreach (var fileEntry in Entries)
            {
                f.Write("{0}|{1}|", fileEntry.IsDir, fileEntry.Name);
                for (int i = 0; i < fileEntry.Clusters.Length; i++)
                {
                    f.WriteLine("{0}", fileEntry.Clusters[i]);
                    if (fileEntry.Clusters.Length - i != 1)
                    {
                        f.Write(";");
                    }
                }
            }
            f.WriteLine("Files&Dirs_END");

            f.WriteLine("BitMask");
            foreach (var b in bitMask)
            {
                f.Write(b + " ");
            }
            f.WriteLine("");
            f.WriteLine("DataSegment");

            foreach (var cluster in clusters)
            {
                if (cluster.Data == null)
                {
                    f.WriteLine("null");
                }
                else
                {
                    f.WriteLine(cluster.Data);
                }
            }
            f.WriteLine("DataSegment_END");

            f.Close();
        }

        public void CreateFile(string filename)
        {
            for (int i = 0; i < bitMask.Length; i++)
            {
                if (bitMask[i] == 0)
                {
                    var tmp = new int[1];
                    tmp[0] = i;
                    Entries.Add(new FileEntry(false, filename, tmp));
                    bitMask[i] = 2;
                    break;
                }
            }
            Serialize();
        }

        public void CreateDir(string dirname)
        {
            for (int i = 0; i < bitMask.Length; i++)
            {
                if (bitMask[i] == 0)
                {
                    var tmp = new int[1];
                    tmp[0] = i;
                    Entries.Add(new FileEntry(true, dirname, tmp));
                    clusters[i].Data = "DIR";
                    bitMask[i] = 1;
                    break;
                }
            }
            Serialize();
        }

        public string GetSizeClusters()
        {
            return Convert.ToString(_clusterSize);
        }

        public string GetSize()
        {
            return Convert.ToString(_clusterCount);
        }

        public string GetFreeClusters()
        {
            var tmp = 0;
            foreach (var cluster in clusters)
                if (cluster.Data == null)
                    tmp += 1;
            return Convert.ToString(tmp);
        }


        public string GetFreeMemory()
        {

            using (Graphics g = Main.panel1.CreateGraphics())
            {
                Pen pen = new Pen(Color.Black, 1);
                    
                Brush brush = new SolidBrush(Color.Aqua);
                int x = 0;
                int y = 0;
                int c = 0;
                bool exit = false;
                foreach (var cluster in clusters)
                {
                    g.DrawRectangle(pen, x, y, 10, 10);
                    x += 12;
                    c += 1;
                    if (c == 50)
                    {
                        c = 0;
                        x = 0;
                        y += 12;
                    }
                }

                //g.DrawRectangle(pen, 100, 100, 100, 200);
                //g.FillRectangle( brush,  );

                pen.Dispose();
            }


            var tmp = Convert.ToInt32(GetFreeClusters()) * 4;
            return Convert.ToString(tmp);
        }

        public void Loaging()
        {
            Deserialize();
        }


    }

    internal class FileEntry
    {
        public bool IsDir;
        public string Name;
        public int[] Clusters;
        public List<FileEntry> Entires = new List<FileEntry>();

        public FileEntry(bool isDir, string name, int[] clusters)
        {
            IsDir = isDir;
            Name = name;
            Clusters = clusters;
        }
    }

    internal class Cluster
    {
        public string Data;
    }
}
