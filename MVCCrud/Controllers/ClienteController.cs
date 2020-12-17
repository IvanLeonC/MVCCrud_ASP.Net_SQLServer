using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;
using MVCCrud.Models.ViewModels;

namespace MVCCrud.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ListTablaViewModelCliente> lst;
            using (CrudEntities db = new CrudEntities())
            {
                lst = (from d in db.Cliente
                       select new ListTablaViewModelCliente
                       {
                           IdCliente = d.id,
                           NombreCliente = d.nombre,
                           CorreoCliente = d.correo,
                           FechaNacimiento = d.fecha_nacimiento


                       }).ToList();
            }
            return View(lst);
        }
        public ActionResult NuevoCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevoCliente(ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oCliente = new Cliente();
                        oCliente.nombre = model.NombreCliente;
                        oCliente.correo = model.CorreoCliente;
                        oCliente.fecha_nacimiento = model.FechaNacimiento;
                        

                        db.Cliente.Add(oCliente);
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/");
                    
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

                
            }

        }
  
        public ActionResult EditarCliente(int id)
        {
            ClienteViewModel model = new ClienteViewModel();
            using (CrudEntities db = new CrudEntities())
            {
                var oCliente = db.Cliente.Find(id);
                model.NombreCliente = oCliente.nombre;
                model.CorreoCliente = oCliente.correo;
                model.FechaNacimiento = oCliente.fecha_nacimiento;
                model.IdCliente = oCliente.id;
            }
                return View(model);
        }
        [HttpPost]
        public ActionResult EditarCliente(ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oCliente = db.Cliente.Find(model.IdCliente);
                        oCliente.nombre = model.NombreCliente;
                        oCliente.correo = model.CorreoCliente;
                        oCliente.fecha_nacimiento = model.FechaNacimiento;


                        db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/");

                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }

        }
        [HttpGet]
        public ActionResult EliminarCliente(int id)
        {
            
            using (CrudEntities db = new CrudEntities())
            {
                var oCliente = db.Cliente.Find(id);
                db.Cliente.Remove(oCliente);
                db.SaveChanges();

            }
            return Redirect("~/Cliente/");
        }
    }
}