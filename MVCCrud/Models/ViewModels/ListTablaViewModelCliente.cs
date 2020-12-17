using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class ListTablaViewModelCliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string CorreoCliente { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}