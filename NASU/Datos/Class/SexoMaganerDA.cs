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
    public class SexoMaganerDA :ISexoManagerDA
    {
        private NasuNContext _entities;

        public SexoMaganerDA()
        {
            _entities = new NasuNContext();
        }

        public ResponseGeneric<SexoDTO> CrearSexo(SexoDTO request)
        {
            try
            {
                Sexo sexo = new Sexo
                {
                    Descripcion = request.Descripcion,
                    Mascota = request.Mascota,
                    Activo = request.Activo
                };

                _entities.Sexos.Add(sexo);
                int res = _entities.SaveChanges();
                if (res == 0)
                    return new ResponseGeneric<SexoDTO>("Error");
                else
                    return new ResponseGeneric<SexoDTO>(request);

            }
            catch(Exception ex)
            {
                return new ResponseGeneric<SexoDTO>(ex);
            }
        }

        public ResponseGeneric<List<SexoDTO>> GetSexoHumano(SexoDTO request)
        {
            try
            {
                List<SexoDTO> list=new List<SexoDTO>();
                List<Sexo> lisrta = _entities.Sexos.Where(c=>c.Mascota==false).ToList();

                if(lisrta.Count<0)
                {
                    return new ResponseGeneric<List<SexoDTO>>("Vacio");
                }
                else
                {
                    foreach(Sexo temp in lisrta)
                    {
                        SexoDTO sexoDTO = new SexoDTO
                        {
                            Id = temp.Id,
                            Descripcion = temp.Descripcion
                        };
                        list.Add(sexoDTO);
                    }

                    return new ResponseGeneric<List<SexoDTO>>(list);
                }
            }
            catch (Exception ex) 
            {
                return new ResponseGeneric<List<SexoDTO>>(ex);
            }
        }

        public ResponseGeneric<List<SexoDTO>> GetSexoMascota(SexoDTO request)
        {
            try
            {
                List<SexoDTO> list = new List<SexoDTO>();
                List<Sexo> lisrta = _entities.Sexos.Where(c => c.Mascota == true).ToList();

                if (lisrta.Count < 0)
                {
                    return new ResponseGeneric<List<SexoDTO>>("Vacio");
                }
                else
                {
                    foreach (Sexo temp in lisrta)
                    {
                        SexoDTO sexoDTO = new SexoDTO
                        {
                            Id = temp.Id,
                            Descripcion = temp.Descripcion
                        };
                        list.Add(sexoDTO);
                    }

                    return new ResponseGeneric<List<SexoDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                return new ResponseGeneric<List<SexoDTO>>(ex);
            }
        }
    }
}
