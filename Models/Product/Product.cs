namespace DistributedWarehouseSystem.Models.Product
{
    public class Product(string name, double weight, string packaging) : IProduct
    {
        public string Name { get; private set; } = name;
        public double Weight { get; private set; } = weight;
        public string Packaging { get; private set; } = packaging;
    }
}