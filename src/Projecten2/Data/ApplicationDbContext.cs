using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projecten2.Models;
using Projecten2.Models.Domain;

namespace Projecten2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Analyse> Analyses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Analyse>(MapAnalyse);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        private static void MapAnalyse(EntityTypeBuilder<Analyse> a)
        {
            //Table name
            a.ToTable("Analyse");

            //Primary key
            a.HasKey(t => t.analyseId);

            //Properties
            a.Property(t => t.naam)
                .IsRequired()
                .HasMaxLength(50);

            a.Property(t => t.bedrijf)
                .IsRequired();

            a.Property(t => t.afdeling)
                .IsRequired();

            a.Property(t => t.gebruikerId)
                .HasColumnName("gebruiker_id")
                .IsRequired();

            a.Property(t => t.datum)
                .IsRequired();

            a.Property(t => t.analyseId)
                .HasColumnName("analyse_id")
                .IsRequired();
        }
    }
}
