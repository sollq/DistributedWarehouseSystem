using DistributedWarehouseSystem.Models;

namespace DistributedWarehouseSystem.Strategy
{
    public class DefaultLoadingStrategy : ILoadingStrategy
    {
        public void Load(Truck truck, Product product, int quantity)
        {
            truck.LoadedProducts.Add(product);
            Console.WriteLine($"Грузовик {truck.Type} загрузил {quantity} единиц продукта {product.Name}.");
        }
    }
}