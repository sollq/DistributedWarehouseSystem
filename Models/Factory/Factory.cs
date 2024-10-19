namespace DistributedWarehouseSystem.Models.Factory
{
    public class Factory(string name, Product.Product product, int productionRate)
    {
        public string Name { get; } = name;
        public Product.Product Product { get; } = product;
        public int ProductionRate { get; } = productionRate;
        public async Task ProduceAsync(Silo.Silo silo, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(1000, token);

                var producedUnits = ProductionRate;
                await silo.AddProductAsync(Product, producedUnits); // Добавляем продукцию на склад
                Console.WriteLine($"Продукция {Product.Name} добавлена на склад.");
            }
        }
    }
}