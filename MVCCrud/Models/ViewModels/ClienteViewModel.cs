using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string NombreCliente { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string CorreoCliente { get; set; }
       [Required]
       [Display(Name = "Fecha de nacimiento")]
       [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
       [DataType(DataType.Date)]
       public DateTime FechaNacimiento { get; set; }
    }
}