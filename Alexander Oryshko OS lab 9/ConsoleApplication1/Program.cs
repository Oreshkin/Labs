using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        /// <summary>
        /// Размер страницы
        /// </summary>
        private static int _sizePage; 
        /// <summary>
        /// Размер виртуальной памяти
        /// </summary>
        private static int _sizeVp; 
        /// <summary>
        /// Переменная для сохранения начального значения виртуальной памяти
        /// </summary>
        private static int _sizeVpOr; 
        /// <summary>
        /// Количество свободных страниц
        /// </summary>
        private static int _numberCp; 
        /// <summary>
        /// Количество страниц для ФП
        /// </summary>
        private static int _k; 
        /// <summary>
        /// ФП
        /// </summary>
        private static byte[] _memory; 
        /// <summary>
        /// Список страниц
        /// </summary>
        private static Page[] _pageList; 
        /// <summary>
        /// Очередь процессов
        /// </summary>
        private static readonly Queue<MyProcess> ProcessList = new Queue<MyProcess>(); 
        /// <summary>
        /// История обращения к памяти (fifo)
        /// </summary>
        private static readonly List<MyProcess> HistoriList = new List<MyProcess>(); 
        /// <summary>
        /// ВП
        /// </summary>
        private static readonly List<MyProcess> VirtualMemoryList = new List<MyProcess>(); 
        ///
        private static void Main()
        {
            Console.Title = "Лабораторная работа № 9 ОС Вариант 2 (Бобр Г.В)";
            bool exit = true;
            int start = 0;
            Console.WriteLine("\n Ввод начальных данных\n");
            Console.Write(" Введите количество памяти 2^: ");
            var nm = Convert.ToInt32(Console.ReadLine());
            _memory = new byte[(int)Math.Pow(2, nm)];
            Console.Write("\n Введите количество страниц: ");
            _k = Convert.ToInt32(Console.ReadLine());
            _pageList = new Page[_k];
            _sizePage = Convert.ToInt32(Math.Pow(2, nm) / _k);
            for (var i = 0; i < _k; i++)
            {
                _pageList[i] = new Page { FirstAddress = start, Length = start + _sizePage };
                start += _sizePage;
            }
            Console.Write("\n Введите количество виртуальной памяти 2^: ");
            var vm = Convert.ToInt32(Console.ReadLine());
            _sizeVpOr = vm;
            _sizeVp = Convert.ToInt32(Math.Pow(2, vm) / _pageList[0].Length);
            while (exit)
            {
                Console.Title = "Главное меню";
                Console.Clear();
                Info();
                Console.WriteLine("\n\t\tГлавное Меню:\n");
                Console.WriteLine("  1. Чтение с файла");
                Console.WriteLine("  2. Запуск");
                Console.WriteLine("  3. Удаление");
                Console.WriteLine("  4. Полный сброс");
                Console.WriteLine("  5. Добавление процесса");
                Console.WriteLine("  6. Exit");
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
                        Reset();
                        break;
                    case 5:
                        AddProcess();
                        break;
                    case 6:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("\n ERROR: Неверный выбор!");
                        Pause();
                        break;
                }
            }
        }

        private static void Reset()
        {
            foreach (var page in _pageList)
            {
                page.CurrentProcess = null;
                page.Сounter = 0;
            }
            ProcessList.Clear();
            VirtualMemoryList.Clear();
            _sizeVp = Convert.ToInt32(Math.Pow(2, _sizeVpOr) / _pageList[0].Length);
            HistoriList.Clear();
        }

        private static void AddProcess()
        {
            Console.Title = "Добавление процесса";
            Console.Clear();
            Console.WriteLine("\n Введите имя:");
            var name = Console.ReadLine();
            Console.WriteLine("\n Введите размер:");
            var size = Convert.ToInt32(Console.ReadLine());
            int fullsize = size / _sizePage;
            int rest = size % _sizePage;
            ProcessList.Enqueue(new MyProcess
            {
                Name = name,
                Size = size,
                NumberBlock = fullsize + 1
            });
            int i;
            for (i = 0; i < fullsize; i++)
                VirtualMemoryList.Add(new MyProcess { Name = name, NumberBlock = i + 1 });
            if (rest != 0)
                VirtualMemoryList.Add(new MyProcess { Name = name, NumberBlock = i + 1 });
            Console.WriteLine(" Процесс {0} добавлен и разбит на {1} страницы из них {2} по {3}, и 1 страницу размером {4}", name, fullsize + 1, fullsize, _sizePage, rest);
            Pause();
        }

        private static void Delete()
        {
            Console.Title = "Удаление";
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
                                Console.WriteLine("\n ERROR: Нет такой страницы!");
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
                            var tmpHl = HistoriList.Count;
                            for (int i = 0; i < tmpHl; i++)
                            {
                                if (HistoriList[i].Name == name)
                                {
                                    HistoriList.Remove(HistoriList[i]);
                                    tmpHl = HistoriList.Count;
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
                                if (page.CurrentProcess != null && page.CurrentProcess.Name == name)
                                    page.CurrentProcess = null;

                            var tmpVml = VirtualMemoryList.Count;
                            for (int i = 0; i < tmpVml; i++)
                            {
                                if (VirtualMemoryList[i].Name == name)
                                {
                                    VirtualMemoryList.Remove(VirtualMemoryList[i]);
                                    tmpVml = VirtualMemoryList.Count;
                                    i--;
                                }
                            }
                            var tmpHl = HistoriList.Count;
                            for (int i = 0; i < tmpHl; i++)
                            {
                                if (HistoriList[i].Name == name)
                                {
                                    HistoriList.Remove(HistoriList[i]);
                                    tmpHl = HistoriList.Count;
                                    i--;
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            foreach (var page in _pageList)
                                page.CurrentProcess = null;
                            ProcessList.Clear();
                            VirtualMemoryList.Clear();
                            HistoriList.Clear();
                            _sizeVp = Convert.ToInt32(Math.Pow(2, _sizeVpOr) / _pageList[0].Length);
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
        /// <summary>
        /// Эмуляция работы 
        /// </summary>
        private static void Start()
        {
            Console.Title = "Эмуляция Online";
            var rand = new Random();
            while (ProcessList.Count != 0)
            {
                var process = ProcessList.Dequeue();
                var block = process.NumberBlock; // Берет количество страниц (время работы)
                for (int j = 1; j <= block; j++)
                {
                    SearchCpNull(); // высчитывает количество свободных страниц в ФП
                    var numberPage = rand.Next(0, _k - 1); // рандомное число для обращения в ФП (рандом. номер страницы в ФП)
                    _pageList[numberPage].Сounter += 1; // Увеличивает счетчик обращения к странице
                    if (_numberCp <= _k && _numberCp != 0)
                    {
                        if (_pageList[numberPage].CurrentProcess == null) // Если в этой странице ФП нет процесса
                        {
                            int nvm = VirtualMemoryList.Count;
                            for (int i = 0; i < nvm; i++) // Ищет в ВП памяти первую страницу процесса
                            {
                                if (VirtualMemoryList[i].Name == process.Name && VirtualMemoryList[i].NumberBlock == j)
                                {
                                    _pageList[numberPage].CurrentProcess = VirtualMemoryList[i];
                                    HistoriList.Add(VirtualMemoryList[i]);
                                    VirtualMemoryList.Remove(VirtualMemoryList[i]);
                                    _sizeVp += 1;
                                    Info();
                                    Console.WriteLine("\n Обращение к {0} странице, загружаемая страница {1}, Процесс {2}", numberPage + 1, j, _pageList[numberPage].CurrentProcess.Name);
                                    Pause();
                                    break;
                                }
                            }
                        }
                        else // Если страница, к которой мы обращаемся, занята
                        {
                            foreach (var page in _pageList)
                            {
                                if (page.CurrentProcess == null)
                                {
                                    int nvm = VirtualMemoryList.Count;
                                    for (int i = 0; i < nvm; i++)
                                    {
                                        if (VirtualMemoryList[i].Name == process.Name && VirtualMemoryList[i].NumberBlock == j)
                                        {
                                            page.Сounter += 1;
                                            page.CurrentProcess = VirtualMemoryList[i];
                                            HistoriList.Add(VirtualMemoryList[i]);
                                            VirtualMemoryList.Remove(VirtualMemoryList[i]);
                                            _sizeVp += 1;
                                            Info();
                                            Console.WriteLine("\n Обращение к {0} странице, загружаемая страница {1}, Процесс {2}", numberPage + 1, j, page.CurrentProcess.Name);
                                            Pause();
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    else // Если свободных страниц нет
                    {
                        var history = HistoriList.FirstOrDefault();
                        HistoriList.Remove(HistoriList.FirstOrDefault());
                        int nvm = VirtualMemoryList.Count;
                        for (int i = 0; i < nvm; i++)
                        {
                            if (VirtualMemoryList[i].Name == process.Name && VirtualMemoryList[i].NumberBlock == block)
                            {
                                foreach (var page in _pageList)
                                {
                                    if (history != null &&
                                        (page.CurrentProcess.Name == history.Name &&
                                         page.CurrentProcess.NumberBlock == history.NumberBlock))
                                    {
                                        VirtualMemoryList.Add(page.CurrentProcess);
                                        nvm = VirtualMemoryList.Count;
                                        _sizeVp -= 1;
                                        page.CurrentProcess = VirtualMemoryList[i];
                                        HistoriList.Add(VirtualMemoryList[i]);
                                        Info();
                                        Console.WriteLine(
                                            "\n Обращение к {0} странице, загружаемый блок {1}, Процесс {2}",
                                            numberPage + 1, j, page.CurrentProcess.Name);
                                        Pause();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.Title = "Эмуляция OFF";
            VirtualMemoryList.Clear();
            _sizeVp = Convert.ToInt32(Math.Pow(2, _sizeVpOr) / _pageList[0].Length);
            Info();
            Console.WriteLine("\n !!!PROGRAM END!!!");
            Pause();
        }

        private static void SearchCpNull()
        {
            _numberCp = 0;
            foreach (var page in _pageList)
                if (page.CurrentProcess == null)
                    _numberCp += 1;
        }

        private static void Info()
        {
            Console.Clear();
            
            SearchCpNull();

            TableCount();

            Console.WriteLine("\n Физическая память: ");
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (_numberCp == _pageList.Length)
            {
                Console.WriteLine(" Память пуста!");
            }
            else
            {
                foreach (var page in _pageList)
                {
                    if (page.CurrentProcess != null)
                        Console.WriteLine(" Имя: {0} Номер страницы: {1}", page.CurrentProcess.Name,
                            page.CurrentProcess.NumberBlock);
                    else
                        Console.WriteLine(" null");
                }
            }
            Console.WriteLine("\n Список процессов в очереди: ");
            foreach (var myProcess in ProcessList)
                Console.WriteLine(" Имя: {0} Время работы: {1}", myProcess.Name, myProcess.NumberBlock);
            if (ProcessList.Count == 0)
                Console.WriteLine(" Процессов НЕТ!");
            Console.WriteLine("\n История: ");
            foreach (var myProcess in HistoriList)
                if (myProcess != null)
                    Console.WriteLine(" Имя: {0} Номер страницы: {1}", myProcess.Name, myProcess.NumberBlock);
            if (HistoriList.Count == 0)
                Console.WriteLine(" Истории НЕТ!");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n ═══════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n Виртуальная память: ");
            Console.WriteLine(" Количество ВП: {0} байт", Math.Pow(2, _sizeVpOr));
            Console.WriteLine(" Количество страниц ВП: {0} ", Math.Pow(2, _sizeVpOr) / _pageList[0].Length);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n ═══════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var myProcess in VirtualMemoryList)
                Console.WriteLine(" Имя: {0} ║ Cтраница: {1}", myProcess.Name, myProcess.NumberBlock);
            if (VirtualMemoryList.Count == 0)
                Console.WriteLine("\n Память пуста!");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n ═══════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void TableCount()
        {
            SearchCpNull();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n ═══════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n\t\tФизическая память:");
            Console.WriteLine("\n Количество обращений");

            int table = 0;
            Console.Write(" ╔");
            for (int i = 1; i <= _pageList.Length*3; i++)
            {
                table += 1;
                Console.Write("═");
                if (table == 3)
                {
                    if (i != _pageList.Length*3)
                    {
                        Console.Write("╦");
                        table = 0;
                    }
                }
            }
            Console.Write("╗\n");

            Console.Write(" ║");
            for (int i = 0; i < _pageList.Length; i++)
            {
                Console.Write("{0,3}║", i + 1);
            }
            Console.Write(" Страницы");
            table = 0;
            Console.Write("\n ╠");
            for (int i = 1; i <= _pageList.Length*3; i++)
            {
                table += 1;
                Console.Write("═");
                if (table == 3)
                {
                    if (i != _pageList.Length*3)
                    {
                        Console.Write("╬");
                        table = 0;
                    }
                }
            }
            Console.Write("╣\n");

            Console.Write(" ║");
            for (int i = 0; i < _pageList.Length; i++)
            {
                Console.Write("{0,3}║", _pageList[i].Сounter);
            }
            Console.Write(" Обращения");
            table = 0;
            Console.Write("\n ╚");
            for (int i = 1; i <= _pageList.Length*3; i++)
            {
                table += 1;
                Console.Write("═");
                if (table == 3)
                {
                    if (i != _pageList.Length*3)
                    {
                        Console.Write("╩");
                        table = 0;
                    }
                }
            }
            Console.Write("╝\n");
            Console.WriteLine("\n Количество ФП: {0} байт", _memory.Length);
            Console.WriteLine(" Количество страниц ФП: {0} ", _pageList.Length);
            Console.WriteLine(" Размер страниц: {0} байт", _pageList[0].Length);
            Console.WriteLine(" Число свободных страниц в ФП: {0}%", (_numberCp / _pageList.Length) * 100);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n ═══════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void LoadFile()
        {
            Console.Title = "Загрузка из файла";
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
                int restTmp = 0;
                if (rest > 0)
                    restTmp = 1;
                if (_sizeVp >= fullsize + restTmp)
                {
                    int i;
                    for (i = 1; i <= fullsize; i++)
                    {
                        VirtualMemoryList.Add(new MyProcess { Name = lines[0], NumberBlock = i });
                        _sizeVp -= 1;
                        if (fullsize - i == 0 && rest == 0)
                        {
                            ProcessList.Enqueue(new MyProcess { Name = lines[0], Size = Convert.ToInt32(lines[1]), NumberBlock = fullsize });
                        }
                    }
                    if (rest != 0)
                    {
                        VirtualMemoryList.Add(new MyProcess { Name = lines[0], NumberBlock = i });
                        ProcessList.Enqueue(new MyProcess { Name = lines[0], Size = Convert.ToInt32(lines[1]), NumberBlock = fullsize + 1 });
                        _sizeVp -= 1;
                    }
                    Console.WriteLine(" {0} добавлен и разбит на {1} страницы из них {2} по {3}, и 1 страница размером {4}", lines[0], fullsize + restTmp, fullsize, _sizePage, rest);
                }
                else
                {
                    Console.WriteLine("\n ERROR: Недостаточно памяти под процесс {0}", lines[0]);
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