using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinosaursShop.Models
{
    public interface IDinosaurRepository
    {
        IEnumerable<Dinosaur> GetAllDinosaurs { get; }
        IEnumerable<Dinosaur> GetDinosaursOnSale { get; }
        Dinosaur GetDinosaurById(int dinosaurId);
    }
}
