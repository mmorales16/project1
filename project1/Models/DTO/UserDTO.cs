using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project1.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int RoleId { get; set; }  // Nueva propiedad para el ID del rol.
    }
}