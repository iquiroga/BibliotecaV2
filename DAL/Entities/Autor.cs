using System;

namespace DAL.Entities
{
    public class Autor
    {
        public int id_autor { get; set; }
        public string nombre_autor { get; set; }
        public int id_pais { get; set; }
        public DateTime? anio_nac { get; set; }
        public DateTime? anio_def { get; set; }
    }
}
