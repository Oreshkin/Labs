using System;
using System.Collections.Generic;

namespace MemoryMan_lab_5
{
    public class ClickTimer : ITimer
    {
        private const int TickSize = 1000;

        private static readonly List<ClickTimer> Timers = new List<ClickTimer>();
        private static int _counter;

        private Action<int> _a;
        private int _interval;
        private int _curInterval;

        public static ITimer CreateTimer()
        {
            var t = new ClickTimer();
            Timers.Add(t);
            return t;
        }

        public static int Next()
        {
            foreach (var clickTimer in Timers)
                clickTimer.DoNext();

            _counter += TickSize;
            return _counter;
        }

        public void SetAction(Action<int> a)
        {
            _a = a;
        }

        public bool Enabled { get; set; }

        public int Interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
                _curInterval = 0;
            }
        }

        private void DoNext()
        {
            if (!Enabled)
                return;

            if (_curInterval < _interval)
            {
                _curInterval += TickSize;
                return;
            }

            _a(0);
            _curInterval = 0;
        }
    }
}