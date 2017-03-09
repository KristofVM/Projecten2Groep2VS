using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projecten2.Models.Domain;

namespace Projecten2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Analyse> Analyses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Analyse>(MapAnalyse);
            modelBuilder.Entity<Kosten>(MapKosten);
            modelBuilder.Entity<Baten>(MapBaten);
            modelBuilder.Entity<ApplicationUser>(MapApplicationUser);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        private static void MapKosten(EntityTypeBuilder<Kosten> k)
        {
            //Table name
            k.ToTable("Kosten");

            //Primary key
            k.HasKey(t => t.KostenId);

            k.Property(t => t.KostenId)
                .ValueGeneratedOnAdd();

            //Associaties
            k.HasOne(t => t.Analyse)
                .WithOne(t => t.Kosten)
                .IsRequired();
        }
        private static void MapBaten(EntityTypeBuilder<Baten> b)
        {
            //Table name
            b.ToTable("Baten");

            //Primary key
            b.HasKey(t => t.BatenId);

            b.Property(t => t.BatenId)
                .ValueGeneratedOnAdd();

            //Associaties
        }
        private static void MapAnalyse(EntityTypeBuilder<Analyse> a)
        {
            //Table name
            a.ToTable("Analyse");

            //Primary key
            a.HasKey(t => t.AnalyseId);

            //Properties
            a.Property(t => t.Naam)
                .IsRequired()
                .HasMaxLength(50);

            a.Property(t => t.Bedrijf)
                .IsRequired();

            a.Property(t => t.Afdeling)
                .IsRequired();

            a.Property(t => t.Datum)
                .IsRequired();

            a.Property(t => t.Archief)
                .IsRequired();

            a.Property(t => t.AnalyseId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            //Associations
            a.HasOne(t => t.Kosten)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            a.HasOne(t => t.Baten)
                .WithOne()
                .IsRequired()
                .HasForeignKey<Baten>(t => t.BatenId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private static void MapApplicationUser(EntityTypeBuilder<ApplicationUser> a)
        {
            //Table name
            a.ToTable("aspnetusers");

            //Properties
            a.Property(t => t.Naam)
                .IsRequired()
                .HasMaxLength(50);

            a.Property(t => t.Voornaam)
                .IsRequired()
                .HasMaxLength(50);

            a.Property(t => t.Organisatie)
                .HasMaxLength(50);

            a.Property(t => t.Straat)
                .IsRequired()
                .HasMaxLength(100);

            a.Property(t => t.Nr)
                .IsRequired()
                .HasMaxLength(4);

            a.Property(t => t.Bus)
                .HasMaxLength(5);

            a.Property(t => t.Postcode)
                .IsRequired()
                .HasMaxLength(4);

            a.Property(t => t.Plaats)
                .IsRequired()
                .HasMaxLength(100);

            //Associaties
            a.HasMany(t => t.Analyses)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
