namespace Tuto
{
    public class Rabbit
    {

        private string _breed;
        private bool _sex;

        public Rabbit(string breed, bool sex)
        {
            _breed = breed;
            _sex = sex;

        }

        public string eat()
        {
            return "Rabbit is eating";
        }

        public string sleep()
        {
            return "Rabbit is sleeping";
        }
        public string Breed
        {
            get { return _breed; }
        }
    }
}
