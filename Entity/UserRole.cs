using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UserRole
    {
        [Key]
        public int CodUserRole { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
