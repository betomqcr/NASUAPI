using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Sexo
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Mascota { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Mascota> MascotaNavigation { get; } = new List<Mascota>();
}
