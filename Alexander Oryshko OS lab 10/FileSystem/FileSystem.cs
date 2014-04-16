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
        private FileEntry _CurrentDir;
        private Cluster[] clusters;
        private int[] bitMask;

        private FileEntry root = new FileEntry(true, "\\" , new int[] {0}, null );

        public void SetCurDir(FileEntry Dir)
        {
            _CurrentDir = Dir;
        }

        public FileEntry GetCurDir()
        {
            if (_CurrentDir == null)
            {
                return root;
            }
            return _CurrentDir;
        }


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
            clusters[0].Data = "DIR";
            bitMask = new int[_clusterCount / _clusterSize];
            bitMask[0] = 1;
            for (int i = 1; i < bitMask.Length; i++)
            {
                bitMask[i] = 0;
            }
            Serialize();
        }



        private void Deserialize(FileEntry fileEntry, StreamReader f, string s)
        {
            var lines = s.Split(new[] { '|' });
            var lines_3 = lines[2].Split(new[] { ';' });

            var tmp = new int[Convert.ToInt32(lines_3.Length)];

            for (int j = 0; j < tmp.Length; j++)
            {
                tmp[j] = Convert.ToInt32(lines_3[j]);
            }

            var FD = new FileEntry(Convert.ToBoolean(lines[0]), lines[1], tmp, null);

            fileEntry.Entires.Add(FD);
            
            s = f.ReadLine();

            if (s == "STARTDIR")
            {
                s = f.ReadLine();
                while (s != "ENDDIR")
                {
                    Deserialize(FD, f, s);
                }
            }
        }

        void Deserialize()
        {
            FileEntry root = new FileEntry(true, "\\", new int[] { 0 }, null);
            int i;
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
            for (i = 0; i < clusters.Length; i++)
            {
                clusters[i] = new Cluster();
            }
            s = reader.ReadLine();
            while (s != "Files&Dirs_END")
            {
                Deserialize(null, reader, s);
            }
            s = reader.ReadLine();
            
            while (s != "DataSegment")
            {
                s = reader.ReadLine();
                var lines = s.Split(new[] { ' ' });
                bitMask = new int[lines.Length - 1];
                for (i = 0; i < bitMask.Length - 1; i++)
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

        private void Serialize(FileEntry fileEntry, StreamWriter f)
        {
            // header
            f.Write("");
            f.Write("{0}|{1}|", fileEntry.IsDir, fileEntry.Name);
            for (int i = 0; i < fileEntry.Clusters.Length; i++)
            {
                f.Write("{0}", fileEntry.Clusters[i]);
                if (fileEntry.Clusters.Length - i != 1)
                {
                    f.Write(";");
                }
            }
            f.WriteLine("");
            if (fileEntry.IsDir)
            {
                // tokenstart
                f.WriteLine("STARTDIR");
                foreach (var file in fileEntry.Entires)
                {
                    Serialize(file, f);
                }
                f.WriteLine("ENDDIR");
                // tokenend
            }
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
            Serialize(root, f);
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
                    GetCurDir().Entires.Add(new FileEntry(false, filename, tmp, GetCurDir()));
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
                    GetCurDir().Entires.Add(new FileEntry(true, dirname, tmp, GetCurDir()));
                    bitMask[i] = 1;
                    
                    /*
                    var tmp1 = root.Entires.LastOrDefault();
                    tmp1.Entires.Add(new FileEntry(false, dirname, tmp));
                    //*/
                    
                    break;
                }
            }

            Serialize();
        }

        public string GetSizeClusters()
        {
            return Convert.ToString(_clusterSize);
        }

        public Cluster[] GetClusters()
        {
            return clusters;
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
            var tmp = Convert.ToInt32(GetFreeClusters()) * 4;
            return Convert.ToString(tmp);
        }

        public int[] GetBitBock()
        {
            return bitMask;
        }

        public void Loaging()
        {
            Deserialize();
        }


        public void Clear()
        {
            root.Entires.Clear();
        }

        public string GetClusterData(int clusterNum)
        {
            if (clusterNum > clusters.Length || clusterNum < 0)
            {
                return null;
            }
            return clusters[clusterNum].Data;
        }
    }

    public class FileEntry
    {
        public bool IsDir;
        public string Name;
        public int[] Clusters;
        public List<FileEntry> Entires = new List<FileEntry>();

        public FileEntry Parent;

        public FileEntry(bool isDir, string name, int[] clusters, FileEntry parent )
        {
            IsDir = isDir;
            Name = name;
            Clusters = clusters;
            Parent = parent;
        }
    }

    public class Cluster
    {
        public string Data;
    }
}