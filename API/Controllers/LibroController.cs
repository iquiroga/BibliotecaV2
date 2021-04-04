using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibroController : ControllerBase
    {
        protected IUnitOfWork unitOfWork;

        public LibroController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Libro> GetAll()
        {
            return unitOfWork.LibroRepository.GetAll("SELECT * FROM LIBROS");
        }

        [HttpGet]
        [Route("{id}")]
        public Libro Get(int id)
        {
            return unitOfWork.LibroRepository.Get("SELECT * FROM LIBROS WHERE id_libro = @id", new { id });

        }

        [HttpPost]
        public ActionResult Add(Libro libro)
        {
            try
            {
                int id = unitOfWork.LibroRepository.Add(@"INSERT INTO LIBROS (titulo, id_genero, id_autor, precio, fecha_publicacion, id_idioma)
                                                        VALUES(@titulo, @id_genero, @id_autor, @precio, @fecha_publicacion, @id_idioma)",
                                                        new { libro.titulo, libro.id_genero, libro.id_autor, libro.precio, libro.fecha_publicacion, libro.id_idioma }
                                                        );
                
                libro.id_libro = id;

                unitOfWork.Commit();

            }
            catch (System.Exception)
            {
                return Ok(false);
                throw;
            }

            return Ok(libro);
        }
    }
}
