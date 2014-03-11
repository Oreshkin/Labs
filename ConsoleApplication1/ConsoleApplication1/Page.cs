using System.Collections.Generic;

namespace ConsoleApplication1
{
    internal class Page
    {
        public int FirstAddress;
        public int Length;
        public List<MyProcess> Queue = new List<MyProcess>();
        public MyProcess CurrentProcess;
    }
}