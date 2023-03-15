using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Mascota
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaNac { get; set; }

    public byte[]? ImagenB { get; set; }

    public string? ImagenD { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int IdSexo { get; set; }

    public int IdRaza { get; set; }

    public int IdCategoriaMascota { get; set; }

    public virtual CategoriasMascota IdCategoriaMascotaNavigation { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Raza IdRazaNavigation { get; set; } = null!;

    public virtual Sexo IdSexoNavigation { get; set; } = null!;

    public virtual ICollection<Peso> Pesos { get; } = new List<Peso>();
}
