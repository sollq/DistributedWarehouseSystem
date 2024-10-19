using System.Collections.Concurrent;
using DistributedWarehouseSystem.Models.Product;

namespace DistributedWarehouseSystem.Models.Silo
{
    public class Silo(int capacity)
    {
        private readonly ConcurrentQueue<ProductBatch> _productQueue = new ConcurrentQueue<ProductBatch>();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        public int Capacity { get; } = capacity;

        public async Task AddProductAsync(Product.Product product, int quantity)
        {
            await _semaphore.WaitAsync();
            try
            {
                _productQueue.Enqueue(new ProductBatch(product, quantity));
            }
            finally
            {
                _semaphore.Release();
            }
        }
        public async Task<ProductBatch> GetProductAsync(int maxQuantity)
        {
            await _semaphore.WaitAsync();
            try
            {
                if (_productQueue.TryDequeue(out var batch))
                {
                    int quantityToTake = Math.Min(batch.Quantity, maxQuantity);
                    batch.Quantity -= quantityToTake;

                    if (batch.Quantity > 0)
                    {
                        _productQueue.Enqueue(batch);
                    }
                    return new ProductBatch(batch.Product, quantityToTake);
                }
                return null;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}