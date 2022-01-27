using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RolePermission
    {
        [Key]
        public int CodRolePermission { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
