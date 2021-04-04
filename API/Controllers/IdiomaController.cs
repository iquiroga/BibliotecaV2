using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdiomaController : ControllerBase
    {
        protected IUnitOfWork unitOfWork;

        public IdiomaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Idioma> GetAll()
        {
            return unitOfWork.IdiomaRepository.GetAll("SELECT * FROM IDIOMAS");
        }

        [HttpGet]
        [Route("{id}")]
        public Idioma Get(int id)
        {
            return unitOfWork.IdiomaRepository.Get("SELECT * FROM IDIOMAS WHERE id_idioma = @id", new { id });

        }

        [HttpPost]
        public ActionResult Add(Idioma idioma)
        {
            try
            {
                int id = unitOfWork.IdiomaRepository.Add("INSERT INTO IDIOMAS (idioma) VALUES(@idioma)", new { idioma.idioma });
                idioma.id_idioma = id;

                unitOfWork.Commit();

            }
            catch (System.Exception)
            {
                return Ok(false);
                throw;
            }

            return Ok(idioma);
        }
    }
}
