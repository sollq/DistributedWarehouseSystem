using DistributedWarehouseSystem.Models.Product;
using DistributedWarehouseSystem.Models.Silo;

namespace DistributedWarehouseSystem.Models.Factory
{
    public interface IFactory
    {
        string Name { get; }
        double ProductionRate { get; }
        IProduct ProductType { get; }
        Task ProduceAsync(ISilo silo);
    }
}