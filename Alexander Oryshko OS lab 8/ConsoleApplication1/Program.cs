using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static float _request;
        private static float _requestOk;
        private static bool _run;
        private static readonly byte[] Memory = new byte[60000];
        private static Page[] _pageList;
        private static readonly List<MyProcess> ProcessList = new List<MyProcess>();
        private static bool _random;

        private static void Main()
        {
            // Переменная для главного меню
            bool exit = true;
            // Переменная начало памяти
            var start = 0;
            // Ввод начальных данных (Кол-во разделов и их размер)
            Console.WriteLine("\n Ввод начальных данных\n");
            Console.Write(" Введите ко-во разделов: ");
            var k = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");
            // Создаем массив k разделов
            _pageList = new Page[k];
            // Ввод размера страниц
            for (var i = 0; i < k; i++)
            {
                Console.Write(" Введите размер раздела под номером {0}: ", i + 1);
                var tmp = Convert.ToInt32(Console.ReadLine());
                _pageList[i] = new Page { FirstAddress = start, Length = start + tmp };
                start += tmp;
            }
            // Сортировка разделов по возрастанию (Исправлено)
            Array.Sort(_pageList, (page, page1) =>
            {
                if (page.Length - page.FirstAddress
                    > page1.Length - page1.FirstAddress)
                    return 1;
                if (page.Length - page.FirstAddress
                    < page1.Length - page1.FirstAddress)
                    return -1;

                return 0;
            });
            while (exit)
            {
                Getstate();
                Console.WriteLine("\n Главное Меню:\n");
                Console.WriteLine("  1. Добавить");
                Console.WriteLine("  2. Удалить");
                Console.WriteLine("  3. Записать");
                Console.WriteLine("  4. Чтение");
                Console.WriteLine("  5. Random");
                Console.WriteLine("  6. Загрузка процесса на раздел");
                Console.WriteLine("  7. Exit");
                Console.Write("\n Выберите пункт меню: ");
                var m = Convert.ToInt32(Console.ReadLine());
                switch (m)
                {
                   case 1:
                        Reserve();
                        break;
                    case 2:
                        Free();
                        break;
                    case 3:
                        Write();
                        break;
                    case 4:
                        Read();
                        break;
                    case 5:
                        My_random();
                        break;
                    case 6:
                        {
                            Console.Clear();
                            Console.Write("\n Введите номер раздела: ");
                            var load = Convert.ToInt32(Console.ReadLine());
                            if (load <= _pageList.Length && load > 0)
                            {
                                RemoveProcess(_pageList[load - 1]);
                                Console.WriteLine("\n MES: Процесс загружен если в очереди на раздел есть процесс!");
                                Pause();
                            }
                            else
                            {
                                Console.WriteLine("\n ERROR: Неверный выбор!");
                                Pause();
                            }
                        }
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

        // Задержка консоли
        private static void Pause()
        {
            Console.Write("\n\n Нажмите любую клавишу для продолжения . . . ");
            Console.ReadKey(true);
        }

        // Автоматическое выделение и освобождение памяти (Исправление не требуется)
        private static void My_random()
        {
            bool exit = true;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("\n Режим работы автоматизации:\n");
                Console.WriteLine("  1. Random ALL");
                Console.WriteLine("  2. Чтение из файла");
                Console.WriteLine("  3. Запуск введенных данных (при ручном вводе)");
                Console.WriteLine("  4. Exit");
                Console.Write("\n Выберите пункт меню: ");
                var m = Convert.ToInt32(Console.ReadLine());
                switch (m)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.Write("\n Введите колличество процессов: ");
                            var k = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < k; i++)
                            {
                                System.Threading.Thread.Sleep(500);
                                Console.Write("\n Создание {0} процесса", i + 1);
                                var rand = new Random();
                                var nameR = rand.Next(0, 1000);
                                var sizeR = rand.Next(0, 100);
                                var timestartR = rand.Next(0, 20);
                                var timeworkR = rand.Next(0, 20);
                                ProcessList.Add(new MyProcess { Name = Convert.ToString(nameR), Size = sizeR, Timestart = timestartR, Timework = timeworkR });
                                ReserveMemory(ProcessList.Last());
                            }
                            Pause();
                            break;
                        }
                    case 2:
                        {
                            var reader = new StreamReader("process_list.txt");
                            while (true)
                            {
                                var s = reader.ReadLine();
                                if (s == null)
                                    break;
                                var lines = s.Split(new[] { ' ' });
                                ProcessList.Add(new MyProcess { Name = lines[0], Size = Convert.ToInt32(lines[1]), Timestart = Convert.ToInt32(lines[2]), Timework = Convert.ToInt32(lines[3]) });
                                ReserveMemory(ProcessList.Last());
                            }
                            reader.Close();
                            Pause();
                            break;
                        }
                    case 3:
                        {
                            RandomWork(ProcessList);
                            break;
                        }
                    case 4:
                        {
                            exit = false;
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("\n ERROR: Неверный выбор!");
                            Pause();
                            break;
                        }
                }
            }

        }

        // Алгоритм атмоматизации выделения памяти и выгрузки процесса
        public static void RandomWork(List<MyProcess> processes)
        {
            _random = true;
            _run = true;
            Console.Clear();
            Console.WriteLine("\n Начинаем!");
            var maxtime = processes.Select(myProcess => myProcess.Timestart + myProcess.Timework).Concat(new[] {0}).Max();
            for (var i = 0; i <= maxtime; i++)
            {
                foreach (var myProcess in processes)
                {
                    if (myProcess.Timestart == i)
                        ReserveMemory(myProcess);
                    if (myProcess.Timestart + myProcess.Timework == i)
                        FreeAll(myProcess.Name);
                }
                Getstate();
                Console.WriteLine("\n Цикл: {0}", i);
                Pause();
                Console.Clear();
            }
            CleanMemory();
            _random = false;
            _run = false;
            foreach (var page in _pageList)
                RemoveProcess(page);
            Pause();
        }

        // Последовательное чтение из памяти (Исправление не требуется)
        private static void Read()
        {
            Console.Clear();
            Console.Write("\n Номер раздела: ");
            var number = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Смещение: ");
            var ofseat = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Колличество считываемых элементов: ");
            var len = Convert.ToInt32(Console.ReadLine());
            var page = _pageList[number - 1];
            var tmp = page.FirstAddress + ofseat;
            Console.WriteLine("\n Список адресов ячеек и данных в них:\n");
            for (int i = 0; i < len; i++)
            {
                var adr = tmp + i;
                Console.Write("  Адресс: {0} Содержимое: {1}\n", adr, Memory[adr]);
            }
            Pause();
        }

        // Последовательная запись ячеек памяти (Исправление не требуется)
        private static void Write()
        {
            Console.Clear();
            Console.Write("\n Введите колличество записываемых эленентов: ");
            var k = Convert.ToInt32(Console.ReadLine());
            var input = new byte[k];
            Console.Write("\n");
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(" Введите {0} эленент: ", i + 1);
                var value = Convert.ToByte(Console.ReadLine());
                input[i] = value;
            }
            Console.Write("\n Номер раздела: ");
            var number = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Смещение: ");
            var ofseat = Convert.ToInt32(Console.ReadLine());
            var page = _pageList[number - 1];
            var tmp = page.FirstAddress + ofseat;
            Array.Copy(input, 0, Memory, tmp, input.Length);
            Console.Write("\n MES: Запись элементов выполнена!\n");
            Pause();
        }

        // Удаление процессов (Исправление не требуется)
        private static void Free()
        {
            bool exit = true;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("\n Удаление:\n");
                Console.WriteLine("  1. По имени процесса");
                Console.WriteLine("  2. По номеру раздела");
                Console.WriteLine("  3. Очистить все разделы");
                Console.WriteLine("  4. Exit");
                Console.Write("\n Выберите пункт меню: ");
                var m = Convert.ToInt32(Console.ReadLine());
                switch (m)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.Write("\n Ввести имя процесса: ");
                            var name = Console.ReadLine();
                            FreeAll(name);
                            exit = false;
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.Write("\n Ввести номер раздела: ");
                            var number = Convert.ToInt32(Console.ReadLine());
                            var page = _pageList[number - 1];
                            RemoveProcess(page);
                            Console.WriteLine("\n MES: Удалиние выполнено!");
                            exit = false;
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            foreach (var page in _pageList)
                                RemoveProcess(page);
                            Console.WriteLine("\n MES: Удалиние выполнено!");
                            exit = false;
                            break;
                        }
                    case 4:
                        {
                            exit = false;
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("\n ERROR: Неверный выбор!");
                            Console.Write("\n Нажмите любую клавишу для продолжения . . . ");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
            Pause();
        }

        // Удаления процессов по имени (Исправление не требуется)
        private static void FreeAll(string name)
        {
            bool isHandled = false;
            foreach (var page in _pageList)
            {
                if (page.CurrentProcess != null
                    && page.CurrentProcess.Name == name)
                {
                    isHandled = true;
                    Console.WriteLine("\n MES: Удаление выполнено!");
                    RemoveProcess(page);
                    break;
                }
            }
            if (isHandled != true)
                Console.WriteLine("\n ERROR: Такого имени нет!");
        }

        // Удаление процесса и замена на новый процесс из очереди (Исправление не требуется)
        private static void RemoveProcess(Page page)
        {
            page.CurrentProcess = null;
            var p = page.Queue.FirstOrDefault();
            if (p != null)
            {
                ++_requestOk;
                page.CurrentProcess = p;
                page.Queue.Remove(p);
            }
        }

        // Метод довавления процесса (Исправление не требуется)
        private static void Reserve()
        {
            Console.Clear();
            Console.Write("\n Ввести имя: ");
            var name = Console.ReadLine();
            Console.Write("\n Ввести размер: ");
            var size = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Время запуска: ");
            var timestars = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Время работы: ");
            var timework = Convert.ToInt32(Console.ReadLine());
            var process = new MyProcess { Name = name, Size = size, Timestart = timestars, Timework = timework };
            ProcessList.Add(new MyProcess { Name = process.Name, Size = process.Size, Timestart = process.Timestart, Timework = process.Timework });
            ReserveMemory(process);
            Pause();
        }

        // Очистка всех очередей
        private static void CleanMemory()
        {
            foreach (var page in _pageList)
                page.Queue.Clear();
            ProcessList.Clear();
        }

        // Выделение памяти (Исправлено)
        private static void ReserveMemory(MyProcess process)
        {
            bool isHandled = false;
            ++_request;
            if (_pageList.Last().Length - _pageList.Last().FirstAddress
                < process.Size)
            {
                Console.WriteLine("\n ERROR: Размер процесса больше любого созданного раздела!");
                return;
            }

            if (!_run)
            {
                for (int i = 0; i < _pageList.Length; i++)
                {
                    var page = _pageList[i];
                    if ((page.Length - page.FirstAddress) >= process.Size)
                    {
                        page.Queue.Add(process);
                        Console.WriteLine("\n MES: Объект добавлен в очередь на {0} раздел!", i + 1);
                        break;
                    }
                }
            }
            else
            {
                foreach (var page in _pageList)
                {
                    if ((page.Length - page.FirstAddress) >= process.Size
                        && page.CurrentProcess == null)
                    {
                        page.CurrentProcess = process;
                        isHandled = true;
                        ++_requestOk;
                        Console.WriteLine("\n MES: Процессу выделена память. Время работы: {0}", process.Timework);
                        if (_random)
                        {
                            var p = page.Queue.FirstOrDefault();
                            if (p != null)
                            {
                                page.Queue.Remove(p);
                            }
                        }
                        break;
                    }
                }
                if (!isHandled)
                {
                    for (int i = 0; i < _pageList.Length; i++)
                    {
                        var page = _pageList[i];
                        if (page.Length - page.FirstAddress
                            >= process.Size)
                        {
                            page.Queue.Add(process);
                            Console.WriteLine("\n MES: Объект добавлен в очередь на {0} раздел!", i + 1);
                            break;
                        }
                    }
                }
            }
        }

        // Метод вывода информации (Исправлено)
        private static void Getstate()
        {
            Console.Clear();
            int allSection = 0;
            int freeSection = 0;
            int biggestSection = 0;
            foreach (var page in _pageList)
            {
                allSection += (page.Length - page.FirstAddress);
                if (page.CurrentProcess == null)
                {
                    freeSection += (page.Length - page.FirstAddress);
                    if ((page.Length - page.FirstAddress) > biggestSection)
                        biggestSection = (page.Length - page.FirstAddress);
                }
            }
            float procent;
            if (Math.Abs(_request) <= 0)
                procent = 0;
            else
                procent = (_requestOk / _request) * 100;
            Console.WriteLine("\n Кол-во всего пам {0}", allSection);
            Console.WriteLine(" Кол-во свободной пам {0}", freeSection);
            Console.WriteLine(" Самый большой свободный {0}", biggestSection);
            Console.WriteLine(" Количество запросов на выделение памяти {0}", _request);
            Console.WriteLine(" Количество OK запросов на выделение памяти {0} ({1:0}%)", _requestOk, procent);
            Console.WriteLine("\n Список текущих процессов:");
            foreach (var page in _pageList)
            {
                if (allSection == freeSection)
                {
                    Console.WriteLine(" Текущих процессов нет!");
                    break;
                }
                if (page.CurrentProcess != null)
                    Console.Write(" Имя процесса: " + page.CurrentProcess.Name + " Размер процесса: " + page.CurrentProcess.Size + " Время работы: " + page.CurrentProcess.Timework + " Размер раздела: " + (page.Length - page.FirstAddress) + "\n");
            }
            Console.WriteLine("\n На очередях следующие процессы: ");
            foreach (var page in _pageList)
            {
                foreach (var number in page.Queue)
                {
                    Console.WriteLine(" Имя: " + number.Name + " Размер: " + number.Size + " Время старта: " + number.Timestart + " Время работы: " + number.Timework);
                }
            }
            Console.WriteLine("\n Графическое представление занятых ячеек памяти:");
            Console.WriteLine("\n Обозначения:");
            Console.WriteLine(" | - Графическое разделение памяти на разделы");
            Console.WriteLine(" Серый - ячейка пямяти не задействована процессом");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Красный");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" - ячейка пямяти задействована процессом\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Зелёный");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" - ячейка (раздел) пямяти свободнана\n\n");
            foreach (var page in _pageList)
            {
                if (page.CurrentProcess != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    for (int i = 0; i < page.CurrentProcess.Size; i++)
                        Console.Write("#");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    for (int i = page.CurrentProcess.Size; i < (page.Length - page.FirstAddress); i++)
                        Console.Write("#");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = page.FirstAddress; i < page.Length; i++)
                        Console.Write("#");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.Write("\n");
            }
        }
    }
}