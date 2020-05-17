using System.Collections.Generic;
using PEIAProcessing.Domain.Entities;
using PEIAProcessing.Domain.Interfaces;

namespace PEIAProcessing.Data.Repositories
{
    public class PositionRepository : BaseConnection, IRepository<Position>
    {
        public PositionRepository(ConnectionConfig connectionConfig) : base(connectionConfig){}

        public IList<Position> Select()
        {
            //return context.Set<T>().ToList();
            return null;
        }

        public void Insert(Position obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Position obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Position Select(int id)
        {
            //return context.Set<T>().Find(id);            //return context.Set<T>().Find(id);
            return null;


        }
    }
}
