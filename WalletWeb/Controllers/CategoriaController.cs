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
    public class CategoriaController : Controller
    {
        // GET: Personas
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var categorias = await httpClient.GetStringAsync("http://localhost:51170//api/categoria");
            var categoriasList = JsonConvert.DeserializeObject<List<Categoria>>(categorias);
            return View(categoriasList);
        }


        // GET: Categoria/Create
        public async Task<ActionResult> Create()
        {
            var httpClient = new HttpClient();

            var categorias = await httpClient.GetStringAsync("http://localhost:51170//api/categoria");
            var categoriasList = JsonConvert.DeserializeObject<List<Categoria>>(categorias);
            ViewBag.Categorias = new SelectList(categoriasList, "Id", "Nombre");

            Categoria cat = new Categoria();
            return View(cat);
        }

        // POST: Categoria/Create
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

        // GET: Categoria/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var httpClient = new HttpClient();
            var categoria = await httpClient.GetStringAsync("http://localhost:51170//api/categoria/" + id);
            var categoriaObj = JsonConvert.DeserializeObject<Categoria>(categoria);

            var categorias = await httpClient.GetStringAsync("http://localhost:51170//api/categoria");
            var categoriasList = JsonConvert.DeserializeObject<List<Categoria>>(categorias);
            ViewBag.Categorias = new SelectList(categoriasList, "Id", "Nombre");

            return View(categoriaObj);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public async Task <ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                //string Nombre = Request.Form["Nombre"];
                //int TipoMovimientoId = Convert.ToInt32(Request.Form["TipoMovimientoId"]);
                string Nombre = collection["Nombre"];
                int TipoMovimientoId = Convert.ToInt32(collection["TipoMovimientoId"]);

                var httpClient = new HttpClient();
                Categoria categoria = new Categoria() { Id = id, Nombre = Nombre, TipoMovimientoId = TipoMovimientoId };
                //HttpResponseMessage response = await httpClient.PutAsJsonAsync("http://localhost:51170//api/categoria/" + id, categoria);
                var response = httpClient.PutAsync("http://localhost:51170//api/categoria/Edit/" + id, new StringContent(
                new JavaScriptSerializer().Serialize(categoria), Encoding.UTF8, "application/json")).Result;
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var httpClient = new HttpClient();
            var categoria = await httpClient.GetStringAsync("http://localhost:51170//api/categoria/" + id);
            var categoriaObj = JsonConvert.DeserializeObject<Categoria>(categoria);

            return View(categoriaObj);
        }

        // POST: Categoria/Delete/5
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
