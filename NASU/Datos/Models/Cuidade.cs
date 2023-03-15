using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Cuidade
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public int IdProvincia { get; set; }

    public virtual ICollection<Distrito> Distritos { get; } = new List<Distrito>();

    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;
}
