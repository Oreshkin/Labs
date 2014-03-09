using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static int _request;
        private static int _requestOk;
        private static byte[] _memory = new byte[60000];
        private static Page[] _pageList;

        // Основная программа
        private static void Main()
        {
            // Переменная для главного меню
            bool exit = true;
            // Переменная начало памяти
            var start = 0;

            // Ввод начальных данных (Кол-во разделов и их размер)
            Console.WriteLine("\n Ввод начальных данных\n");
            Console.Write(" Введите ко-во страниц: ");
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

            // Сортировка разделов по возрастаниюа
            Array.Sort(_pageList, (page, page1) =>
            {
                if (page.Length
                    > page1.Length)
                    return 1;

                if (page.Length
                    < page1.Length)
                    return -1;

                return 0;
            });

            // Главное меню
            while (exit)
            {
                // Очистка консоли
                Console.Clear();
                Console.WriteLine("\n Главное Меню:\n");
                Console.WriteLine("  1. Вывод информации");
                Console.WriteLine("  2. Добавить");
                Console.WriteLine("  3. Удалить");
                Console.WriteLine("  4. Записать");
                Console.WriteLine("  5. Чтение");
                Console.WriteLine("  6. Random");
                Console.WriteLine("  7. Exit");
                Console.Write("\n Выберите пункт меню: ");

                // Выбор пункта
                var m = Convert.ToInt32(Console.ReadLine());
                switch (m)
                {
                    case 1:
                        Getstate();
                        break;
                    case 2:
                        Reserve();
                        break;
                    case 3:
                        Free();
                        break;
                    case 4:
                        Write();
                        break;
                    case 5:
                        Read();
                        break;
                    case 6:
                        My_random();
                        break;
                    case 7:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("\n ERROR: Неверный выбор!");
                        Console.Write("\n Нажмите любую клавишу для продолжения . . . ");
            Console.ReadKey(true);
                        break;
                }
            }
        }

        // Автоматическое выделение и освобождение памяти
        private static void My_random()
        {
            Console.Clear();
            //var processList = new List<MyProcess>();
            var processList = new List<MyProcess>
            { 
                new MyProcess { Name = "1", Size = 50, Timestart = 5, Timework = 5 },
                new MyProcess { Name = "2", Size = 50, Timestart = 0, Timework = 5 },
            };

            Console.WriteLine("\n Начинаем!");

            var maxtime = 0;
            foreach (var myProcess in processList)
            {
                var tmp = myProcess.Timestart + myProcess.Timework;
                if (tmp > maxtime)
                    maxtime = tmp;
            }

            for (int i = 0; i <= maxtime; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("  Цикл № {0}", i);
                foreach (var myProcess in processList)
                {
                    if (myProcess.Timestart == i)
                    {
                        ReserveMemory(myProcess);
                    }
                    if (myProcess.Timestart + myProcess.Timework == i)
                        FreeAll(myProcess.Name);
                }
            }
            Console.Write("\n Нажмите любую клавишу для продолжения . . . ");
            Console.ReadKey(true);
        }

        // Последовательное чтение из памяти
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

                Console.Write("  Адресс: {0} Содержимое: {1}\n", adr, _memory[adr]);
            }
            Console.Write("\n Нажмите любую клавишу для продолжения . . . ");
            Console.ReadKey(true);
        }

        // Последовательная запись ячее в память
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

            Array.Copy(input, 0, _memory, tmp, input.Length);

            Console.Write("\n MES: Запись элементов выполнена!\n");
            Console.Write("\n Нажмите любую клавишу для продолжения . . . ");
            Console.ReadKey(true);
        }

        // Удаление процессов
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
            Console.Write("\n Нажмите любую клавишу для продолжения . . . ");
            Console.ReadKey(true);
        }

        // Удаления процессов по имени
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

        // Удаление процесса и замена на новый процесс из очереди
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

        // Метод довавления процесса
        private static void Reserve()
        {
            Console.Clear();
            Console.Write("\n Ввести имя: ");
            var name = Console.ReadLine();
            Console.Write("\n Ввести размер: ");
            var size = Convert.ToInt32(Console.ReadLine());
            var process = new MyProcess { Name = name, Size = size };

            ReserveMemory(process);
            Console.Write("\n Нажмите любую клавишу для продолжения . . . ");
            Console.ReadKey(true);
        }

        // Выделение памяти
        private static void ReserveMemory(MyProcess process)
        {
            bool isHandled = false;
            ++_request;
            if (_pageList.Last().Length
                < process.Size)
            {
                Console.WriteLine("\n ERROR: Размер процесса больше любого созданного раздела!");
                Console.Write("\n Нажмите любую клавишу для продолжения . . . ");
                Console.ReadKey(true);
                return;
            }
            foreach (var page in _pageList)
            {
                if (page.Length >= process.Size
                    && page.CurrentProcess == null)
                {
                    page.CurrentProcess = process;
                    isHandled = true;
                    ++_requestOk;
                    Console.WriteLine("\n MES: Процессу выделена память");
                    break;
                }
            }
            if (!isHandled)
            {
                for (int i = 0; i < _pageList.Length; i++)
                {
                    var page = _pageList[i];
                    if (page.Length
                        >= process.Size)
                    {
                        page.Queue.Add(process);
                        Console.WriteLine("\n MES: Объект добавлен в очередь на {0} раздел!", i + 1);
                        break;
                    }
                }
            }
        }

        // Метод вывода информации
        private static void Getstate()
        {
            Console.Clear();
            int allSection = 0;
            int freeSection = 0;
            int biggestSection = 0;
            foreach (var page in _pageList)
            {
                allSection += page.Length;
                if (page.CurrentProcess == null)
                {
                    freeSection += page.Length;
                    if (page.Length > biggestSection)
                        biggestSection = page.Length;
                }
            }
            Console.WriteLine("\n Кол-во всего пам {0}", allSection);
            Console.WriteLine(" Кол-во свободной пам {0}", freeSection);
            Console.WriteLine(" Самый большой свободный {0}", biggestSection);
            Console.WriteLine(" Количество запросов на выделение памяти {0}", _request);
            Console.WriteLine(" Количество OK запросов на выделение памяти {0}", _requestOk);
            Console.WriteLine("\n Список текущих процессов:");
            foreach (var page in _pageList)
            {
                if (page.CurrentProcess != null)
                {
                    Console.Write(" Имя процесса: " + page.CurrentProcess.Name + " Размер: " + page.CurrentProcess.Size + "\n");
                }
            }

            // TEST
            foreach (var page in _pageList)
            {
                if (page.CurrentProcess != null)
                {
                   for (int i = page.FirstAddress; i < page.Length; i++)
                   {
                       Console.ForegroundColor = ConsoleColor.DarkRed;
                       Console.Write("#");
                       Console.ForegroundColor = ConsoleColor.Gray;
                   }
                }
                else
                {
                    for (int i = page.FirstAddress; i < page.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("#");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
            for (int i = _pageList.Last().Length; i < 100; i++)
            {
                Console.Write("#");
            }

            Console.Write("\n Нажмите любую клавишу для продолжения . . . ");
            Console.ReadKey(true);
        }
    }
}