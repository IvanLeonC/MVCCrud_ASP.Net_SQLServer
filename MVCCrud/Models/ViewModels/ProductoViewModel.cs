using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class ProductoViewModel
    {
        public int IdProducto { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Producto")]
        public string NombreProducto { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Marca")]
        public string Marca { get; set; }


        [Required]
        [Display(Name = "Precio")]
        public int Precio { get; set; }
    }
}