using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;


namespace WalletWeb.Controllers
{
    public class MovimientoController : Controller
    {
        // GET: Movimiento
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var movimientos = await httpClient.GetStringAsync("http://localhost:51170//api/movimiento");
            var movimientosList = JsonConvert.DeserializeObject<List<Movimiento>>(movimientos);
            return View(movimientosList);
        }

        // GET: Movimiento/Create
        public async Task<ActionResult> Create()
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

            Movimiento mov = new Movimiento();
            return View(mov);
        }

        // POST: Movimiento/Create
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

        // GET: Movimiento/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var httpClient = new HttpClient();
            var movimiento = await httpClient.GetStringAsync("http://localhost:51170//api/movimiento/" + id);
            var movimientoObj = JsonConvert.DeserializeObject<Movimiento>(movimiento);

            var tiposmovimiento = await httpClient.GetStringAsync("http://localhost:51170//api/tipomovimiento");
            var tiposmovimientoList = JsonConvert.DeserializeObject<List<TipoMovimiento>>(tiposmovimiento);
            ViewBag.TiposMovimiento = new SelectList(tiposmovimientoList, "Id", "Nombre");

            var cuentas = await httpClient.GetStringAsync("http://localhost:51170//api/cuenta");
            var cuentasList = JsonConvert.DeserializeObject<List<Cuenta>>(cuentas);
            ViewBag.Cuentas = new SelectList(cuentasList, "Id", "Nombre");

            var categorias = await httpClient.GetStringAsync("http://localhost:51170//api/categoria");
            var categoriasList = JsonConvert.DeserializeObject<List<Categoria>>(categorias);
            ViewBag.Categorias = new SelectList(categoriasList, "Id", "Nombre");


            return View(movimientoObj);
        }

        // POST: Movimiento/Edit/5
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

        // GET: Movimiento/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var httpClient = new HttpClient();
            var movimiento = await httpClient.GetStringAsync("http://localhost:51170//api/movimiento/" + id);
            var movimientoObj = JsonConvert.DeserializeObject<Movimiento>(movimiento);

            return View(movimientoObj);
        }

        // POST: Movimiento/Delete/5
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
