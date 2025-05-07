namespace ClockProgram
{
    public class Clock
    {
        // Fields
        private Counter _hour;
        private Counter _minute;
        private Counter _second;

        // Constructor
        public Clock()
        {
            _hour = new Counter("Hour");
            _minute = new Counter("Minute");
            _second = new Counter("Second");
        }

        // Methods
        public void Tick()
        {
            this.IncrementSecond();
        }

        public void Reset()
        {
            _second.Reset();
            _minute.Reset();
            _hour.Reset();
        }

        private void IncrementSecond()
        {
            _second.Increment();
            if (_second.Ticks == 60)
            {
                _second.Reset();
                this.IncrementMinute();
            }
        }
        private void IncrementMinute()
        {
            _minute.Increment();
            if (_minute.Ticks == 60)
            {
                _minute.Reset();
                this.IncrementHour();
            }
        }
        private void IncrementHour()
        {
            _hour.Increment();
            if (_hour.Ticks == 13)
            {
                _hour.Reset();
                _hour.Increment();
            }
        }

        public string GetTime()
        {
            return $"{this.Hour}:{this.Minute}:{this.Second}";
        }

        // Properties
        private string Hour
        {
            get
            {
                if (_hour.Ticks == 0) _hour.Increment();
                return _hour.Ticks.ToString("D2");
            }
        }
        private string Minute
        {
            get { return _minute.Ticks.ToString("D2"); }
        }
        private string Second
        {
            get { return _second.Ticks.ToString("D2"); }
        }
    }
}
