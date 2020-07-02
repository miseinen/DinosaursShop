using System;
using Microsoft.EntityFrameworkCore;

namespace DinosaursShop.Models
{
    /// <summary>
    /// Represents a session with the database.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by a DbContext.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets a DbSet of the <see cref="Dinosaur"/> class.
        /// </summary>
        public DbSet<Dinosaur> Dinosaurs { get; set; }

        /// <summary>
        /// Gets or sets a DbSet of the <see cref="Category"/> class.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets a DbSet of the <see cref="ShoppingCartItem"/> class.
        /// </summary>
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        /// <summary>
        /// Call when app context is first created to build the model and its mappings in memory.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                CategoryName = "Carnivornes",
                CategoryDescription = "Meat eating dinosaur",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 2,
                CategoryName = "Herbivores",
                CategoryDescription = "Plant eating dinosaur",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 3,
                CategoryName = "Omnivores",
                CategoryDescription = "Meat and plants eating dinosaur",
            });

            modelBuilder.Entity<Dinosaur>().HasData(new Dinosaur
            {
                DinosaurId = 1,
                Name = "Allosaurus",
                Description = "Allosaurus was a typical large theropod, having a massive skull on a short neck, a long," +
                " slightly sloping tail and reduced forelimbs. Allosaurus fragilis, the best-known species, had an average" +
                " length of 8.5 m (28 ft), with the largest definitive Allosaurus specimen estimated at 9.7 meters " +
                "(32 feet) long, and an estimated weight of 2.3 metric tons (2.5 short tons).",
                Price = 1500M,
                CategoryId = 1,
                ImageUrl = "/images/Allosaurus_Juvenile_Reconstruction.jpg",
                ImageThumbnailUrl = "/images/thumbnails/Allosaurus_Juvenile_Reconstruction.jpg",
                IsInStock = true,
                IsOnSale = false,
            });
            modelBuilder.Entity<Dinosaur>().HasData(new Dinosaur
            {
                DinosaurId = 2,
                Name = "Nomingia",
                Description = "Nomingia is a medium-sized oviraptorosaur to have been 1.7 metres (5.6 ft) long and " +
               "20 kilograms (44 lb) in weight. It is characterized by a pygostyle-like mass of five fused vertebrae" +
               " at the tail end.",
                Price = 950M,
                CategoryId = 3,
                ImageUrl = "/images/800px-Nomingia_gobiensis.png.jpg",
                ImageThumbnailUrl = "/images/thumbnails/220px-Nomingia_gobiensis.png",
                IsInStock = true,
                IsOnSale = false,
            });
            modelBuilder.Entity<Dinosaur>().HasData(new Dinosaur
            {
                DinosaurId = 3,
                Name = "Velociraptor",
                Description = "Velociraptor was a mid-sized dromaeosaurid, with adults measuring up to 2.07 m (6 ft 9 1⁄2 in) long," +
                " 0.5 m (1 ft 7 1⁄2 in) high at the hip, and weighing up to 15 kg (33 lb), though there is a higher estimate of 19.7 kg" +
                " (43 1⁄2 lb). The skull, which grew up to 25 cm (10 in) long, is uniquely up-curved, concave on the upper surface and" +
                " convex on the lower. The jaws is lined with 26–28 widely spaced teeth on each side, each more strongly serrated on" +
                " the back edge than the front",
                Price = 1000M,
                CategoryId = 1,
                ImageUrl = "/images/1024px-Velociraptor_Restoration.png",
                ImageThumbnailUrl = "/images/thumbnails/220px-Velociraptor_Restoration.png",
                IsInStock = true,
                IsOnSale = true,
            });
            modelBuilder.Entity<Dinosaur>().HasData(new Dinosaur
            {
                DinosaurId = 4,
                Name = "Eoraptor",
                Description = "Eoraptor has a slender body that grew to about 1 metre (3 ft 3 in) in length, with an estimated weight" +
                " of about 10 kilograms (22 lb). It has a lightly built skull with a slightly enlarged external naris.",
                Price = 500M,
                CategoryId = 3,
                ImageUrl = "/images/Eoraptor_NT_small.jpg",
                ImageThumbnailUrl = "/images/thumbnails/220px-Eoraptor_NT_small.jpg",
                IsInStock = true,
                IsOnSale = true,
            });
            modelBuilder.Entity<Dinosaur>().HasData(new Dinosaur
            {
                DinosaurId = 5,
                Name = "Triceratops",
                Description = "Individual Triceratops are estimated to have reached about 7.9 to 9 metres (26 to 30 ft)" +
                " in length, 2.9 to 3.0 m (9.5 to 9.8 ft) in height, and 6.1 to 12.0 tonnes (13,400 to 26,500 lb)" +
                " in weight. The most distinctive feature is their large skull, among the largest of all land animals.",
                Price = 1500M,
                CategoryId = 2,
                ImageUrl = "/images/Knight_Triceratops.jpg",
                ImageThumbnailUrl = "/images/thumbnails/220px-Knight_Triceratops.jpg",
                IsInStock = true,
                IsOnSale = true,
            });
            modelBuilder.Entity<Dinosaur>().HasData(new Dinosaur
            {
                DinosaurId = 6,
                Name = "Brachiosaurus",
                Description = "Over the years, the mass of B. altithorax has been estimated at 35.0 metric tons (38.6 short tons)," +
                 "28.3 metric tons (31.2 short tons), 43.9 metric tons (48.4 short tons), 28.7 metric tons (31.6 short tons)," +
                 " 56.3 metric tons (62.1 short tons), and 58 metric tons (64 short tons). The length of Brachiosaurus has been" +
                 " estimated at 20–21 meters (66–69 ft) and 18 meters (59 ft), and its height at 9.4 meters (30 3⁄4 ft) and 12–13" +
                 " meters (39–43 ft).",
                Price = 2500M,
                CategoryId = 2,
                ImageUrl = "/images/Brachiosaurus_NT_new.jpg",
                ImageThumbnailUrl = "/images/thumbnails/220px-Brachiosaurus_NT_new.jpg",
                IsInStock = true,
                IsOnSale = false,
            });
        }
    }
}
