using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Response
{
    public class BookConsultaResponse : GenericConsultResponse<Book>
    {
        public BookConsultaResponse(string mensaje) : base(mensaje)
        {
        }

        public BookConsultaResponse(IEnumerable<Book> books): base(books)
        {
        }
    }
}
