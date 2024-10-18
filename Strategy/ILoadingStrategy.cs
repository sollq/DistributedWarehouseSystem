using DistributedWarehouseSystem.Models;

namespace DistributedWarehouseSystem.Strategy;

public interface ILoadingStrategy
{
    void Load(Truck truck, Product product, int quantity);
}