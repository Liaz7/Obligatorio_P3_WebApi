﻿using Dominio.Dto;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Servicios
{
    public interface IServicioEcosistema
    {
        EcosistemaDto Add(EcosistemaDto ecosistemaDto);
        void EliminarEnCascada(EcosistemaDto EcosistemaDto);
        IEnumerable<EcosistemaDto> GetAll();
        /*void Update(string nombre, EcosistemaDto ecosistemaDto);
        
        IEnumerable<EcosistemaDto> GetByNombreEspecie(string nombre);
        EcosistemaDto GetByNombre(string nombre);
        EcosistemaDto GetById(int id);
        */

    }
}
