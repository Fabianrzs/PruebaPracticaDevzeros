using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Response
{
    public class BookLogResponse<Book> : GenericlogResponse<Book> where Book : class 
    {
        public BookLogResponse(Book entity) : base(entity)
        {
        }
        public BookLogResponse(string mensaje) : base(mensaje)
        {
        }
    }
}
