﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTO
{
    public class SexoDTO
    {
        public int Id { get; set; }

        public string Descripcion { get; set; } = null!;

        public bool Mascota { get; set; }

        public bool Activo { get; set; }
    }
}
