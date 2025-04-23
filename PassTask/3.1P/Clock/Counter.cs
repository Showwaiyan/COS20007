namespace ClockProgram
{
    public class Counter
    {
        private int _count;
        private string _name;
        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public void Increment()
        {
            _count += 1;
        }

        public void Reset()
        {
            _count = 0;
        }
        public void ResetByDefault()
        {
            // Answer for 13
            // _count = 2147483647041;
            // above value create the crash(error) for the compile time
            // due to overflow of integer which is _count
            // to run safetly (However, _count will get unexcpeted value), we can use
            // uncheckd block, which neglecte the overflow exception throw and
            // use explictly type cast to in
            // becuase 2147483647041 is bigger than int max value
            unchecked
            {
                _count = (int)2147483647041;
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Ticks
        {
            get { return _count; }
        }
    }
}
