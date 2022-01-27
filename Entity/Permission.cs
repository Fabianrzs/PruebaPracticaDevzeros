using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Permission
    {
        [Key]
        public int CodPermission { get; set; }
        public string NamePermission { get; set; }
        public string DescripcionPermission { get; set; }

        public RolePermission RolePermission { get; set; }

    }
}
