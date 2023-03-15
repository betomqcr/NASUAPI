using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido1 { get; set; } = null!;

    public string Apellido2 { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public DateTime FechaNac { get; set; }

    public int IdTipoIdentificacion { get; set; }

    public string NumDocumento { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int IdSexo { get; set; }

    public bool Activo { get; set; }

    public bool Enviado { get; set; }

    public int IdDistrito { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaModficacion { get; set; }

    public bool? UsarMismosDatosFactura { get; set; }

    public virtual ICollection<DatosFacturacion> DatosFacturacions { get; } = new List<DatosFacturacion>();

    public virtual Distrito IdDistritoNavigation { get; set; } = null!;

    public virtual Sexo IdSexoNavigation { get; set; } = null!;

    public virtual TiposIdentificacion IdTipoIdentificacionNavigation { get; set; } = null!;

    public virtual ICollection<Mascota> Mascota { get; } = new List<Mascota>();
}
