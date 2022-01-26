using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Response
{
    public class GenericConsultResponse<TEntity>
    {
        public IEnumerable<TEntity> Books { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public GenericConsultResponse(IEnumerable<TEntity> books)
        {
            Books = books;
            Error = false;
        }
        public GenericConsultResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
