namespace Tuto
{
    public class WolfPack
    {
        private int _count;
        private List<Wolf> wolves = new List<Wolf>();

        public string hunt(Rabbit rabbit)
        {
            return $"Wolf Packs is hunting Rabbits, Breed {rabbit.Breed}";
        }

    }
}
