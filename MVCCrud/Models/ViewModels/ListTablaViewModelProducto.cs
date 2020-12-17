using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class ListTablaViewModelProducto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Marca { get; set; }
        public int Precio { get; set; }
    }
}