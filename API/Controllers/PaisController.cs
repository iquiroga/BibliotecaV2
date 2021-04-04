using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaisController : ControllerBase
    {
        protected IUnitOfWork unitOfWork;

        public PaisController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Pais> GetAll()
        {
            return unitOfWork.PaisRepository.GetAll("SELECT * FROM PAISES");
        }

        [HttpGet]
        [Route("{id}")]
        public Pais Get(int id)
        {
            return unitOfWork.PaisRepository.Get("SELECT * FROM PAISES WHERE id_pais = @id", new { id });

        }

        [HttpPost]
        public ActionResult Add(Pais pais)
        {
            try
            {
                int id = unitOfWork.PaisRepository.Add("INSERT INTO PAISES (pais) VALUES(@pais)", new { pais.pais });
                pais.id_pais = id;

                unitOfWork.Commit();

            }
            catch (System.Exception)
            {
                return Ok(false);
                throw;
            }

            return Ok(pais);
        }
    }
}
