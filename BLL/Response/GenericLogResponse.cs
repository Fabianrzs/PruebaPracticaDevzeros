using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Response
{
    public class GenericlogResponse<TEntity> where TEntity : class
    {
        public TEntity Entity { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public GenericlogResponse(TEntity entity)
        {
            Entity = entity;
            Error = false;  
        }

        public GenericlogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
        
    }
}
