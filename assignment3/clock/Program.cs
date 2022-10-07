using asss5.Event;

namespace asss5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Clock clock = new Clock();
            DigitalClock digitalClock = new DigitalClock();
            digitalClock.Subscribe(clock);
            clock.Run();
        }
    }
}