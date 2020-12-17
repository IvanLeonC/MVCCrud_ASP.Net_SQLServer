using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class ListTablaViewModelProveedor
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string Empresa { get; set; }
        public int Cedula { get; set; }
    }
}