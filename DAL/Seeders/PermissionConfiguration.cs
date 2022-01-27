using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeders
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasData
            (
                new Permission
                {
                    CodPermission = 1,
                    NamePermission = "Guardar",
                    DescripcionPermission = "Guardar Entities",
                    RolePermission = Interceptors.RolePermission(), 
                },
                new Permission
                {
                    CodPermission = 2,
                    NamePermission = "Modificar",
                    DescripcionPermission = "Moficar Entities",
                    RolePermission = Interceptors.RolePermission(),
                },
                new Permission
                {
                    CodPermission = 3,
                    NamePermission = "Consultar",
                    DescripcionPermission = "Consultar Entities",
                    RolePermission = Interceptors.RolePermission(),
                }
            ); 
        }
    }
}
