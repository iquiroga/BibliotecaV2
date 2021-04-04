using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroController : ControllerBase
    {
        protected IUnitOfWork unitOfWork;

        public GeneroController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Genero> GetAll()
        {
            return unitOfWork.GeneroRepository.GetAll("SELECT * FROM GENEROS");
        }

        [HttpGet]
        [Route("{id}")]
        public Genero Get(int id)
        {
            return unitOfWork.GeneroRepository.Get("SELECT * FROM GENEROS WHERE id_genero = @id", new { id });

        }

        [HttpPost]
        public ActionResult Add(Genero genero)
        {
            try
            {
                int id = unitOfWork.GeneroRepository.Add("INSERT INTO GENEROS (genero) VALUES(@genero)", new { genero.genero });
                genero.id_genero = id;

                unitOfWork.Commit();

            }
            catch (System.Exception)
            {
                return Ok(false);
                throw;
            }

            return Ok(genero);
        }
    }
}
