using asss5.Event;

namespace asss5
{
    public class DigitalClock
    {
        public void Subscribe(Clock clock)
        {
            clock.clockTickEvent += new Clock.clockTickEventHandler(Show);
        }
        public void Show(object clock, ClockInfoEventArgs clockInfoEventArgs)
        {
            Console.WriteLine("{0}:{1}:{2}", clockInfoEventArgs._hour, clockInfoEventArgs._minute, clockInfoEventArgs._second);
        }
    }
}