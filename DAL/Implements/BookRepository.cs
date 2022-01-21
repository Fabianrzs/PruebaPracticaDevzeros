using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implements
{
    public class BookRepository: GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationContext context): base(context){}
    }
}
