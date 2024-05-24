using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomainModel.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RickAndMorty;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }*/

        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EpisodeCharacter> EpisodeCharacters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EpisodeCharacter>()
                .HasKey(ec => new { ec.EpisodeId, ec.CharacterId });

            modelBuilder.Entity<EpisodeCharacter>()
                .HasOne(ec => ec.Episode)
                .WithMany(c => c.Characters)
                .HasForeignKey(ec => ec.EpisodeId);

            modelBuilder.Entity<EpisodeCharacter>()
                .HasOne(ec => ec.Character)
                .WithMany(e => e.Episodes)
                .HasForeignKey(ec => ec.CharacterId);
        }
    }
}
