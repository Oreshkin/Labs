using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static byte[] _memory;
        private static Page[] _pageList;
        private static readonly Queue<MyProcess> ProcessList = new Queue<MyProcess>();
        private static readonly Queue<MyProcess> HistoriList = new Queue<MyProcess>();
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
            var k = Convert.ToInt32(Console.ReadLine());
            _pageList = new Page[k];
            Console.Write("\n Введите размер: ");
            var tmp = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < k; i++)
            {
                _pageList[i] = new Page { FirstAddress = start, Length = start + tmp };
                start += tmp;
            }
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
                        Add();
                        break;
                    case 5:
                        RandomW();
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
                Console.WriteLine("  4. Exit");
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
                                if (HistoriList.ElementAt(i).Name == name)
                                {
                                    HistoriList.Dequeue();
                                    tmpHL = HistoriList.Count;
                                    i--;
                                }
                            }
                        }
                        break;
                    case 4:
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
            var number = ProcessList.Count;
            for (int i = 0; i < number; i++)
            {
                var tmp = ProcessList.Dequeue();
                foreach (var page in _pageList)
                {
                    if (page.CurrentProcess == null)
                    {
                        page.CurrentProcess = tmp;
                        HistoriList.Enqueue(tmp);
                        tmp = null;
                        break;
                    }
                }
                if (tmp != null)
                {
                    var history = HistoriList.Dequeue();
                    HistoriList.Enqueue(tmp);
                    foreach (var page in _pageList)
                    {
                        if (history != null && (page.CurrentProcess.Name == history.Name && page.CurrentProcess.NumberBlock == history.NumberBlock))
                        {
                            VirtualMemoryList.Add(page.CurrentProcess);
                            page.CurrentProcess = tmp;
                            history = null;
                        }
                    }
                }

                Info();
                Pause();
            }
        }

        private static void Info()
        {
            Console.Clear();
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
                    Console.WriteLine(" Имя: {0} Номер блока: {1}", page.CurrentProcess.Name, page.CurrentProcess.NumberBlock);
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

            Console.WriteLine("\n Колличество памяти: {0} байт", _memory.Length);

            Console.WriteLine("\n Колличество страниц: {0} ", _pageList.Length);

            Console.WriteLine("\n Размер страниц: {0}", _pageList[0].Length);

            Console.WriteLine("\n Число свободных страниц: {0}%", (numberCP / _pageList.Length) * 100);
        }

        private static void LoadFile()
        {
            var reader = new StreamReader("process_list.txt");
            while (true)
            {
                var s = reader.ReadLine();
                if (s == null)
                    break;
                var lines = s.Split(new[] { ' ' });
                ProcessList.Enqueue(new MyProcess { Name = lines[0], NumberBlock = Convert.ToInt32(lines[1]) });
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