namespace asss5.Event
{
    public class ClockInfoEventArgs : EventArgs
    {
        public readonly int _hour;
        public readonly int _minute;
        public readonly int _second;

        public ClockInfoEventArgs(int x, int y, int z)
        {
            this._hour = x;
            this._minute = y;
            this._second = z;
        }
    }
}