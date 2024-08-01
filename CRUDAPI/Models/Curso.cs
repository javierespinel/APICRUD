using System;
using System.Collections.Generic;

namespace CRUDAPI.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int IdCurso { get; set; }
        public int? Curso1 { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
