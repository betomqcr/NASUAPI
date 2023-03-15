using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Distrito
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public int IdCuidad { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual Cuidade IdCuidadNavigation { get; set; } = null!;
}
