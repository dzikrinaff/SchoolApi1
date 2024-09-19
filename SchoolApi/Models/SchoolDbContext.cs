using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public DbSet<Nama> Namas { get; set; }
        public DbSet<Kelas> Kelas { get; set; }
        public DbSet<Jurusan> jurusans { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nama>()
                .HasOne(b => b.Kelas)
                .WithMany()
                .HasForeignKey(b => b.KelasId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Nama>()
                .HasOne(b => b.jurusan)
                .WithMany()
                .HasForeignKey(b => b.JurusanId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
