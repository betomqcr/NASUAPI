using Datos.DTO;
using Datos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface ISexoManagerDA
    {
        ResponseGeneric<SexoDTO> CrearSexo(SexoDTO request);

        ResponseGeneric<List<SexoDTO>> GetSexoHumano(SexoDTO request);

        ResponseGeneric<List<SexoDTO>> GetSexoMascota(SexoDTO request);
    }
}
