namespace SwinAdventure
{
    public interface IHaveInventory
    {
        public GameObject Locate(string id);
        public string Name { get; }
        public Inventory Inventory { get; }
    }
}
