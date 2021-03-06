﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VenueManagment.Models;

namespace VenueManagment.Migrations
{
    [DbContext(typeof(DbContexto))]
    [Migration("20200320045421_1_19032020")]
    partial class _1_19032020
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview8.19405.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VenueManagment.Models.Campana", b =>
                {
                    b.Property<int>("idCampana")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idCampana")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("idCampana");

                    b.ToTable("Campana");
                });

            modelBuilder.Entity("VenueManagment.Models.Contacto", b =>
                {
                    b.Property<int>("idContacto")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idContacto")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnName("telefono")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("idContacto");

                    b.ToTable("Contacto");
                });

            modelBuilder.Entity("VenueManagment.Models.Cuenta", b =>
                {
                    b.Property<int>("idCuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idCuenta")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("calle")
                        .IsRequired()
                        .HasColumnName("calle")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ciudad")
                        .IsRequired()
                        .HasColumnName("ciudad")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("colonia")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("cp")
                        .HasColumnName("cp")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<string>("descripcion")
                        .HasColumnName("descripcion")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnName("estado")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("estatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estatus")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("idCampana")
                        .HasColumnName("idCampana")
                        .HasColumnType("int");

                    b.Property<int>("idContacto")
                        .HasColumnType("int");

                    b.Property<int>("idSegmento")
                        .HasColumnName("idSegmento")
                        .HasColumnType("int");

                    b.Property<int>("noExt")
                        .HasColumnName("noExt")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<int>("noInt")
                        .HasColumnName("noInt")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("pais")
                        .IsRequired()
                        .HasColumnName("pais")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("web")
                        .HasColumnName("web")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("idCuenta");

                    b.HasIndex("idCampana");

                    b.HasIndex("idContacto");

                    b.HasIndex("idSegmento");

                    b.HasIndex("nombre")
                        .IsUnique();

                    b.ToTable("Cuenta");
                });

            modelBuilder.Entity("VenueManagment.Models.Espacio", b =>
                {
                    b.Property<int>("idEspacio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("area")
                        .IsRequired()
                        .HasColumnName("area")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("capacidadMaxima")
                        .IsRequired()
                        .HasColumnName("capacidadMaxima")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("combo")
                        .HasColumnName("combo")
                        .HasColumnType("bit");

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("idFlujoIngreso")
                        .HasColumnName("idFlujoIngreso")
                        .HasColumnType("int");

                    b.Property<int>("idGrupoEspacio")
                        .HasColumnName("idGrupoEspacio")
                        .HasColumnType("int");

                    b.Property<int>("idVenue")
                        .HasColumnName("idVenue")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("idEspacio");

                    b.HasIndex("area")
                        .IsUnique();

                    b.HasIndex("capacidadMaxima")
                        .IsUnique();

                    b.HasIndex("idFlujoIngreso");

                    b.HasIndex("idGrupoEspacio");

                    b.HasIndex("idVenue");

                    b.HasIndex("nombre")
                        .IsUnique();

                    b.ToTable("Espacio");
                });

            modelBuilder.Entity("VenueManagment.Models.Evento", b =>
                {
                    b.Property<int>("idEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idEvento")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime>("fechaFin")
                        .HasColumnName("fechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaInicio")
                        .HasColumnName("fechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<bool>("fullday")
                        .HasColumnName("fullday")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("idEvento");

                    b.HasIndex("nombre")
                        .IsUnique();

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("VenueManagment.Models.FlujoIngreso", b =>
                {
                    b.Property<int>("idFlujoIngreso")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idFlujoIngreso")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("idTipoIngreso")
                        .HasColumnName("idTipoIngreso")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("idFlujoIngreso");

                    b.HasIndex("idTipoIngreso");

                    b.HasIndex("nombre")
                        .IsUnique();

                    b.ToTable("FlujoIngreso");
                });

            modelBuilder.Entity("VenueManagment.Models.GrupoEspacio", b =>
                {
                    b.Property<int>("idGrupoEspacio")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idGrupoEspacio")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("idGrupoEspacio");

                    b.ToTable("GrupoEspacio");
                });

            modelBuilder.Entity("VenueManagment.Models.MaestroEvento", b =>
                {
                    b.Property<int>("idMaestroEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idMaestroEvento")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("idMaestroEvento");

                    b.ToTable("MaestroEvento");
                });

            modelBuilder.Entity("VenueManagment.Models.RazonSocial", b =>
                {
                    b.Property<int>("idRazonSocial")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idRazonSocial")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("calle")
                        .IsRequired()
                        .HasColumnName("calle")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ciudad")
                        .IsRequired()
                        .HasColumnName("ciudad")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("colonia")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("cp")
                        .HasColumnName("cp")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnName("estado")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("estatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estatus")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("idCuenta")
                        .HasColumnType("int");

                    b.Property<string>("metodoPago")
                        .IsRequired()
                        .HasColumnName("metodoPago")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("noExt")
                        .HasColumnName("noExt")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<int>("noInt")
                        .HasColumnName("noInt")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("pais")
                        .IsRequired()
                        .HasColumnName("pais")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("rfc")
                        .IsRequired()
                        .HasColumnName("rfc")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("usoCfdi")
                        .IsRequired()
                        .HasColumnName("usoCfdi")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("idRazonSocial");

                    b.HasIndex("idCuenta");

                    b.HasIndex("nombre")
                        .IsUnique();

                    b.ToTable("RazonSocial");
                });

            modelBuilder.Entity("VenueManagment.Models.Segmento", b =>
                {
                    b.Property<int>("idSegmento")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idSegmento")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("idSegmento");

                    b.ToTable("Segmento");
                });

            modelBuilder.Entity("VenueManagment.Models.TipoEvento", b =>
                {
                    b.Property<int>("idTipoEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idTipoEvento")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("idMaestroEvento")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("idTipoEvento");

                    b.HasIndex("idMaestroEvento");

                    b.HasIndex("nombre")
                        .IsUnique();

                    b.ToTable("TipoEvento");
                });

            modelBuilder.Entity("VenueManagment.Models.TipoIngreso", b =>
                {
                    b.Property<int>("idTipoIngreso")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idTipoIngreso")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("idTipoIngreso");

                    b.ToTable("TipoIngreso");
                });

            modelBuilder.Entity("VenueManagment.Models.Venue", b =>
                {
                    b.Property<int>("idVenue")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idVenue")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estado")
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnName("nombre")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("idVenue");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("VenueManagment.Models.Cuenta", b =>
                {
                    b.HasOne("VenueManagment.Models.Campana", "campana")
                        .WithMany("cuenta")
                        .HasForeignKey("idCampana")
                        .HasConstraintName("FK_cuenta_campana")
                        .IsRequired();

                    b.HasOne("VenueManagment.Models.Contacto", "contacto")
                        .WithMany("cuenta")
                        .HasForeignKey("idContacto")
                        .HasConstraintName("FK_cuenta_contacto")
                        .IsRequired();

                    b.HasOne("VenueManagment.Models.Segmento", "segmento")
                        .WithMany("cuenta")
                        .HasForeignKey("idSegmento")
                        .HasConstraintName("FK_cuenta_segmento")
                        .IsRequired();
                });

            modelBuilder.Entity("VenueManagment.Models.Espacio", b =>
                {
                    b.HasOne("VenueManagment.Models.FlujoIngreso", "flujoingreso")
                        .WithMany("espacio")
                        .HasForeignKey("idFlujoIngreso")
                        .HasConstraintName("FK_Espacio_flujoingreso")
                        .IsRequired();

                    b.HasOne("VenueManagment.Models.GrupoEspacio", "grupoespacio")
                        .WithMany("espacio")
                        .HasForeignKey("idGrupoEspacio")
                        .HasConstraintName("FK_Espacio_GrupoEspacio")
                        .IsRequired();

                    b.HasOne("VenueManagment.Models.Venue", "venue")
                        .WithMany("espacio")
                        .HasForeignKey("idVenue")
                        .HasConstraintName("FK_Espacio_Venue")
                        .IsRequired();
                });

            modelBuilder.Entity("VenueManagment.Models.FlujoIngreso", b =>
                {
                    b.HasOne("VenueManagment.Models.TipoIngreso", "tipoingreso")
                        .WithMany("flujoingreso")
                        .HasForeignKey("idTipoIngreso")
                        .HasConstraintName("FK_flujoingreso_tipoingreso")
                        .IsRequired();
                });

            modelBuilder.Entity("VenueManagment.Models.RazonSocial", b =>
                {
                    b.HasOne("VenueManagment.Models.Cuenta", "cuenta")
                        .WithMany("razonsocial")
                        .HasForeignKey("idCuenta")
                        .HasConstraintName("FK_razonsocial_cuenta")
                        .IsRequired();
                });

            modelBuilder.Entity("VenueManagment.Models.TipoEvento", b =>
                {
                    b.HasOne("VenueManagment.Models.MaestroEvento", "maestroevento")
                        .WithMany("tipoevento")
                        .HasForeignKey("idMaestroEvento")
                        .HasConstraintName("FK_TipoEvento_maestroevento")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
