using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {
        protected IUnitOfWork unitOfWork;

        public AutorController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Autor> GetAll()
        {
            return unitOfWork.AutorRepository.GetAll("SELECT * FROM AUTORES");
        }

        [HttpGet]
        [Route("{id}")]
        public Autor Get(int id)
        {
            return unitOfWork.AutorRepository.Get("SELECT * FROM AUTORES WHERE id_autor = @id", new { id });

        }

        [HttpPost]
        public ActionResult Add(Autor autor)
        {
            try
            {
                int id = unitOfWork.AutorRepository.Add(@"INSERT INTO AUTORES (nombre_autor, id_pais, anio_nac, anio_def) 
                                                        VALUES(@nombre_autor, @id_pais, @anio_nac, @anio_def)",
                                                        new { autor.nombre_autor, autor.id_pais, autor.anio_nac, autor.anio_def }
                                                        );
                
                autor.id_autor = id;

                unitOfWork.Commit();

            }
            catch (System.Exception)
            {
                return Ok(false);
                throw;
            }

            return Ok(autor);
        }
    }
}
