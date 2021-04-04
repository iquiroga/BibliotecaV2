using DAL.Entities;
using DAL.Helper;
using DAL.Repositories;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private GenericDapperRepository<Autor> autorRepository;
        private GenericDapperRepository<Genero> generoRepository;
        private GenericDapperRepository<Idioma> idiomaRepository;
        private GenericDapperRepository<Libro> libroRepository;
        private GenericDapperRepository<Pais> paisRepository;
        
        private bool _disposed;
        //private bool _token;

        public UnitOfWork(ConnectionHelper connection)
        {

            _connection = new SqlConnection(connection.GetConnectionString());
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            //_token = false;
        }
        public GenericDapperRepository<Autor> AutorRepository
        {
            get
            {
                if (this.autorRepository == null)
                {
                    this.autorRepository = new GenericDapperRepository<Autor>(_transaction);
                }
                return autorRepository;
            }
        }
        public GenericDapperRepository<Genero> GeneroRepository
        {
            get
            {
                if (this.generoRepository == null)
                {
                    this.generoRepository = new GenericDapperRepository<Genero>(_transaction);
                }
                return generoRepository;
            }
        }

        public GenericDapperRepository<Idioma> IdiomaRepository
        {
            get
            {
                if (this.idiomaRepository == null)
                {
                    this.idiomaRepository = new GenericDapperRepository<Idioma>(_transaction);
                }
                return idiomaRepository;
            }
        }
        public GenericDapperRepository<Libro> LibroRepository
        {
            get
            {
                if (this.libroRepository == null)
                {
                    this.libroRepository = new GenericDapperRepository<Libro>(_transaction);
                }
                return libroRepository;
            }
        }

        public GenericDapperRepository<Pais> PaisRepository
        {
            get
            {
                if (this.paisRepository == null)
                {
                    this.paisRepository = new GenericDapperRepository<Pais>(_transaction);
                }
                return paisRepository;
            }
        }
       
      

        //public bool success()
        //{
        //    return _token;
        //}

        public void Commit()
        {
            try
            {
                _transaction.Commit();
                //_token = true;
            }
            catch
            {
                _transaction.Rollback();
                //_token = false;
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        private void ResetRepositories()
        {
        }

        public void Dispose()
        {
            DisposeConn(true);
            GC.SuppressFinalize(this);
        }

        private void DisposeConn(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }
    }

}
