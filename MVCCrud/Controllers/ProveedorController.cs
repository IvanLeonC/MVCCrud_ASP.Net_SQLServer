using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;
using MVCCrud.Models.ViewModels;

namespace MVCCrud.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            List<ListTablaViewModelProveedor> lst;
            using (CrudEntities1 db = new CrudEntities1())
            {
                lst = (from dp in db.Proveedor
                       select new ListTablaViewModelProveedor
                       {
                           IdProveedor = dp.id,
                           NombreProveedor = dp.nombre,
                           Empresa = dp.empresa,
                           Cedula = dp.cedula


                       }).ToList();
            }
            return View(lst);
            
        }

        public ActionResult NuevoProveedor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevoProveedor(ProveedorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities1 db = new CrudEntities1())
                    {
                        var oProveedor = new Proveedor();
                        oProveedor.nombre = model.NombreProveedor;
                        oProveedor.empresa = model.Empresa;
                        oProveedor.cedula = model.Cedula;

                        db.Proveedor.Add(oProveedor);
                        db.SaveChanges();
                    }
                    return Redirect("~/Proveedor/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }

        }
        public ActionResult EditarProveedor(int id)
        {
            ProveedorViewModel model = new ProveedorViewModel();
            using (CrudEntities1 db = new CrudEntities1())
            {
                var oProveedor = db.Proveedor.Find(id);
                model.NombreProveedor = oProveedor.nombre;
                model.Empresa = oProveedor.empresa;
                model.Cedula = oProveedor.cedula;
                model.IdProveedor = oProveedor.id;

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditarProveedor(ProveedorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities1 db = new CrudEntities1())
                    {

                        var oProveedor = db.Proveedor.Find(model.IdProveedor);
                        oProveedor.nombre = model.NombreProveedor;
                        oProveedor.empresa = model.Empresa;
                        oProveedor.cedula = model.Cedula;

                        db.Entry(oProveedor).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Proveedor/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }

        }
        [HttpGet]
        public ActionResult EliminarProveedor(int id)
        {

            using (CrudEntities1 db = new CrudEntities1())
            {
                var oProveedor = db.Proveedor.Find(id);
                db.Proveedor.Remove(oProveedor);
                db.SaveChanges();

            }
            return Redirect("~/Proveedor/");
        }
    }
}