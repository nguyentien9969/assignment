namespace ass4
{
    public class Program
    {
        public static void Main()
        {
            Clock myClock = new Clock();

            DigitalClock c2 = new DigitalClock();

            c2.Subscribe(myClock);
            myClock.Run();
        }
    }

}