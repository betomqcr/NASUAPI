using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Especy
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<CategoriaPeso> CategoriaPesos { get; } = new List<CategoriaPeso>();

    public virtual ICollection<Raza> Razas { get; } = new List<Raza>();
}
