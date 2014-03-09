using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Program
    {
        static int _request = 0;
        static int _requestOk = 0;
        private static void Main()
        {
            bool exit = true;

            Console.WriteLine("Ввод начальных данных\n");
            Console.Write("Введите ко-во страниц: ");
            var k = Convert.ToInt32(Console.ReadLine());

            var pageList = new Page[k];

            for (var i = 0; i < k; i++)
            {
                Console.Write("Введите размер раздела под номером {0}: ", i + 1);
                var tmp = Convert.ToInt32(Console.ReadLine());
                pageList[i] = new Page { Memory = new byte[tmp] };
            }

            // сортировка
            Console.Clear();
            while (exit)
            {
                Console.WriteLine("1. Вывод информации");
                Console.WriteLine("2. Добавить");
                Console.WriteLine("3. Удалить");
                Console.WriteLine("4. Записать");
                Console.WriteLine("5. Чтение");
                Console.WriteLine("6. Random");
                Console.WriteLine("7. Exit");

                var m = Convert.ToInt32(Console.ReadLine());
                switch (m)
                {
                    case 1:
                        Getstate(pageList);
                        break;
                    case 2:
                        Reserve(pageList);
                        break;
                    case 3:
                        Free(pageList);
                        break;
                    case 4:
                        //Write(pageList);
                        break;
                    case 5:
                        //Read(pageList);
                        break;
                    case 6:
                        //My_random(pageList);
                        break;
                    case 7:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }

        private static void Free(Page[] pageList)
        {
            bool exit = true;
            bool isHandled = false;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("1. По имени процесса");
                Console.WriteLine("2. По номеру раздела");
                Console.WriteLine("3. Очистить все разделы");

                var m = Convert.ToInt32(Console.ReadLine());
                switch (m)
                {
                    case 1:
                        Console.WriteLine("Ввести имя процесса");
                        var name = Console.ReadLine();

                        foreach (var page in pageList)
                            if (page.CurrentProcess != null && page.CurrentProcess.Name == name)
                            {
                                page.CurrentProcess = null;
                                isHandled = true;
                                Console.WriteLine("MES: Удалиние выполнено!");

                                var p = page.Queue.FirstOrDefault(); // замена на новый процесс из очереди
                                page.CurrentProcess = p;
                                if (p != null)
                                {
                                    page.Queue.Remove(p);
                                }

                                break;
                            }

                        if (isHandled != true)
                            Console.WriteLine("ERROR: Такого имени нет!");

                        exit = false;
                        break;
                    case 2:
                        Console.WriteLine("Ввести номер раздела");
                        var number = Convert.ToInt32(Console.ReadLine());
                        pageList[number].CurrentProcess = null;
                        Console.WriteLine("MES: Удалиние выполнено!");

                        /*var v = page.Queue.LastOrDefault(); // замена на новый процесс из очереди
                        page.CurrentProcess = v;
                        if (v != null)
                        {
                            page.Queue.Remove(v);
                        }*/

                        exit = false;
                        break;
                    case 3:
                        foreach (var page in pageList)
                        {
                            page.CurrentProcess = null;
                        }
                        Console.WriteLine("MES: Удалиние выполнено!");

                        /*var v = page.Queue.LastOrDefault(); // замена на новый процесс из очереди
                        page.CurrentProcess = v;
                        if (v != null)
                        {
                            page.Queue.Remove(v);
                        }*/


                        exit = false;
                        break;
                    case 4:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }


                /*var v = page.queue.LastOrDefault();
            if (v != null)
            {
                page.queue.Remove(process);

            }*/
            }
        }

        /// <summary>
        /// Метод довавления процесса
        /// isHandled - bool переменная для проверки добавлен ли проценн
        /// name - имя процесса
        /// size - размер процесса
        /// </summary>
        /// <param name="pageList">Список разделов</param>

        private static void Reserve(Page[] pageList)
        {
            bool isHandled = false;
            Console.WriteLine("Ввести имя");
            var name = Console.ReadLine();
            Console.WriteLine("Ввести размер");
            var size = Convert.ToInt32(Console.ReadLine());
            var process = new MyProcess { Name = name, Size = size };

            if (pageList.Last().Memory.Length < process.Size)
            {
                Console.WriteLine("ERROR: Размер процесса больше любого созданного раздела!");
                _request += 1;
            }

            foreach (var page in pageList)
                if (page.Memory.Length >= process.Size && page.CurrentProcess == null)
                {
                    page.CurrentProcess = process;
                    isHandled = true;
                    _request += 1;
                    _requestOk += 1;
                    break;
                }

            if (isHandled != true)
                for (int i = 0; i < pageList.Length; i++)
                {
                    var page = pageList[i];
                    if (page.Memory.Length >= process.Size)
                    {
                        page.Queue.Add(process);
                        _request += 1;
                        Console.WriteLine("MES: Объект добавлен в очередь на {0} раздел!", i + 1);
                        break;
                    }
                }

        }

        /// <summary>
        /// Метод вывода информации
        /// allSection - Кол-во всей памяти
        /// freeSection - Кол-во свободной памяти
        /// biggestSection - Наибольший блок 
        /// </summary>
        /// <param name="pageList">Массив страниц</param>

        private static void Getstate(IEnumerable<Page> pageList)
        {
            int allSection = 0;
            int freeSection = 0;
            int biggestSection = 0;
            foreach (var page in pageList)
            {
                allSection += page.Memory.Length;
                if (page.CurrentProcess == null)
                {
                    freeSection += page.Memory.Length;
                    if (page.Memory.Length > biggestSection)
                    {
                        biggestSection = page.Memory.Length;
                    }
                }
            }
            Console.WriteLine("Кол-во всего пам {0}", allSection);
            Console.WriteLine("Кол-во свободной пам {0}", freeSection);
            Console.WriteLine("Самый большой свободный {0}", biggestSection);
            Console.WriteLine("Количество запросов на выделение памяти {0}", _request);
            Console.WriteLine("Количество OK запросов на выделение памяти {0}", _requestOk);
            foreach (var page in pageList)
            {
                if (page.CurrentProcess != null)
                {
                    Console.WriteLine(page.CurrentProcess.Name);
                    Console.WriteLine(page.CurrentProcess.Size);
                }
            }
        }
    }

    /// <summary>
    /// Класс страница (раздел)
    /// Memory - массив памяти
    /// List MyProcess - список процессов
    /// CurrentProcess - текущий процесс
    /// </summary>

    internal class Page
    {
        public byte[] Memory;
        public List<MyProcess> Queue = new List<MyProcess>();
        public MyProcess CurrentProcess;
        public int[][] Block;
    }

    /// <summary>
    /// Класс процессов
    /// Name - имя процесса
    /// Size - размер процесса
    /// </summary>

    internal class MyProcess
    {
        public string Name;
        public int Size;
    }
}