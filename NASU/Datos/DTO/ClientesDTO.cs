using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTO
{
    public class ClientesDTO
    {
        public int? Id { get; set; }

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
    }
}
