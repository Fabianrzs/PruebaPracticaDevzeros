using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Save(TEntity entity);
        IEnumerable<TEntity> Consult();
        TEntity GetCod(int id);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
