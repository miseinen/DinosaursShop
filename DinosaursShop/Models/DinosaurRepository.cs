using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DinosaursShop.Models
{
    /// <summary>
    /// Provides methods to display dinosaurs information.
    /// </summary>
    public class DinosaurRepository : IDinosaurRepository
    {
        private readonly AppDbContext appDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DinosaurRepository"/> class.
        /// </summary>
        /// /// <param name="appDbContext">Application Db context.</param>
        public DinosaurRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// Gets an enumerable collection of all dinosaurs.
        /// </summary>
        public IEnumerable<Dinosaur> GetAllDinosaurs
        {
            get
            {
                return this.appDbContext.Dinosaurs.Include(d => d.Category);
            }
        }

        /// <summary>
        /// Gets an enumerable collection of dinosaurs which are on sale.
        /// </summary>
        public IEnumerable<Dinosaur> GetDinosaursOnSale
        {
            get
            {
                return this.appDbContext.Dinosaurs.Include(d => d.Category).Where(p => p.IsOnSale);
            }
        }

         /// <summary>
        /// Get information about dinosaur by id.
        /// </summary>
        /// <param name="dinosaurId">Dinosaur id.</param>
        /// <returns>Dinosaur by id.</returns>
        public Dinosaur GetDinosaurById(int dinosaurId)
        {
            return this.appDbContext.Dinosaurs.FirstOrDefault(d => d.DinosaurId == dinosaurId);
        }
    }
}
