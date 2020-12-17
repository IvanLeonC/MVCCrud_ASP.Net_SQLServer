using MVCCrud.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCCrud.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ListTablaViewModelProducto> lst;
            using (CrudEntities2 db = new CrudEntities2())
            {
                lst = (from dpr in db.Producto
                       select new ListTablaViewModelProducto
                       {
                           IdProducto = dpr.id,
                           NombreProducto = dpr.producto1,
                           Marca = dpr.marca,
                           Precio = dpr.precio


                       }).ToList();
            }
            return View(lst);

        }

        public ActionResult NuevoProducto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevoProducto(ProductoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities2 db = new CrudEntities2())
                    {
                        var oProducto = new Producto();
                        oProducto.producto1 = model.NombreProducto;
                        oProducto.marca = model.Marca;
                        oProducto.precio = model.Precio;

                        db.Producto.Add(oProducto);
                        db.SaveChanges();
                    }
                    return Redirect("~/Producto/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }
        public ActionResult EditarProducto(int id)
        {
            ProductoViewModel model = new ProductoViewModel();
            using (CrudEntities2 db= new CrudEntities2())
            {
                var oProducto = db.Producto.Find(id);
                model.NombreProducto = oProducto.producto1;
                model.Marca = oProducto.marca;
                model.Precio = oProducto.precio;
                model.IdProducto = oProducto.id;

            }
                return View(model);
        }
        [HttpPost]
        public ActionResult EditarProducto(ProductoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities2 db = new CrudEntities2())
                    {
                        var oProducto = db.Producto.Find(model.IdProducto);
                        oProducto.producto1 = model.NombreProducto;
                        oProducto.marca = model.Marca;
                        oProducto.precio = model.Precio;

                        db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Producto/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }
        [HttpGet]
        public ActionResult EliminarProducto(int id)
        {

            using (CrudEntities2 db = new CrudEntities2())
            {
                var oProducto = db.Producto.Find(id);
                db.Producto.Remove(oProducto);
                db.SaveChanges();

            }
            return Redirect("~/Producto/");
        }
    }
}