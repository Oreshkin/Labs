using System.Collections.Generic;

namespace ConsoleApplication1
{
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
    }
}