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
        private static int _request = 0;
        private static int _requestOk = 0;
        private static byte[] _memory = new byte[60000];
        private static Page[] _pageList;

        private static void Main()
        {
            bool exit = true;
            var start = 0;

            Console.WriteLine( "Ввод начальных данных\n" );
            Console.Write( "Введите ко-во страниц: " );
            var k = Convert.ToInt32( Console.ReadLine() );

            _pageList = new Page[k];

            for ( var i = 0; i < k; i++ )
            {
                Console.Write( "Введите размер раздела под номером {0}: ", i + 1 );
                var tmp = Convert.ToInt32( Console.ReadLine() );
                _pageList[i] = new Page { FirstAddress = start, Length = tmp };
                start += tmp;
            }

            // сортировка
            Array.Sort( _pageList, ( page, page1 ) =>
            {
                if ( page.Length
                    > page1.Length )
                    return 1;

                if ( page.Length
                    < page1.Length )
                    return -1;

                return 0;
            } );

            Console.Clear();
            while ( exit )
            {
                Console.WriteLine( "\n1. Вывод информации" );
                Console.WriteLine( "2. Добавить" );
                Console.WriteLine( "3. Удалить" );
                Console.WriteLine( "4. Записать" );
                Console.WriteLine( "5. Чтение" );
                Console.WriteLine( "6. Random" );
                Console.WriteLine( "7. Exit" );

                var m = Convert.ToInt32( Console.ReadLine() );
                switch ( m )
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
                        Console.WriteLine( "Неверный выбор!" );
                        break;
                }
            }
        }

        private static void My_random()
        {
            //var processList = new List<MyProcess>();
            var processList = new List<MyProcess>
            { 
                new MyProcess { Name = "1", Size = 50, Timestart = 5, Timework = 5 },
                new MyProcess { Name = "2", Size = 50, Timestart = 0, Timework = 5 },
            };

            Console.WriteLine("Начинаем!");

            var maxtime = 0;
            foreach ( var myProcess in processList )
            {
                var tmp = myProcess.Timestart + myProcess.Timework;
                if ( tmp > maxtime )
                    maxtime = tmp;
            }

            for ( int i = 0; i <= maxtime; i++ )
            {
                System.Threading.Thread.Sleep( 1000 );
                Console.WriteLine("Цикл №{0}", i);
                foreach ( var myProcess in processList )
                {
                    if ( myProcess.Timestart == i )
                        ReserveMemory( myProcess );
                    if ( myProcess.Timestart + myProcess.Timework == i )
                        FreeAll( myProcess.Name );
                }
            }
        }

        private static void Read()
        {
            var number = 1;
            var ofseat = 5;
            var len = 10;

            var page = _pageList[number];
            var tmp = page.FirstAddress + ofseat;

            for ( int i = 0; i < len; i++ )
            {
                var adr = tmp + i;
                Console.Write( "{0},{1} ", adr, _memory[adr] );
            }
        }

        private static void Write()
        {
            //var input = new byte[2];
            var input = new byte[] { 10, 21 };
            var number = 1;
            var ofseat = 5;

            var page = _pageList[number];
            var tmp = page.FirstAddress + ofseat;

            //Array.Copy( input, 0, _memory, tmp, input.Length );

            for ( int i = 0; i < input.Length; i++ )
            {
                _memory[tmp + i] = input[i];
                Console.Write( "" );
            }
        }

        private static void Free()
        {
            bool exit = true;
            while ( exit )
            {
                Console.Clear();
                Console.WriteLine( "1. По имени процесса" );
                Console.WriteLine( "2. По номеру раздела" );
                Console.WriteLine( "3. Очистить все разделы" );

                var m = Convert.ToInt32( Console.ReadLine() );
                switch ( m )
                {
                    case 1:
                        Console.WriteLine( "Ввести имя процесса" );
                        var name = Console.ReadLine();
                        
                        FreeAll( name );

                        exit = false;

                        break;
                    case 2:
                    {
                        Console.WriteLine( "Ввести номер раздела" );
                        var number = Convert.ToInt32( Console.ReadLine() );
                        var page = _pageList[number-1];
                        RemoveProcess( page );
                        Console.WriteLine( "MES: Удалиние выполнено!" );

                        exit = false;
                        break;
                    }
                    case 3:
                        foreach ( var page in _pageList )
                            RemoveProcess( page );
                        Console.WriteLine( "MES: Удалиние выполнено!" );

                        exit = false;
                        break;
                    case 4:
                        exit = false;
                        break;
                    default:
                        Console.WriteLine( "Неверный выбор!" );
                        break;
                }
            }
        }

        private static void FreeAll( string name )
        {
            bool isHandled = false;
            foreach ( var page in _pageList )
            {
                if ( page.CurrentProcess != null
                    && page.CurrentProcess.Name == name )
                {
                    isHandled = true;
                    Console.WriteLine( "MES: Удалиние выполнено!" );

                    RemoveProcess( page );

                    break;
                }
            }

            if ( isHandled != true )
                Console.WriteLine( "ERROR: Такого имени нет!" );
        }

        private static void RemoveProcess( Page page )
        {
            page.CurrentProcess = null;

            // замена на новый процесс из очереди
            var p = page.Queue.FirstOrDefault();
            if ( p != null )
            {
                ++_requestOk;
                page.CurrentProcess = p;
                page.Queue.Remove( p );
            }
        }

        /// <summary>
        /// Метод довавления процесса
        /// isHandled - bool переменная для проверки добавлен ли проценн
        /// name - имя процесса
        /// size - размер процесса
        /// </summary>
        /// <param name="pageList">Список разделов</param>
         
         
        private static void Reserve()
        {
            Console.WriteLine( "Ввести имя" );
            var name = Console.ReadLine();
            Console.WriteLine( "Ввести размер" );
            var size = Convert.ToInt32( Console.ReadLine() );
            var process = new MyProcess { Name = name, Size = size };

            ReserveMemory( process);
        }

        private static void ReserveMemory( MyProcess process )
        {
            bool isHandled = false;

            ++_request;

            if ( _pageList.Last().Length
                < process.Size )
            {
                Console.WriteLine( "ERROR: Размер процесса больше любого созданного раздела!" );
                return;
            }

            foreach ( var page in _pageList )
            {
                if ( page.Length >= process.Size
                    && page.CurrentProcess == null )
                {
                    page.CurrentProcess = process;
                    isHandled = true;
                    _requestOk += 1;
                    Console.WriteLine("Процессу выделена память");
                    break;
                }
            }

            if ( !isHandled )
            {
                for ( int i = 0; i < _pageList.Length; i++ )
                {
                    var page = _pageList[i];
                    if ( page.Length
                        >= process.Size )
                    {
                        page.Queue.Add( process );
                        Console.WriteLine( "MES: Объект добавлен в очередь на {0} раздел!", i + 1 );
                        break;
                    }
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
        private static void Getstate()
        {
            int allSection = 0;
            int freeSection = 0;
            int biggestSection = 0;
            foreach ( var page in _pageList )
            {
                allSection += page.Length;
                if ( page.CurrentProcess == null )
                {
                    freeSection += page.Length;
                    if ( page.Length > biggestSection )
                        biggestSection = page.Length;
                }
            }
            Console.WriteLine( "Кол-во всего пам {0}", allSection );
            Console.WriteLine( "Кол-во свободной пам {0}", freeSection );
            Console.WriteLine( "Самый большой свободный {0}", biggestSection );
            Console.WriteLine( "Количество запросов на выделение памяти {0}", _request );
            Console.WriteLine( "Количество OK запросов на выделение памяти {0}", _requestOk );
            foreach ( var page in _pageList )
            {
                if ( page.CurrentProcess != null )
                {
                    Console.WriteLine( page.CurrentProcess.Name );
                    Console.WriteLine( page.CurrentProcess.Size );
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
        public int FirstAddress;
        public int Length;
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
        public int Timestart;
        public int Timework;
    }
}