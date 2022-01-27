using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Role
    {
        [Key]
        public int CodRole { get; set; }
        public string NameRole { get; set; }
        public RolePermission RolePermission { get; set; }
    }
}
