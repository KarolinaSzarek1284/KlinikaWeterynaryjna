using Microsoft.EntityFrameworkCore;

namespace KlinikaWeterynaryjna.Entities
{
    public class VeterinaryMedicineContext : DbContext
    {
        private string _connectionString =
            "Server=(localdb)\\BeautyBareDb;Database=KlinikaDb;Trusted_Connection=True";

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
