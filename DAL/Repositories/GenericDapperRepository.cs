using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class GenericDapperRepository<T> where T : class
    {
        IDbConnection connection;
        IDbTransaction transaction;
        public GenericDapperRepository(IDbTransaction transaction)
        {
            this.transaction = transaction;
            connection = transaction.Connection;
        }
        public int Add(string query, object parameters)
        {
            query += "; SELECT SCOPE_IDENTITY()";
            int id = 0;
            try
            {
                id = connection.ExecuteScalar<int>(query, parameters, transaction: transaction);
                return id;
            }
            catch (Exception)
            {
                return id;
            }
            
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Get(string query, object parameters = null)
        {
            try
            {
                return connection.QueryFirst<T>(query, parameters, transaction: transaction);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public IEnumerable<T> GetAll(string query, object parameters = null)
        {
            return connection.Query<T>(query, parameters, transaction: transaction).ToList();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
