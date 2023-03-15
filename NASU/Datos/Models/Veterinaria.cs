using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Veterinaria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string NombreFiscal { get; set; } = null!;

    public int IdTipoIdentificacion { get; set; }

    public string Documento { get; set; } = null!;

    public string NombreContacto { get; set; } = null!;

    public string Puesto { get; set; } = null!;

    public string Medico { get; set; } = null!;

    public string? NumColegiado { get; set; }

    public string? CorreoContacto { get; set; }

    public string? Maps { get; set; }

    public bool? Estado { get; set; }

    public bool? Activo { get; set; }

    public bool? Eliminado { get; set; }

    public string Direccion { get; set; } = null!;

    public byte[]? LogoB { get; set; }

    public string? LogoD { get; set; }

    public virtual TiposIdentificacion IdTipoIdentificacionNavigation { get; set; } = null!;
}
