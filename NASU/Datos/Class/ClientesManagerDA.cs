using Datos.DTO;
using Datos.Helpers;
using Datos.Interfaces;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Class
{
    public class ClientesManagerDA : IClientesManagerDA
    {
        public NasuNContext _entities;

        public ClientesManagerDA()
        {
            _entities = new NasuNContext();
        }

        public ResponseGeneric<ClientesDTO> CreateClient(ClientesDTO request)
        {
            try
            {
                Cliente cliente = new Cliente { 
                    Nombre=request.Nombre,
                    Apellido1 = request.Apellido1,
                    Apellido2 = request.Apellido2,
                    Telefono = request.Telefono,
                    FechaNac=request.FechaNac,
                    IdTipoIdentificacion=request.IdTipoIdentificacion,
                    NumDocumento=request.NumDocumento,
                    Email=request.Email,
                    IdSexo=request.IdSexo,
                    Activo=request.Activo,
                    Enviado=request.Enviado,
                    IdDistrito=request.IdDistrito,
                    FechaAlta=request.FechaAlta,
                    FechaModficacion=request.FechaModficacion,
                    UsarMismosDatosFactura=request.UsarMismosDatosFactura
                };
                return new ResponseGeneric<ClientesDTO>(request);

            }
            catch (Exception ex) 
            {
                return new ResponseGeneric<ClientesDTO>(ex);
            }
        }
    }
}
