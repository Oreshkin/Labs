using System;
using System.Windows.Forms;

namespace MemoryMan_lab_5
{
    public class TimerWrapper : Timer, ITimer
    {
        public void SetAction( Action<int> a)
        {
            Tick += (sender, args) => a(0);
        }
    }
}