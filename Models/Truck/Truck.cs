namespace DistributedWarehouseSystem.Models.Truck;

public class Truck(int capacity, string name)
{
    public int Capacity { get; } = capacity;
    public string Name { get; } = name;
    public async Task DeliverAsync(Silo.Silo silo, CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await Task.Delay(2000, token);

            var batch = await silo.GetProductAsync(Capacity);
            Console.WriteLine($"Грузовик {Name} загружен продукцией на {batch.Quantity} единиц.");
            await Task.Delay(3000, token);
            Console.WriteLine($"Грузовик {Name} доставил продукцию.");
        }
    }
}