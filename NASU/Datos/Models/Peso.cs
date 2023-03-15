using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Peso
{
    public int Id { get; set; }

    public int IdMascota { get; set; }

    public DateTime Fecha { get; set; }

    public int IdCategoriaPeso { get; set; }

    public virtual CategoriaPeso IdCategoriaPesoNavigation { get; set; } = null!;

    public virtual Mascota IdMascotaNavigation { get; set; } = null!;
}
