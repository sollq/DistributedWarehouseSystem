using DistributedWarehouseSystem.Models.Product;

namespace DistributedWarehouseSystem.Models.Silo
{
    public interface ISilo
    {
        double Capacity { get; }
        double CurrentLoad { get; }
        bool IsFull { get; }
        void Store(IProduct product);
        void ReleaseProductsForDelivery(List<IProduct> products);
        List<IProduct> GetAllProducts();
    }
}