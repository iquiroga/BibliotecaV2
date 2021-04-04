using DAL.Entities;
using DAL.Repositories;
using System;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        GenericDapperRepository<Autor> AutorRepository { get; }
        GenericDapperRepository<Genero> GeneroRepository { get; }
        GenericDapperRepository<Idioma> IdiomaRepository { get; }
        GenericDapperRepository<Libro> LibroRepository { get; }
        GenericDapperRepository<Pais> PaisRepository { get;  }
        void Commit();
    }
}
