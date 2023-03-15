using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class TiposIdentificacion
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int CodigoFe { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Veterinaria> Veterinaria { get; } = new List<Veterinaria>();
}
