using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IDataAccess<TEntity>
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity FindWithId(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
    public interface IBusiness<TEntity>
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity FindWithId(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
    
}
