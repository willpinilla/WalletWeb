using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WalletWeb.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();

            var tiposmovimiento = await httpClient.GetStringAsync("http://localhost:51170//api/tipomovimiento");
            var tiposmovimientoList = JsonConvert.DeserializeObject<List<TipoMovimiento>>(tiposmovimiento);
            ViewBag.TiposMovimiento = new SelectList(tiposmovimientoList, "Id", "Nombre");

            var cuentas = await httpClient.GetStringAsync("http://localhost:51170//api/cuenta");
            var cuentasList = JsonConvert.DeserializeObject<List<Cuenta>>(cuentas);
            ViewBag.Cuentas = new SelectList(cuentasList, "Id", "Nombre");

            var categorias = await httpClient.GetStringAsync("http://localhost:51170//api/categoria");
            var categoriasList = JsonConvert.DeserializeObject<List<Categoria>>(categorias);
            ViewBag.Categorias = new SelectList(categoriasList, "Id", "Nombre");

            return View();
        }

        // GET: Reporte/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reporte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reporte/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reporte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reporte/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reporte/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reporte/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
