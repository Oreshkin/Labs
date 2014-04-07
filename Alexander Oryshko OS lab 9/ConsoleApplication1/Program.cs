using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static int _sizePage;
        private static int _sizeVP;
        private static int _sizeVP_OR;
        private static int k;
        private static byte[] _memory;
        private static Page[] _pageList;
        private static readonly Queue<MyProcess> ProcessList = new Queue<MyProcess>();
        private static readonly List<MyProcess> HistoriList = new List<MyProcess>();
        private static readonly List<MyProcess> VirtualMemoryList = new List<MyProcess>();

        private static void Main()
        {
            bool exit = true;
            var start = 0;
            Console.WriteLine("\n Ввод начальных данных\n");
            Console.Write(" Введите ко-во памяти: ");
            var nm = Convert.ToInt32(Console.ReadLine());
            _memory = new byte[nm];
            Console.Write("\n Введите ко-во страниц: ");
            k = Convert.ToInt32(Console.ReadLine());
            _pageList = new Page[k];
            _sizePage = nm / k;
            for (var i = 0; i < k; i++)
            {
                _pageList[i] = new Page { FirstAddress = start, Length = start + _sizePage };
                start += _sizePage;
            }

            Console.Write("\n Введите ко-во виртуальной памяти: ");
            var vm = Convert.ToInt32(Console.ReadLine());
            _sizeVP_OR = vm;
            _sizeVP = vm / k;

            while (exit)
            {
                Console.Clear();
                Info();
                Console.WriteLine("\n Главное Меню:\n");
                Console.WriteLine("  1. Чтение с файла");
                Console.WriteLine("  2. Запуск");
                Console.WriteLine("  3. Удаление");
                Console.WriteLine("  4. Добавить");
                Console.WriteLine("  5. Random обращение");
                Console.WriteLine("  6. Добовление процесса");
                Console.WriteLine("  7. Exit");
                Console.Write("\n Выберите пункт меню: ");
                var m = Convert.ToInt32(Console.ReadLine());
                switch (m)
                {
                    case 1:
                        LoadFile();
                        break;
                    case 2:
                        Start();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Add();
                        break;
                    case 5:
                        RandomW();
                        break;
                    case 6:
                        AddProcess();
                        break;
                    case 7:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("\n ERROR: Неверный выбор!");
                        Pause();
                        break;
                }
            }
        }

        private static void AddProcess()
        {
            Console.Clear();
            Console.WriteLine("\n Введите имя:");
            var name = Console.ReadLine();
            Console.WriteLine("\n Введите размер:");
            var size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n Введите время работы:");
            var timework = Convert.ToInt32(Console.ReadLine());
            int fullsize = size / _sizePage;
            int rest = size % _sizePage;
            ProcessList.Enqueue(new MyProcess
            {
                Name = name,
                Size = size,
                TimeWork = timework
            });
            int i;
            for (i = 0; i < fullsize; i++)
                VirtualMemoryList.Add(new MyProcess { Name = name, NumberBlock = i + 1 });
            if (rest != 0)
                VirtualMemoryList.Add(new MyProcess { Name = name, NumberBlock = i + 1 });
            Console.WriteLine(" Процесс {0} добавлен и разбит на {1} страницы из них {2} по {3}, и 1 блок размерои {4}", name, fullsize + 1, fullsize, _sizePage, rest);
            Pause();
        }

        private static void RandomW()
        {
            Console.Clear();
            var rand = new Random();
            var namberUsage = rand.Next(1, 10);
            Console.WriteLine("\n {0} обращений сгенерированно", namberUsage);
            for (int i = 0; i < namberUsage; i++)
            {
                System.Threading.Thread.Sleep(500);
                var numberPage = rand.Next(0, _pageList.Length);
                _pageList[numberPage].Сounter += 1;
                Console.WriteLine("\n Обращение к странице {0} выполнено", numberPage);
            }
            Pause();
        }

        private static void Add()
        {
            Console.Clear();
            Console.WriteLine("\n Введите имя:");
            var name = Console.ReadLine();
            Console.WriteLine("\n Введите номер страницы:");
            var numberBlock = Convert.ToInt32(Console.ReadLine());
            ProcessList.Enqueue(new MyProcess { Name = name, NumberBlock = numberBlock });
            Console.WriteLine(" Процесс {0} добавлен!", name);
            Pause();
        }

        private static void Delete()
        {
            bool exit = true;
            while (exit)
            {
                Console.Clear();
                Info();
                Console.WriteLine("\n Удаление:\n");
                Console.WriteLine("  1. Выгрузить заданную страницу");
                Console.WriteLine("  2. Выгрузить заданный процесс");
                Console.WriteLine("  3. Удаление процесса");
                Console.WriteLine("  4. Очистить все");
                Console.WriteLine("  5. Exit");
                Console.Write("\n Выберите пункт меню: ");
                var m = Convert.ToInt32(Console.ReadLine());
                switch (m)
                {
                    case 1:
                        {
                            Console.WriteLine("\n Введите номер страницы:");
                            var numberPage = Convert.ToInt32(Console.ReadLine());
                            if (_pageList[numberPage] != null)
                            {
                                VirtualMemoryList.Add(_pageList[numberPage].CurrentProcess);
                                for (int i = 0; i < HistoriList.Count; i++)
                                {
                                    if (HistoriList[i].Name == _pageList[numberPage].CurrentProcess.Name && HistoriList[i].NumberBlock == _pageList[numberPage].CurrentProcess.NumberBlock)
                                    {
                                        HistoriList.Remove(HistoriList[i]);
                                        break;
                                    }
                                }
                                _pageList[numberPage].CurrentProcess = null;
                            }
                            else
                            {
                                Console.WriteLine("\n ERROR: Нет такой страницы!");
                            }
                            Pause();
                        }
                        break;
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("\n Введите имя:");
                            var name = Console.ReadLine();
                            foreach (var page in _pageList)
                            {
                                if (page.CurrentProcess != null && page.CurrentProcess.Name == name)
                                {
                                    VirtualMemoryList.Add(page.CurrentProcess);
                                    page.CurrentProcess = null;
                                }
                            }
                            var tmpHL = HistoriList.Count;
                            for (int i = 0; i < tmpHL; i++)
                            {
                                if (HistoriList[i].Name == name)
                                {
                                    HistoriList.Remove(HistoriList[i]);
                                    tmpHL = HistoriList.Count;
                                    i--;
                                }
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("\n Введите имя:");
                            var name = Console.ReadLine();
                            foreach (var page in _pageList)
                            {
                                if (page.CurrentProcess != null && page.CurrentProcess.Name == name)
                                {
                                    page.CurrentProcess = null;
                                }
                            }

                            var tmpVML = VirtualMemoryList.Count;
                            for (int i = 0; i < tmpVML; i++)
                            {
                                if (VirtualMemoryList[i].Name == name)
                                {
                                    VirtualMemoryList.Remove(VirtualMemoryList[i]);
                                    tmpVML = VirtualMemoryList.Count;
                                    i--;
                                }
                            }

                            var tmpHL = HistoriList.Count;
                            for (int i = 0; i < tmpHL; i++)
                            {
                                if (HistoriList[i].Name == name)
                                {
                                    HistoriList.Remove(HistoriList[i]);
                                    tmpHL = HistoriList.Count;
                                    i--;
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            foreach (var page in _pageList)
                            {
                                page.CurrentProcess = null;
                            }
                            VirtualMemoryList.Clear();
                            HistoriList.Clear();
                            _sizeVP = _sizeVP_OR / k;
                        }
                        break;
                    case 5:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("\n ERROR: Неверный выбор!");
                        Pause();
                        break;

                }
            }
        }

        private static void Start()
        {

            var rand = new Random();
            while (ProcessList.Count != 0)
            {
                var process = ProcessList.Dequeue();
                var block = process.NumberBlock;

                int numberCP = 0;
                foreach (var page in _pageList)
                {
                    if (page.CurrentProcess == null)
                    {
                        numberCP += 1;
                    }
                }

                for (int j = 1; j <= block; j++)
                {
                    var numberPage = rand.Next(0, k-1);
                    if (numberCP <= k && numberCP != 0)
                    {
                        if (_pageList[numberPage].CurrentProcess == null)
                        {
                            int NVM = VirtualMemoryList.Count;
                            for (int i = 0; i < NVM; i++)
                            {
                                if (VirtualMemoryList[i].Name == process.Name && VirtualMemoryList[i].NumberBlock == j)
                                {
                                    _pageList[numberPage].CurrentProcess = VirtualMemoryList[i];
                                    HistoriList.Add(VirtualMemoryList[i]);
                                    VirtualMemoryList.Remove(VirtualMemoryList[i]);
                                    Info();
                                    Console.WriteLine("\n Обращение к {0} странице, загружаемый блок {1}, Процесс {2}", numberPage, j, _pageList[numberPage].CurrentProcess.Name);
                                    Pause();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            VirtualMemoryList.Add(_pageList[numberPage].CurrentProcess);
                            HistoriList.Remove(_pageList[numberPage].CurrentProcess);
                            _pageList[numberPage].CurrentProcess = null;
                            int NVM = VirtualMemoryList.Count;
                            for (int i = 0; i < NVM; i++)
                            {
                                if (VirtualMemoryList[i].Name == process.Name && VirtualMemoryList[i].NumberBlock == j)
                                {
                                    _pageList[numberPage].CurrentProcess = VirtualMemoryList[i];
                                    HistoriList.Add(VirtualMemoryList[i]);
                                    VirtualMemoryList.Remove(VirtualMemoryList[i]);
                                    Info();
                                    Console.WriteLine("\n Обращение к {0} странице, загружаемый блок {1}, Процесс {2}", numberPage, j, _pageList[numberPage].CurrentProcess.Name);
                                    Pause();
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        var history = HistoriList.FirstOrDefault();
                        HistoriList.Remove(HistoriList.FirstOrDefault());
                        foreach (var myProcess in VirtualMemoryList)
                        {
                            if (myProcess.Name == process.Name && myProcess.NumberBlock == block)
                            {
                                foreach (var page in _pageList)
                                {
                                    if (history != null && (page.CurrentProcess.Name == history.Name && page.CurrentProcess.NumberBlock == history.NumberBlock))
                                    {
                                        VirtualMemoryList.Add(page.CurrentProcess);
                                        page.CurrentProcess = myProcess;
                                        HistoriList.Add(myProcess);
                                        Info();
                                        Console.WriteLine("\n Обращение к {0} странице, загружаемый блок {1}, Процесс {2}", numberPage, j, _pageList[numberPage].CurrentProcess.Name);
                                        Pause();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("ERROR");
            Info();
            Pause();
        }

        private static void Info()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n =========================================");
            Console.ForegroundColor = ConsoleColor.Gray;
            float numberCP = 0;

            foreach (var page in _pageList)
            {
                if (page.CurrentProcess == null)
                {
                    numberCP += 1;
                }
            }

            Console.WriteLine("\n Колличесво обращений: ");
            for (int i = 0; i < _pageList.Length; i++)
            {
                Console.WriteLine(" Номер страницы: {0} Колличесто обращений: {1}", i, _pageList[i].Сounter);
            }

            Console.WriteLine("\n Список текущих процессов: ");
            foreach (var page in _pageList)
            {
                if (page.CurrentProcess != null)
                {
                    Console.WriteLine(" Имя: {0} Кол-во блоков: {1}", page.CurrentProcess.Name, page.CurrentProcess.NumberBlock);
                }
            }
            if (numberCP == _pageList.Length)
            {
                Console.WriteLine(" Текущих процессов НЕТ!");
            }

            Console.WriteLine("\n Список процессов в очереди: ");
            foreach (var myProcess in ProcessList)
            {
                Console.WriteLine(" Имя: {0} Номер блока: {1}", myProcess.Name, myProcess.NumberBlock);
            }
            if (ProcessList.Count == 0)
            {
                Console.WriteLine(" Процессов НЕТ!");
            }

            Console.WriteLine("\n История: ");
            foreach (var myProcess in HistoriList)
            {
                if (myProcess != null)
                {
                    Console.WriteLine(" Имя: {0} Номер блока: {1}", myProcess.Name, myProcess.NumberBlock);
                }
            }
            if (HistoriList.Count == 0)
            {
                Console.WriteLine(" Истории НЕТ!");
            }

            Console.WriteLine("\n Витруальная память: ");
            foreach (var myProcess in VirtualMemoryList)
            {
                Console.WriteLine(" Имя: {0} Номер блока: {1}", myProcess.Name, myProcess.NumberBlock);
            }
            if (VirtualMemoryList.Count == 0)
            {
                Console.WriteLine(" Процессов НЕТ!");
            }

            Console.WriteLine("\n Колличество ФП: {0} байт", _memory.Length);

            Console.WriteLine("\n Колличество ВП: {0} байт", _sizeVP_OR);

            Console.WriteLine("\n Колличество страниц: {0} ", _pageList.Length);

            Console.WriteLine("\n Размер страниц: {0} байт", _pageList[0].Length);

            Console.WriteLine("\n Число свободных страниц: {0}%", (numberCP / _pageList.Length) * 100);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n =========================================");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void LoadFile()
        {
            Console.Clear();
            var reader = new StreamReader("process_list.txt");
            while (true)
            {
                var s = reader.ReadLine();
                if (s == null)
                    break;
                var lines = s.Split(new[] { ' ' });
                int fullsize = Convert.ToInt32(lines[1]) / _sizePage;
                int rest = Convert.ToInt32(lines[1]) % _sizePage;
                int i;
                if (_sizeVP >= fullsize + rest)
                {
                    for (i = 0; i < fullsize; i++)
                    {
                        VirtualMemoryList.Add(new MyProcess { Name = lines[0], NumberBlock = i + 1 });
                        _sizeVP -= 1;
                    }
                    if (rest != 0)
                    {
                        VirtualMemoryList.Add(new MyProcess { Name = lines[0], NumberBlock = i + 1 });
                        _sizeVP -= 1;
                    }
                    ProcessList.Enqueue(new MyProcess { Name = lines[0], Size = Convert.ToInt32(lines[1]), TimeWork = Convert.ToInt32(lines[2]), NumberBlock = fullsize + 1 });
                    Console.WriteLine(" {0} добавлен и разбит на {1} страницы из них {2} по {3}, и 1 блок размерои {4}", lines[0], fullsize + 1, fullsize, _sizePage, rest);
                    System.Threading.Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("\n ERROR: Недостаточно памяти под процесс {0}", lines[0]);
                    System.Threading.Thread.Sleep(500);
                }

            }
            reader.Close();
            Pause();
        }

        // Задержка консоли
        private static void Pause()
        {
            Console.Write("\n\n Нажмите любую клавишу для продолжения . . . ");
            Console.ReadKey(true);
        }
    }

}