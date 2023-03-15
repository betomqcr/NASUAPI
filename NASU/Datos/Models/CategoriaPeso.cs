using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class CategoriaPeso
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdEspecie { get; set; }

    public short? PesoEspecieOrder { get; set; }

    public virtual Especy IdEspecieNavigation { get; set; } = null!;

    public virtual ICollection<Peso> Pesos { get; } = new List<Peso>();
}
