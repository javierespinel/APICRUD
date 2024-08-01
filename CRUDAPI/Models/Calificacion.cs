using System;
using System.Collections.Generic;

namespace CRUDAPI.Models
{
    public partial class Calificacion
    {
        public Calificacion()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int IdCalificacion { get; set; }
        public int? Calificacion1 { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
