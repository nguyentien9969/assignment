namespace asss5
{
    public class Clock
    {
        public delegate void secondHandler(object ob, EventArgs info);

        public event secondHandler onSecondChange;

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1000);
                onSecondChange(this, new EventArgs());
            }
        }
    }
}