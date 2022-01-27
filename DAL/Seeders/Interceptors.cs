using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeders
{
    public static class Interceptors
    {
        public static UserRole UserRole()
        {
            return new UserRole
            {
                CodUserRole = 1,
                Roles = null,
                Users = null,
            };
        }

        public static RolePermission RolePermission()
        {
            return new RolePermission
            {
                CodRolePermission = 1,
                Permissions = null,
                Roles = null
            };
        }
    }
}
