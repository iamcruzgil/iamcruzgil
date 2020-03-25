using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenueManagment.Models;


namespace VenueManagment.Models
{
    public class DbContexto : DbContext
    {
        public DbContexto()
        {

        }

        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {

        }

        public virtual DbSet<TipoIngreso> TipoIngreso { get; set; }
        public virtual DbSet<FlujoIngreso> FlujoIngreso { get; set; }       
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Venue> Venue { get; set; }
        public virtual DbSet<GrupoEspacio> GrupoEspacio { get; set; }
        public virtual DbSet<Espacio> Espacio { get; set; }
        public virtual DbSet<TipoEvento> TipoEvento { get; set; }
        public virtual DbSet<Segmento> Segmento { get; set; }
        public virtual DbSet<RazonSocial> RazonSocial { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<test> test { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoIngreso>(entity =>
            {
                entity.ToTable("TipoIngreso");
                entity.HasKey(e => e.idTipoIngreso);
                entity.Property(e => e.idTipoIngreso).HasColumnName("idTipoIngreso");

                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.estado)
                .HasColumnName("estado")
               .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<FlujoIngreso>(entity =>
            {
                entity.ToTable("FlujoIngreso");
                entity.HasKey(e => e.idFlujoIngreso);
                entity.Property(e => e.idFlujoIngreso).HasColumnName("idFlujoIngreso");
                entity.Property(e => e.idTipoIngreso).HasColumnName("idTipoIngreso");

                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50);
                entity.HasIndex(e => e.nombre)
                .IsUnique();

                entity.Property(e => e.estado)
                .HasColumnName("estado")
               .HasDefaultValueSql("((1))");

                entity.HasOne(p => p.tipoingreso)
                .WithMany(c => c.flujoingreso)
                .HasForeignKey(p => p.idTipoIngreso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_flujoingreso_tipoingreso");
            });

            modelBuilder.Entity<GrupoEspacio>(entity =>
            {
                entity.ToTable("GrupoEspacio");
                entity.HasKey(e => e.idGrupoEspacio);
                entity.Property(e => e.idGrupoEspacio).HasColumnName("idGrupoEspacio");

                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.estado)
                .HasColumnName("estado")
               .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.ToTable("Venue");
                entity.HasKey(e => e.idVenue);
                entity.Property(e => e.idVenue).HasColumnName("idVenue");

                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.estado)
                .HasColumnName("estado")
               .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Espacio>(entity =>
            {
                entity.ToTable("Espacio");
                entity.HasKey(e => e.idEspacio);
                entity.Property(e => e.idVenue).HasColumnName("idVenue");
                entity.Property(e => e.idFlujoIngreso).HasColumnName("idFlujoIngreso");
                entity.Property(e => e.idGrupoEspacio).HasColumnName("idGrupoEspacio");

                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50);
                entity.HasIndex(e => e.nombre)
                .IsUnique();

                entity.HasOne(p => p.venue)
                .WithMany(c => c.espacio)
                .HasForeignKey(p => p.idVenue)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Espacio_Venue");

                entity.HasOne(p => p.flujoingreso)
                .WithMany(c => c.espacio)
                .HasForeignKey(p => p.idFlujoIngreso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Espacio_flujoingreso");

                entity.HasOne(p => p.grupoespacio)
                .WithMany(c => c.espacio)
                .HasForeignKey(p => p.idGrupoEspacio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Espacio_GrupoEspacio");

                entity.Property(e => e.capacidadMaxima)
                .HasColumnName("capacidadMaxima")
                .IsRequired()
                .HasMaxLength(50);
                entity.HasIndex(e => e.capacidadMaxima)
                .IsUnique();

                entity.Property(e => e.area)
                .HasColumnName("area")
                .IsRequired()
                .HasMaxLength(50);
                entity.HasIndex(e => e.area)
                .IsUnique();

                entity.Property(e => e.combo)
                 .HasColumnName("combo");

                entity.Property(e => e.estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("((1))");

            });

            modelBuilder.Entity<MaestroEvento>(entity =>
            {
                entity.ToTable("MaestroEvento");
                entity.HasKey(e => e.idMaestroEvento);
                entity.Property(e => e.idMaestroEvento).HasColumnName("idMaestroEvento");

                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(e => e.estado)
                .HasColumnName("estado")
               .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.ToTable("TipoEvento");
                entity.HasKey(e => e.idTipoEvento);
                entity.Property(e => e.idTipoEvento).HasColumnName("idTipoEvento");

                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(60);
                entity.HasIndex(e => e.nombre)
                .IsUnique();

                entity.Property(e => e.estado)
                .HasColumnName("estado")
               .HasDefaultValueSql("((1))");

                entity.HasOne(p => p.maestroevento)
                .WithMany(c => c.tipoevento)
                .HasForeignKey(p => p.idMaestroEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoEvento_maestroevento");
            });

            modelBuilder.Entity<Campana>(entity =>
            {
                entity.ToTable("Campana");
                entity.HasKey(e => e.idCampana);
                entity.Property(e => e.idCampana).HasColumnName("idCampana");

                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.estado)
                .HasColumnName("estado")
               .HasDefaultValueSql("((1))");
            });           
           
            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.ToTable("Contacto");
                entity.HasKey(e => e.idContacto);
                entity.Property(e => e.idContacto).HasColumnName("idContacto");

                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.telefono)
                .HasColumnName("telefono")
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.estado)
                .HasColumnName("estado")
               .HasDefaultValueSql("((1))");

            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.ToTable("Cuenta");
                entity.HasKey(e => e.idCuenta);
                entity.Property(e => e.idCuenta).HasColumnName("idCuenta")
                .IsRequired();
                entity.Property(e => e.idSegmento).HasColumnName("idSegmento")
                .IsRequired();
                entity.Property(e => e.idCampana).HasColumnName("idCampana")
               .IsRequired();

                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50);
                entity.HasIndex(e => e.nombre)
                .IsUnique();

                entity.Property(e => e.calle)
                .HasColumnName("calle")                
                .HasMaxLength(50);

                entity.Property(e => e.noInt)
                .HasColumnName("noInt")                
                .HasMaxLength(50);

                entity.Property(e => e.noExt)
                .HasColumnName("noExt")               
                .HasMaxLength(50);

                entity.Property(e => e.ciudad)
                .HasColumnName("ciudad")                
                .HasMaxLength(50);

                entity.Property(e => e.estado)
                .HasColumnName("estado")                
                .HasMaxLength(50);

                entity.Property(e => e.pais)
                .HasColumnName("pais")                
                .HasMaxLength(50);

                entity.Property(e => e.cp)
                .HasColumnName("cp")                
                .HasMaxLength(50);

                entity.Property(e => e.web)
                .HasColumnName("web")               
                .HasMaxLength(50);

                entity.Property(e => e.descripcion)
                .HasColumnName("descripcion")                
                .HasMaxLength(50);

                entity.Property(e => e.estatus)
                .HasColumnName("estatus")
               .HasDefaultValueSql("((1))");  

                entity.HasOne(p => p.contacto)
               .WithMany(c => c.cuenta)
               .HasForeignKey(p => p.idContacto)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_cuenta_contacto");

                entity.HasOne(s => s.segmento)
               .WithMany(c => c.cuenta)
               .HasForeignKey(s => s.idSegmento)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_cuenta_segmento");

                entity.HasOne(s => s.campana)
              .WithMany(c => c.cuenta)
              .HasForeignKey(s => s.idCampana)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_cuenta_campana");

            });

