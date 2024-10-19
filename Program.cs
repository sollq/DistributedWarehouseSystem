using DistributedWarehouseSystem.Models.Factory;
using DistributedWarehouseSystem.Models.Product;
using DistributedWarehouseSystem.Models.Silo;
using DistributedWarehouseSystem.Models.Truck;

namespace DistributedWarehouseSystem
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var silo = new Silo(500);
            var factoryA = new Factory("FactoryA", new Product("ProductA", 10, packaging: "def"), 50);
            var factoryB = new Factory("FactoryB", new Product("ProductB", 20, packaging: "metal"), 55);
            var factoryC = new Factory("FactoryC", new Product("ProductC", 30, packaging: "glass"), 60);

            var smallTruck = new Truck(100, "Small Truck");
            var largeTruck = new Truck(200, "Large Truck");

            var factoryTasks = new[]
            {
                factoryA.ProduceAsync(silo, token),
                factoryB.ProduceAsync(silo, token),
                factoryC.ProduceAsync(silo, token)
            };

            var truckTasks = new[]
            {
                smallTruck.DeliverAsync(silo, token),
                largeTruck.DeliverAsync(silo, token)
            };

            await Task.WhenAll(factoryTasks.Concat(truckTasks));
            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
            await cts.CancelAsync();
        }
    }
}