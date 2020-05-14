using System.Collections.Generic;
using PEIAProcessing.Domain.Entities;
using PEIAProcessing.Domain.Interfaces;

namespace PEIAProcessing.Data.Repositories
{
    public class PositionRepository<T> : BaseConnection, IRepository<T> where T : Position
    {
        public PositionRepository(ConnectionConfig connectionConfig) : base(connectionConfig){}

        public IList<T> Select()
        {
            //return context.Set<T>().ToList();
            return null;
        }

        public void Insert(T obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public T Select(int id)
        {
            //return context.Set<T>().Find(id);            //return context.Set<T>().Find(id);
            return null;


        }
    }
}
