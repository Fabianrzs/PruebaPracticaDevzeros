using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Presentacion.Models
{
    public class LoginInputModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        
        public string Password { get; set; }
    }
    public class LoginViewModel
    {
        public string UserName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }

        public string Email { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
    }

}
