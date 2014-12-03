using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FileSystem
{
    public class FileSystem
    {
        // ПРОВЕРИЛ
        private int _clusterSize; // Размер кластера
        private int _memorySize; // Размер памяти 
        private string _fileName; // Имя файловой системы 
        private FileEntry _currentDir; // Текущая папка
        private Cluster[] _clusters; // Массив кластеров
        private static int[] _bitMask;

        private FileEntry _root = new FileEntry(true, "\\", 0, null);

        // ПРОВЕРИЛ
        /// <summary>
        /// Установка текущей папки
        /// </summary>
        /// <param name="dir">Папка</param>
        public void SetCurDir(FileEntry dir)
        {
            _currentDir = dir;
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Получение текущей папки
        /// </summary>
        /// <returns>Текущая папка</returns>
        public FileEntry GetCurDir()
        {
            if (_currentDir == null)
                return _root;
            return _currentDir;
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Имя файла на диске
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public FileSystem(string fileName)
        {
            _fileName = fileName;
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Форматирование
        /// </summary>
        /// <param name="clusterCount">Количество кластеров</param>
        /// <param name="clusterSize">Размер кластеров</param>
        public void Format(int clusterCount, int clusterSize)
        {
            _currentDir = _root;
            _memorySize = clusterCount;
            _clusterSize = clusterSize;
            _clusters = new Cluster[_memorySize / _clusterSize];
            for (int i = 0; i < _clusters.Length; i++)
                _clusters[i] = new Cluster(-1, -1, null);
            _clusters[0] = new Cluster(-1, -1, "Root DIR");
            _bitMask = new int[_memorySize / _clusterSize];
            _bitMask[0] = 1;
            for (int i = 1; i < _bitMask.Length; i++)
                _bitMask[i] = 0;
            Serialize();
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Десериализация файлов ФС в файле на диске
        /// </summary>
        /// <param name="fileEntry">Входной файл</param>
        /// <param name="f">Файл</param>
        /// <param name="s">Строка</param>
        private void Deserialize(FileEntry fileEntry, StreamReader f, ref string s)
        {
            var lines = s.Split(new[] { '|' });
            var fd = new FileEntry(Convert.ToBoolean(lines[0]), lines[1], Convert.ToInt32(lines[2]), fileEntry);
            if (fileEntry != null)
                fileEntry.Entires.Add(fd);
            else
                _root = fd;
            s = f.ReadLine();
            if (s == "STARTDIR")
            {
                s = f.ReadLine();
                while (s != "ENDDIR")
                    Deserialize(fd, f, ref s);
                s = f.ReadLine();
            }
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Десериализация ФС c диске
        /// </summary>
        void Deserialize()
        {
            _root.Entires.Clear();
            int i;
            var reader = new StreamReader(_fileName);
            string s = reader.ReadLine();
            while (s != "Files&Dirs")
            {
                var lines = s.Split(new[] { ':' });
                switch (lines[0])
                {
                    case "File":
                        _fileName = lines[1];
                        break;
                    case "Size_Memory":
                        _memorySize = Convert.ToInt32(lines[1]);
                        break;
                    case "Size_Clusters":
                        _clusterSize = Convert.ToInt32(lines[1]);
                        break;
                }
                s = reader.ReadLine();
            }
            _clusters = new Cluster[_memorySize / _clusterSize];
            for (i = 0; i < _clusters.Length; i++)
            {
                _clusters[i] = new Cluster(-1, -1, null);
            }
            s = reader.ReadLine();
            while (s != "Files&Dirs_END")
            {
                Deserialize(null, reader, ref s);
            }
            s = reader.ReadLine();

            while (s != "DataSegment")
            {
                s = reader.ReadLine();
                var lines = s.Split(new[] { ' ' });
                _bitMask = new int[lines.Length - 1];
                for (i = 0; i < _bitMask.Length - 1; i++)
                {
                    _bitMask[i] = Convert.ToInt32(lines[i]);
                }
                s = reader.ReadLine();
            }
            i = 0;
            while (s != "DataSegment_END")
            {
                if (s != "DataSegment")
                {
                    //s = reader.ReadLine();
                    var lines = s.Split(new[] { '|' });
                    if (lines[2] == "null")
                        _clusters[i] = new Cluster(-1, -1, null);
                    else
                        _clusters[i] = new Cluster(Convert.ToInt32(lines[0]), Convert.ToInt32(lines[1]), lines[2]);
                    i += 1;
                }
                s = reader.ReadLine();
            }
            reader.Close();
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Сериализация файлов и папок ФС в файл
        /// </summary>
        /// <param name="fileEntry">Папка</param>
        /// <param name="f">Файл</param>
        private void Serialize(FileEntry fileEntry, StreamWriter f)
        {
            // header
            f.Write("");
            f.Write("{0}|{1}|{2}", fileEntry.IsDir, fileEntry.Name, fileEntry.Clusters);
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

        // ПРОВЕРИЛ
        /// <summary>
        /// Сериализация ФС на диск
        /// </summary>
        void Serialize()
        {
            var f = new StreamWriter(_fileName);

            f.WriteLine("InfoFileSystem");
            f.WriteLine("File:{0}", _fileName);
            f.WriteLine("Size_Memory:{0}", _memorySize);
            f.WriteLine("Size_Clusters:{0}", _clusterSize);
            f.WriteLine("Counter_Clusters:{0}", _memorySize / _clusterSize);

            f.WriteLine("Files&Dirs");
            Serialize(_root, f);
            f.WriteLine("Files&Dirs_END");

            f.WriteLine("BitMask");
            foreach (var b in _bitMask)
            {
                f.Write(b + " ");
            }
            f.WriteLine("");
            f.WriteLine("DataSegment");

            foreach (var cluster in _clusters)
            {
                if (cluster.Data == null)
                {
                    f.Write(cluster.Last + "|");
                    f.Write(cluster.Next + "|");
                    f.Write("null");
                }
                else
                {
                    f.Write(cluster.Last + "|");
                    f.Write(cluster.Next + "|");
                    f.Write(cluster.Data);
                }
                f.WriteLine("");
            }
            f.WriteLine("DataSegment_END");

            f.Close();
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Создание файла
        /// </summary>
        /// <param name="filename">Имя файла</param>
        public void CreateFile(string filename)
        {
            for (int i = 0; i < _bitMask.Length; i++)
            {
                if (_bitMask[i] == 0)
                {
                    GetCurDir().Entires.Add(new FileEntry(false, filename, i, GetCurDir()));
                    _bitMask[i] = 2;
                    _clusters[i] = new Cluster(-1, -1, "");
                    break;
                }
            }
            Serialize();
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Создание папки
        /// </summary>
        /// <param name="dirname">Имя папки</param>
        public void CreateDir(string dirname)
        {
            for (int i = 0; i < _bitMask.Length; i++)
            {
                if (_bitMask[i] == 0)
                {
                    GetCurDir().Entires.Add(new FileEntry(true, dirname, i, GetCurDir()));
                    _bitMask[i] = 1;
                    _clusters[i] = new Cluster(-1, -1, "DIR");
                    break;
                }
            }
            Serialize();
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Получение размера кластера
        /// </summary>
        /// <returns>Размер кластера</returns>
        public string GetSizeClusters()
        {
            return Convert.ToString(_clusterSize);
        }

        public int GetOneClusters(int i)
        {
            return _clusters[i].Next;
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Получение массива Cluster[]
        /// </summary>
        /// <returns>Массив кластеров</returns>
        public Cluster[] GetClusters()
        {
            return _clusters;
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Получение размера памяти
        /// </summary>
        /// <returns></returns>
        public string GetSize()
        {
            return Convert.ToString(_memorySize);
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Получение свободных кластеров
        /// </summary>
        /// <returns>Количество свободных</returns>
        public string GetFreeClusters()
        {
            var tmp = 0;
            foreach (var cluster in _clusters)
                if (cluster.Data == null)
                    tmp += 1;
            return Convert.ToString(tmp);
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Получение свободной памяти
        /// </summary>
        /// <returns>Количество свободной памяти</returns>
        public string GetFreeMemory()
        {
            var tmp = Convert.ToInt32(GetFreeClusters()) * _clusterSize;
            return Convert.ToString(tmp);
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Получение битовой маски
        /// </summary>
        /// <returns>Массив BitMask</returns>
        public static int[] GetBitBock()
        {
            return _bitMask;
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Загрузка ФС с диска
        /// </summary>
        public void Loaging()
        {
            Deserialize();
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Очистка корневой директории
        /// </summary>
        public void Clear()
        {
            _root.Entires.Clear();
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Получение информации с кластера
        /// </summary>
        /// <param name="clusterNum"></param>
        /// <returns></returns>
        public string GetClusterData(int clusterNum)
        {
            if (clusterNum > _clusters.Length || clusterNum < 0)
                return null;
            return _clusters[clusterNum].Data;
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Бинарный поиск файла
        /// </summary>
        /// <param name="fileEntry">Папка</param>
        /// <param name="seach">Имя которое ищем</param>
        public void Seach(FileEntry fileEntry, string seach)
        {
            foreach (var file in fileEntry.Entires)
            {
                if (file.IsDir)
                    Seach(file, seach);
                if (file.Name == seach)
                {
                    SetCurDir(file.Parent);
                    break;
                }
            }
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Получение корневой папки
        /// </summary>
        /// <returns></returns>
        public FileEntry GetRootDir()
        {
            return _root;
        }

        public void Defragmintation(FileEntry file, ref string s, ref int head, ProgressBar progressBar)
        {
            foreach (var fileEntry in file.Entires)
            {
                progressBar.Increment(1);
                if (fileEntry.IsDir)
                {
                    s += "Дефрагментация (" + fileEntry.Name + ")\r\n";
                    MoveData(fileEntry.Clusters, ref head);
                    s += "Поиск файлов в папке (" + fileEntry.Name + ")\r\n";
                    Defragmintation(fileEntry, ref s, ref head, progressBar);
                }
                else
                {
                    s += "Дефрагментация (" + fileEntry.Name + ")\r\n";
                    MoveData(fileEntry.Clusters, ref head);                    
                }
            }
        }

        private void MoveData(int clusters, ref int head)
        {
            var start = clusters;
            while (start != -1)
            {
                if (start != head)
                {
                    if (_clusters[head].Data != null)
                    {
                        var free = SeachFreeEndCluster(_clusters);
                        _clusters[free] = _clusters[head];
                        if (_clusters[free].Last != -1)
                            _clusters[_clusters[free].Last].Next = free;
                        else
                            FixStartFile(head, GetRootDir(), free);
                        if (_clusters[free].Next != -1)
                            _clusters[_clusters[free].Next].Last = free;
                    }
                    _clusters[head] = _clusters[start];
                    if (_clusters[head].Last != -1)
                        _clusters[_clusters[start].Last].Next = head;
                    else
                        FixStartFile(start, GetRootDir(), head);
                    if (_clusters[head].Next != -1)
                        _clusters[_clusters[start].Next].Last = head;
                    _clusters[start] = new Cluster(-1, -1, null);
                }
                start = _clusters[head].Next;
                head += 1;
            }
        }

        private void FixStartFile(int head, FileEntry dir, int free)
        {
            foreach (var file in dir.Entires)
            {
                if (file.Clusters == head)
                {
                    file.Clusters = free;
                    break;
                }
                if (file.IsDir)
                    FixStartFile(head, file, free);
            }

        }

        private static int SeachFreeEndCluster(Cluster[] clusters)
        {
            for (int i = clusters.Length - 1; i > 0; i--)
                if (clusters[i].Data == null)
                    return i;
            return -1;
        }

        /// <summary>
        /// Degrag
        /// </summary>
        /// <param name="file">Корневая папка</param>
        /// <param name="progressBar"></param>
        /// <returns>Строка выполнения</returns>
        public string Defrag(FileEntry file, ProgressBar progressBar)
        {
            string s = "";
            var head = 1;
            Defragmintation(file, ref s, ref head, progressBar);
            s += "Сохранение...\r\n";
            Serialize();
            Deserialize();
            SetCurDir(_root);
            UpdateBitMask(_clusters);
            return s;
        }

        private void UpdateBitMask(Cluster[] clusters)
        {
            for (int i = 1; i < clusters.Length; i++)
            {
                var cluster = clusters[i];
                if (cluster.Data != null)
                {
                    if (cluster.Data == "DIR")
                        _bitMask[i] = 1;
                    else
                        _bitMask[i] = 2;
                }
                else
                    _bitMask[i] = 0;
            }
        }

        // ПРОВЕРИЛ
        /// <summary>
        /// Вызов сохранения
        /// </summary>
        public void SaveFs()
        {
            Serialize();
        }

        public int GetOneFreeClusters()
        {
            for (int i = 0; i < _bitMask.Length; i++)
                if (_bitMask[i] == 0)
                    return i;
            return -1;
        }
    }

    /// <summary>
    /// Файл
    /// </summary>
    public class FileEntry
    {
        public bool IsDir;
        public string Name;
        public int Clusters;
        public FileEntry Parent;

        public List<FileEntry> Entires = new List<FileEntry>();

        public FileEntry(bool isDir, string name, int clusters, FileEntry parent)
        {
            IsDir = isDir;
            Name = name;
            Clusters = clusters;
            Parent = parent;
        }
    }

    /// <summary>
    /// Кластер
    /// </summary>
    public class Cluster
    {
        public int Next { get; set; }
        public int Last { get; set; }
        public string Data { get; set; }

        public Cluster(int last, int next, string data)
        {
            Last = last;
            Next = next;
            Data = data;
        }
    }
}