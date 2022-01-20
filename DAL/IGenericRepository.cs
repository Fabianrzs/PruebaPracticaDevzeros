using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Save(TEntity entity);
        Task<IEnumerable<TEntity>> Consult();
        Task<TEntity> GetId(int id);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);

        

    }
}
