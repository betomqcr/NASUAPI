using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Paise
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Provincia> Provincia { get; } = new List<Provincia>();
}
