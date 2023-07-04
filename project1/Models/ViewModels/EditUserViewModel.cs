using project1.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project1.Models.ViewModels
{
    public class EditUserViewModel
    {
        public UserDTO User { get; set; }
        public Roles Roles { get; set; }
    }
}