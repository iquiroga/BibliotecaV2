using System;

namespace DAL.Entities
{
    public class Libro
    {
        public int id_libro { get; set; }
        public string titulo { get; set; }
        public int id_genero { get; set; }
        public int id_autor { get; set; }
        public float precio { get; set; }
        public DateTime? fecha_publicacion { get; set; }
        public int id_idioma { get; set; }
    }
}
