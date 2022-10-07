using System;
namespace asss5.Event
{
    public class Clock
    {
        private readonly int _second;

        public delegate void clockTickEventHandler(object clock, ClockInfoEventArgs args);

        public event clockTickEventHandler clockTickEvent;

        public void OnTick(object clock, ClockInfoEventArgs ClockInfoEventArgs)
        {
            if (clockTickEvent != null)
            {
                clockTickEvent(clock, ClockInfoEventArgs);
            }
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1000);
                var time = DateTime.Now;
                if ( time.Second != _second)
                {
                    var ClockInfoEventArgs = new ClockInfoEventArgs(time.Hour, time.Minute, time.Second);
                    OnTick(this, ClockInfoEventArgs);
                }
            }
        }
    }
}