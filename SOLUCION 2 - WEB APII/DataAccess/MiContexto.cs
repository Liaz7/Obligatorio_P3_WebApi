using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApp
{
    public class MiContexto : DbContext
    {

        public DbSet<Especie> Especies { get; set; }
        public DbSet<Ecosistema> Ecosistemas { get; set; }
        public DbSet<Amenaza> Amenazas { get; set; }
        public DbSet<EstadoDeConservacion> EstadosDeConservacion { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UbicacionGeografica> UbicacionesGeograficas { get; set; }
        public DbSet<EcosistemaAmenaza> EcosistemaAmenaza { get; set; }
        public DbSet<EcosistemaEspecie> EcosistemaEspecie { get; set; }
        public DbSet<EspecieAmenaza> EspecieAmenaza { get; set; }


        public MiContexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Restricciones

            modelBuilder.Entity<Ecosistema>().Ignore(ec => ec.EspecieIds).Ignore(ec => ec.AmenazasIds).HasKey(ec => ec.EcNombre);

            modelBuilder.Entity<Especie>().Ignore(ec => ec.Foto).Ignore(ec => ec.AmenazasIds).Ignore(ec => ec.EcosistemasIdsTe).HasKey(e => e.EsNombreCientifico);

            modelBuilder.Entity<Pais>().Ignore(p => p.EcosistemasIdsPais).HasKey(p => p.PaisIso);

            modelBuilder.Entity<EstadoDeConservacion>().HasKey(edc => edc.ConsId);

            modelBuilder.Entity<Amenaza>().HasKey(a => a.AmId);

            // modelBuilder.Entity<UbicacionGeografica>().HasKey(ub => new { ub.Latitud, ub.Longitud });

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .HasKey(u => u.UsId); // Clave primaria

            modelBuilder.Entity<Usuario>()
                .Property(u => u.UsId)
                .ValueGeneratedOnAdd(); // Auto-generación de clave primaria

            modelBuilder.Entity<Usuario>()
                .Property(u => u.UsuarioAlias)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.UsuarioContrasenia)
                .IsRequired()
                .HasMaxLength(255);

            // Relacion Ecosistema - UbicacionGeografica (value object)
            modelBuilder.Entity<Ecosistema>()
                 .HasOne(e => e.EcUbicacionGeografica)
                 .WithOne()
                 .HasForeignKey<Ecosistema>(e => e.EcUbicacionGeograficaId)
                 .OnDelete(DeleteBehavior.Restrict);
            // Relacion Ecosistema->Pais (* a 1)

            modelBuilder.Entity<Ecosistema>()
                 .HasOne(ec => ec.Pais)
                 .WithMany(p => p.Ecosistemas)
                 .HasForeignKey(ec => ec.PaisId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ecosistema>()
                .HasOne(ec => ec.EstadoDeConservacion)
                .WithMany(e => e.Ecosistema)
                .HasForeignKey(ec => ec.EstadoDeConservacionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Especie>()
                .HasOne(e => e.EstadoDeConservacion)
                .WithMany(edc => edc.Especie)
                .HasForeignKey(e => e.EstadoDeConservacionId);

            //Relacion de muchos a muchos EcosistemaAmenaza
            modelBuilder.Entity<EcosistemaAmenaza>()
                 .HasKey(ab => new { ab.AmId, ab.EcNombre });

            modelBuilder.Entity<EcosistemaAmenaza>()
                .HasOne(ab => ab.Ecosistema)
                .WithMany(a => a.EcosistemaAmenaza)
                .HasForeignKey(ab => ab.EcNombre);

            modelBuilder.Entity<EcosistemaAmenaza>()
                 .HasOne(ab => ab.Amenaza)
                 .WithMany(b => b.EcosistemaAmenaza)
                 .HasForeignKey(ab => ab.AmId);

            //Relacion de muchos a muchos EcosistemaEspecie
            modelBuilder.Entity<EcosistemaEspecie>()
                .HasKey(ab => new { ab.EsNombreCientifico, ab.EcNombre });

            modelBuilder.Entity<EcosistemaEspecie>()
                .HasOne(ab => ab.Ecosistema)
                .WithMany(a => a.EcosistemaEspecie)
                .HasForeignKey(ab => ab.EcNombre)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EcosistemaEspecie>()
                 .HasOne(ab => ab.Especie)
                 .WithMany(b => b.EcosistemaEspecie)
                 .HasForeignKey(ab => ab.EsNombreCientifico)
                 .OnDelete(DeleteBehavior.Restrict);

            //Relacion de muchos a muchos EspecieAmenaza
            modelBuilder.Entity<EspecieAmenaza>()
                .HasKey(ab => new { ab.AmId, ab.EcNombre });

            modelBuilder.Entity<EspecieAmenaza>()
                .HasOne(ab => ab.Amenaza)
                .WithMany(a => a.EspecieAmenaza)
                .HasForeignKey(ab => ab.AmId);

            modelBuilder.Entity<EspecieAmenaza>()
                 .HasOne(ab => ab.Especie)
                 .WithMany(b => b.EspecieAmenaza)
                 .HasForeignKey(ab => ab.EcNombre);


        }


    }
}

