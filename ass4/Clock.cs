namespace ass4
{
    public class Clock
    {
        public delegate void SecondChangeHandler(object clock, EventArgs info);
        public event SecondChangeHandler OnSecondChange;
        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (OnSecondChange != null)
                    OnSecondChange(this, new EventArgs());
            }
        }
    }

}