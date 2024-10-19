namespace DistributedWarehouseSystem.Models.Product
{
    public interface IProduct
    {
        string Name { get; }
        double Weight { get; }
        string Packaging { get; }
    }
}