namespace DistributedWarehouseSystem.Models
{
    public class Product(string name, double weight, string packagingType)
    {
        public string Name { get; set; } = name;
        public double Weight { get; set; } = weight;
        public string PackagingType { get; set; } = packagingType;
    }
}