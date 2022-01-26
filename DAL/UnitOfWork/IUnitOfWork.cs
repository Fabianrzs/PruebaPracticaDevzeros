using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        public ApplicationContext Context { get; }
        public void Commit();
    }
}
