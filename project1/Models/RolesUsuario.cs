namespace project1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RolesUsuario")]
    public partial class RolesUsuario
    {
        public int id { get; set; }

        public int id_role { get; set; }

        [Required(ErrorMessage = "Please select a role")]
        [Display(Name = "Role")]
        public int id_user { get; set; }
    }
}
