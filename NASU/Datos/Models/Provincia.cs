using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Provincia
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public int IdPais { get; set; }

    public virtual ICollection<Cuidade> Cuidades { get; } = new List<Cuidade>();

    public virtual Paise IdPaisNavigation { get; set; } = null!;
}
