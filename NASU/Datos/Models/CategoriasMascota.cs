using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class CategoriasMascota
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public int RangoInicialDias { get; set; }

    public int RangoFinalDias { get; set; }

    public virtual ICollection<Mascota> Mascota { get; } = new List<Mascota>();
}
