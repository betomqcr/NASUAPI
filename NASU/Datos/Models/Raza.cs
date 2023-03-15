using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Raza
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public int IdEspecie { get; set; }

    public virtual Especy IdEspecieNavigation { get; set; } = null!;

    public virtual ICollection<Mascota> Mascota { get; } = new List<Mascota>();
}
