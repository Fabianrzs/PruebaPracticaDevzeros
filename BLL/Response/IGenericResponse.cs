using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Response
{
    public interface IGenericResponse<TEntity> where TEntity : class
    {
        public TEntity Entity { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
    }
}
