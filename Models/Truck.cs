namespace DistributedWarehouseSystem.Models;

public class Truck(string type, double capacity)
{
    public string Type { get; set; } = type;
    public double Capacity { get; set; } = capacity;

    public List<Product> LoadedProducts { get; set; } = new List<Product>();
    //private readonly ILoadingStrategy loadingStrategy;

    //loadingStrategy = strategy;

    public void Load(Product product, int quantity)
    {
        
    }
}