using DistributedWarehouseSystem.Strategy;

namespace DistributedWarehouseSystem.Models
{
    public class Truck(string type, double capacity, ILoadingStrategy strategy)
    {
        public string Type { get; set; } = type;
        public double Capacity { get; set; } = capacity;
        public List<Product> LoadedProducts { get; set; } = [];

        public void Load(Product product, int quantity)
        {
            strategy.Load(this, product, quantity);
        }
    }
}