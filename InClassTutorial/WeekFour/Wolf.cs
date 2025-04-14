namespace Tuto
{
    public class Wolf
    {
        private string _breed;
        private bool _sex;
        public string role;

        public Wolf(string breed, bool sex, string role)
        {
            _breed = breed;
            _sex = sex;
            this.role = role;
        }

        public string eat()
        {
            return "Wolf is eating";
        }

        public string sleep()
        {
            return "Wolf is sleeping";
        }

        public string Breed
        {
            get { return _breed; }
        }
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}
