using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CRUDAPI.Models
{
    public partial class Estudiante
    {
        public int Id { get; set; }
        public int? NumeroIdentificacion { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? IdCurso { get; set; }
        public int? IdCalificacion { get; set; }
        [JsonIgnore]
        public virtual Calificacion? oIdCalificacion { get; set; }
        [JsonIgnore]
        public virtual Curso? oIdCurso { get; set; }
    }
}
