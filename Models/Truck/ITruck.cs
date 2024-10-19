using DistributedWarehouseSystem.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedWarehouseSystem.Models.Truck
{
    public interface ITruck
    {
        double MaxCapacity { get; }
        void Load(List<IProduct> products);
        Task DeliverAsync(Silo.Silo silo, CancellationToken token);
    }
}
