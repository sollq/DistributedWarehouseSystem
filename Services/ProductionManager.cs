using DistributedWarehouseSystem.Models.Factory;
using DistributedWarehouseSystem.Models.Silo;

namespace DistributedWarehouseSystem.Services
{
    public class ProductionManager(List<IFactory> factories, ISilo silo)
    {
        public void StartProduction()
        {
            Task.WaitAll(factories.Select(factory => Task.Run(() => factory.ProduceAsync(silo))).ToArray());
        }
    }
}