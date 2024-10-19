using DistributedWarehouseSystem.Models.Silo;
using DistributedWarehouseSystem.Models.Truck;

namespace DistributedWarehouseSystem.Strategy
{
    public class LogisticsManager(List<ITruck> trucks)
    {
        private int _totalDeliveries = 0;
        private double _totalWeightDelivered = 0;

        public void Dispatch(ISilo silo)
        {
            var products = silo.GetAllProducts();
            var totalProductWeight = products.Sum(p => p.Weight);

            foreach (var truck in trucks)
            {
                if (!(totalProductWeight > 0)) continue;
                var truckCapacity = truck.MaxCapacity;
                var loadableProducts = products.TakeWhile(p => p.Weight <= truckCapacity).ToList();
                var loadableWeight = loadableProducts.Sum(p => p.Weight);

                if (!(loadableWeight > 0)) continue;
                truck.Load(loadableProducts);
                _totalDeliveries++;
                _totalWeightDelivered += loadableWeight;
                silo.ReleaseProductsForDelivery(loadableProducts);

                totalProductWeight -= loadableWeight;
            }

            if (totalProductWeight > 0)
            {
                Console.WriteLine("Нет доступного грузовика с достаточной вместимостью для оставшейся продукции.");
            }
        }

        public void PrintStatistics()
        {
            Console.WriteLine($"Всего доставок: {_totalDeliveries}");
            Console.WriteLine($"Общий вес доставленной продукции: {_totalWeightDelivered}");
            if (_totalDeliveries > 0)
            {
                Console.WriteLine($"Средний вес продукции за доставку: {_totalWeightDelivered / _totalDeliveries}");
            }
        }
    }
}