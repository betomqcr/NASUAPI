using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Datos.Models;

public partial class NasuNContext : DbContext
{
    public NasuNContext()
    {
    }

    public NasuNContext(DbContextOptions<NasuNContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaPeso> CategoriaPesos { get; set; }

    public virtual DbSet<CategoriasMascota> CategoriasMascotas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuidade> Cuidades { get; set; }

    public virtual DbSet<DatosFacturacion> DatosFacturacions { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Especy> Especies { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Peso> Pesos { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Raza> Razas { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<TiposIdentificacion> TiposIdentificacions { get; set; }

    public virtual DbSet<Veterinaria> Veterinarias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ALBERTO-PC\\QSOFT2017; Database=NasuN; User=sa; Password=QsoftMSDEsa2005;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaPeso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3213E83F92CE19CB");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(200);

            entity.HasOne(d => d.IdEspecieNavigation).WithMany(p => p.CategoriaPesos)
                .HasForeignKey(d => d.IdEspecie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Especie_Peso");
        });

        modelBuilder.Entity<CategoriasMascota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3213E83F564C214F");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3213E83F6F0CC417");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido1).HasMaxLength(200);
            entity.Property(e => e.Apellido2).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.FechaModficacion).HasColumnType("datetime");
            entity.Property(e => e.FechaNac).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.NumDocumento).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(40);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdDistrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Clientes_Cuidades");

            entity.HasOne(d => d.IdSexoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdSexo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Clientes_Sexo");

            entity.HasOne(d => d.IdTipoIdentificacionNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdTipoIdentificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Clientes_Identidades");
        });

        modelBuilder.Entity<Cuidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cuidades__3213E83FAF7198DA");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(100);

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Cuidades)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cuidades_Provincias");
        });

        modelBuilder.Entity<DatosFacturacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DatosFac__3213E83FB2ECD449");

            entity.ToTable("DatosFacturacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Documento).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Telefono).HasMaxLength(30);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.DatosFacturacions)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Clientes_DatoFactura");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Distrito__3213E83FEE494264");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(100);

            entity.HasOne(d => d.IdCuidadNavigation).WithMany(p => p.Distritos)
                .HasForeignKey(d => d.IdCuidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Distritos_Cuidades");
        });

        modelBuilder.Entity<Especy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Especies__3213E83F6DC495A5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mascotas__3213E83FD9D80460");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaNac).HasColumnType("datetime");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.IdCategoriaMascotaNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdCategoriaMascota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CategoriasM_Mascota");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Mascotas_Clientes");

            entity.HasOne(d => d.IdRazaNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdRaza)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Razas_Mascota");

            entity.HasOne(d => d.IdSexoNavigation).WithMany(p => p.MascotaNavigation)
                .HasForeignKey(d => d.IdSexo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Mascota_Sexo");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paises__3213E83F9A59559E");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<Peso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pesos__3213E83FC96E3140");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnType("datetime");

            entity.HasOne(d => d.IdCategoriaPesoNavigation).WithMany(p => p.Pesos)
                .HasForeignKey(d => d.IdCategoriaPeso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CategoriaPeso_Peso");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany(p => p.Pesos)
                .HasForeignKey(d => d.IdMascota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Mascota_Peso");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Provinci__3213E83F68476166");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(100);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Pais_Provincia");
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Razas__3213E83F2D3B180A");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(100);

            entity.HasOne(d => d.IdEspecieNavigation).WithMany(p => p.Razas)
                .HasForeignKey(d => d.IdEspecie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Razas_Especie");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sexo__3213E83F75E475A3");

            entity.ToTable("Sexo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<TiposIdentificacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TiposIde__3213E83FD8AE1857");

            entity.ToTable("TiposIdentificacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoFe).HasColumnName("CodigoFE");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<Veterinaria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Veterina__3213E83FE14C0552");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CorreoContacto).HasMaxLength(200);
            entity.Property(e => e.Documento).HasMaxLength(20);
            entity.Property(e => e.Medico).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.NombreContacto).HasMaxLength(200);
            entity.Property(e => e.NombreFiscal).HasMaxLength(200);
            entity.Property(e => e.NumColegiado).HasMaxLength(200);
            entity.Property(e => e.Puesto).HasMaxLength(200);

            entity.HasOne(d => d.IdTipoIdentificacionNavigation).WithMany(p => p.Veterinaria)
                .HasForeignKey(d => d.IdTipoIdentificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_TiposIdentificacion_Veterinaria");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
