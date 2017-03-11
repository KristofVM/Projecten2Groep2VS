using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projecten2.Models.Domain;
using Projecten2.Models.Domain.BatenVragen;
using Projecten2.Models.Domain.KostenVragen;

namespace Projecten2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Analyse> Analyses { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Analyse>(MapAnalyse);
            modelBuilder.Entity<ApplicationUser>(MapApplicationUser);

            //Mapping Kosten
            modelBuilder.Entity<Kosten>(MapKosten);
            modelBuilder.Entity<KVraag1_0>(MapKVraag1_0);
            modelBuilder.Entity<KVraag1_1>(MapKVraag1_1);
            modelBuilder.Entity<KVraag2>(MapKVraag2);
            modelBuilder.Entity<KVraag3>(MapKVraag3);
            modelBuilder.Entity<KVraag4>(MapKVraag4);
            modelBuilder.Entity<KVraag5>(MapKVraag5);
            modelBuilder.Entity<KVraag6>(MapKVraag6);
            modelBuilder.Entity<KVraag7>(MapKVraag7);


            //Mapping Baten
            modelBuilder.Entity<Baten>(MapBaten);
            modelBuilder.Entity<BVraag3>(MapBVraag3);
            modelBuilder.Entity<BVraag4>(MapBVraag4);
            modelBuilder.Entity<BVraag5>(MapBVraag5);
            modelBuilder.Entity<BVraag9>(MapBVraag9);
            modelBuilder.Entity<BVraag11>(MapBVraag11);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
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
                .HasForeignKey<Kosten>(t => t.KostenId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            a.HasOne(t => t.Baten)
                .WithOne()
                .HasForeignKey<Baten>(t => t.BatenId)
                .IsRequired()
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

        //KOSTEN
        private static void MapKosten(EntityTypeBuilder<Kosten> k)
        {
            //Table name
            k.ToTable("Kosten");

            //Primary key
            k.HasKey(t => t.KostenId);

            k.Property(t => t.KostenId)
                .ValueGeneratedOnAdd();

            //Associaties
        }
        private static void MapKVraag1_0(EntityTypeBuilder<KVraag1_0> k)
        {
            //Table name
            k.ToTable("KVraag1_0");

            //Primary Key
            k.HasKey(t => t.Id);

            k.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            k.Property(t => t.Functie)
                .IsRequired()
                .HasMaxLength(50);

            k.Property(t => t.AantalMaandenIBO)
                .IsRequired();

            k.Property(t => t.AantalUrenPerWeek)
                .IsRequired();

            k.Property(t => t.BrutoMaandloonFulltime)
                .IsRequired();

            k.Property(t => t.TotaleProductiviteitsPremie)
                .IsRequired();

            //Associaties
        }
        private static void MapKVraag1_1(EntityTypeBuilder<KVraag1_1> k)
        {
            //Table name
            k.ToTable("KVraag1_1");

            //Primary Key
            k.HasKey(t => t.Id);

            k.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            k.Property(t => t.Beschrijving)
                .IsRequired()
                .HasMaxLength(50);

            k.Property(t => t.JaarBedrag)
                .IsRequired();

            //Associaties
        }
        private static void MapKVraag2(EntityTypeBuilder<KVraag2> k)
        {
            //Table name
            k.ToTable("KVraag2");

            //Primary Key
            k.HasKey(t => t.Id);

            k.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            //Associaties

        }
        private static void MapKVraag3(EntityTypeBuilder<KVraag3> k)
        {
            //Table name
            k.ToTable("KVraag3");

            //Primary Key
            k.HasKey(t => t.Id);

            k.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            //Associaties

        }
        private static void MapKVraag4(EntityTypeBuilder<KVraag4> k)
        {
            //Table name
            k.ToTable("KVraag4");

            //Primary Key
            k.HasKey(t => t.Id);

            k.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            //Associaties

        }
        private static void MapKVraag5(EntityTypeBuilder<KVraag5> k)
        {
            //Table name
            k.ToTable("KVraag5");

            //Primary Key
            k.HasKey(t => t.Id);

            k.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            //Associaties

        }
        private static void MapKVraag6(EntityTypeBuilder<KVraag6> k)
        {
            //Table name
            k.ToTable("KVraag6");

            //Primary Key
            k.HasKey(t => t.Id);

            k.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            //Associaties

        }
        private static void MapKVraag7(EntityTypeBuilder<KVraag7> k)
        {
            //Table name
            k.ToTable("KVraag7");

            //Primary Key
            k.HasKey(t => t.Id);

            k.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            //Associaties

        }

        //BATEN
        private static void MapBaten(EntityTypeBuilder<Baten> b)
        {
            //Table name
            b.ToTable("Baten");

            //Primary key
            b.HasKey(t => t.BatenId);

            b.Property(t => t.BatenId)
                .ValueGeneratedOnAdd();

            b.Property(t => t.JaarBedExtraProd)
                .IsRequired();

            b.Property(t => t.JaarBedHandelingsKost)
                .IsRequired();

            b.Property(t => t.JaarBedOmzetVerlies)
                .IsRequired();

            b.Property(t => t.JaarBedOveruren)
                .IsRequired();

            b.Property(t => t.JaarBedSubsWerkOmg)
                .IsRequired();

            b.Property(t => t.JaarBedTransportKost)
                .IsRequired();

            b.Property(t => t.ProcentBesparing)
                .IsRequired();

            b.Property(t => t.UrenVoltijdsWerkweek)
                .IsRequired();

            //Associaties
        }
        private static void MapBVraag3(EntityTypeBuilder<BVraag3> b)
        {

        }
        private static void MapBVraag4(EntityTypeBuilder<BVraag4> b)
        {

        }
        private static void MapBVraag5(EntityTypeBuilder<BVraag5> b)
        {

        }
        private static void MapBVraag9(EntityTypeBuilder<BVraag9> b)
        {

        }
        private static void MapBVraag11(EntityTypeBuilder<BVraag11> b)
        {

        }
    }
}
