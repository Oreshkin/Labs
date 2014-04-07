using System;
using System.Collections.Generic;

namespace MemoryMan_lab_5
{
    public class ClickTimer : ITimer
    {
        private const int TickSize = 1000;

        private static readonly List<ClickTimer> Timers = new List<ClickTimer>(); // список всех таймеров
        private static int _counter; // показ на кнопке

        private Action<int> _a; // DOT.net 2.0 нет делегата без параметра
        private int _interval;
        private int _curInterval;

        public static ITimer CreateTimer() // создание таймера
        {
            var t = new ClickTimer();
            Timers.Add(t);
            return t;
        }

        public static int Next() // вызов с кнопки увеличение на 1000
        {
            foreach (var clickTimer in Timers)
                clickTimer.DoNext();

            _counter += 1; // на кнопке
            return _counter;
        }

        public void SetAction(Action<int> a)
        {
            _a = a;
        }

        public bool Enabled { get; set; } // елили false nj dct

        public int Interval // при установке нового сбрасываем текуший
        {
            get { return _interval; }
            set
            {
                _interval = value;
                _curInterval = 0;
            }
        }

        private void DoNext() // если ьекущий достигает заданного то сбрасывается
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