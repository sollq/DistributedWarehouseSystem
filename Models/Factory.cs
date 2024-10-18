namespace DistributedWarehouseSystem.Models
{
    public class Factory(string name, Product product, double productionRate)
    {
        public string Name { get; set; } = name;
        public Product Product { get; set; } = product;
        public double ProductionRate { get; set; } = productionRate;
    }
}