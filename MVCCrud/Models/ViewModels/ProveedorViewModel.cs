using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class ProveedorViewModel
    {
        public int IdProveedor { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string NombreProveedor { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Empresa")]
        public string Empresa { get; set; }


        [Required]
        [Display(Name = "Cedula")]
        public int Cedula { get; set; }
    }
}