            modelBuilder.Entity<Segmento>(entity =>
            {
                entity.ToTable("Segmento");
                entity.HasKey(e => e.idSegmento);
                entity.Property(e => e.idSegmento).HasColumnName("idSegmento");

                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.estado)
                .HasColumnName("estado")
               .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<RazonSocial>(entity =>
            {
                entity.ToTable("RazonSocial");
                entity.HasKey(e => e.idRazonSocial);
                entity.Property(e => e.idRazonSocial).HasColumnName("idRazonSocial");

                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50);
                entity.HasIndex(e => e.nombre)
                .IsUnique();

                entity.Property(e => e.rfc)
                .HasColumnName("rfc")
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.calle)
                .HasColumnName("calle")
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.noInt)
                .HasColumnName("noInt")
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.noExt)
                .HasColumnName("noExt")
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.ciudad)
                .HasColumnName("ciudad")
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.estado)
                .HasColumnName("estado")
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.pais)
                .HasColumnName("pais")
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.cp)
                .HasColumnName("cp")
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.metodoPago)
                .HasColumnName("metodoPago")
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.usoCfdi)
                .HasColumnName("usoCfdi")
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.estatus)
                .HasColumnName("estatus")
               .HasDefaultValueSql("((1))");

                entity.HasOne(p => p.cuenta)
                .WithMany(c => c.razonsocial)
                .HasForeignKey(p => p.idCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_razonsocial_cuenta");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.ToTable("Evento");
                entity.HasKey(e => e.idEvento);
                entity.Property(e => e.idEvento).HasColumnName("idEvento");             


                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50);
                entity.HasIndex(e => e.nombre)
                .IsUnique();

                entity.Property(e => e.fechaInicio)
                .HasColumnName("fechaInicio")
                .IsRequired();
                
                entity.Property(e => e.fechaFin)
                .HasColumnName("fechaFin")
                .IsRequired();
                
                entity.Property(e => e.fullday)
               .HasColumnName("fullday");
                        
            });

            modelBuilder.Entity<test>(entity =>
            {
                entity.ToTable("test");
                entity.HasKey(e => e.idTest);
                entity.Property(e => e.idTest).HasColumnName("idTest");

                entity.Property(e => e.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);                
            });

        }      

    }
}
