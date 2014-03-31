using System;

namespace MemoryMan_lab_5
{
    public interface ITimer
    {
        void SetAction(Action<int> a);
        bool Enabled { get; set; }
        int Interval { get; set; }
    }
}