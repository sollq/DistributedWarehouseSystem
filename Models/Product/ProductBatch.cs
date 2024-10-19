namespace DistributedWarehouseSystem.Models.Product
{
    public class ProductBatch(Product product, int quantity)
    {
        public Product Product { get; } = product ?? throw new ArgumentNullException(nameof(product));
        public int Quantity { get; set; } = quantity;
    }
}