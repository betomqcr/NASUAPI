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
    public class TiposIdentificacionManagerDA : ITiposIdentificacionManagerDA
    {
        public NasuNContext _entities;
        public TiposIdentificacionManagerDA()
        {
            _entities = new NasuNContext();

        }
        public ResponseGeneric<TiposIndentificacionDA> CrearTipoIdentificacion(TiposIndentificacionDA request)
        {
            try
            {
                TiposIdentificacion t = new TiposIdentificacion 
                {
                    Id = request.id,
                    Descripcion= request.Descripcion,
                    CodigoFe = request.CodigoFE
                };

                _entities.TiposIdentificacions.Add(t);
                int res = _entities.SaveChanges();
                if (res == 1)
                    return new ResponseGeneric<TiposIndentificacionDA>(request);
                else
                    return new ResponseGeneric<TiposIndentificacionDA>("Error al registrar");

            }
            catch(Exception ex)
            {
                return new ResponseGeneric<TiposIndentificacionDA>(ex);
            }
        }

        public ResponseGeneric<List<TiposIndentificacionDA>> GetTiposIdentificacion()
        {
            try
            {
                List<TiposIndentificacionDA> lista = new List<TiposIndentificacionDA>();
                var query = from c in _entities.TiposIdentificacions
                            select c;
                foreach(TiposIdentificacion tempo in query)
                {
                    TiposIndentificacionDA ti = new TiposIndentificacionDA
                    {
                        id= tempo.Id,
                        Descripcion=tempo.Descripcion
                    };
                    lista.Add(ti);
                }

                if(lista.Count >0)
                {
                    return new ResponseGeneric<List<TiposIndentificacionDA>>("Sin Datos");
                }
                else
                {
                    return new ResponseGeneric<List<TiposIndentificacionDA>>(lista);
                }
                

            }
            catch (Exception ex) 
            {
                return new ResponseGeneric<List<TiposIndentificacionDA>>(ex);
            }

        }
    }
}
