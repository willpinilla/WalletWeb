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
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var cuentas = await httpClient.GetStringAsync("http://localhost:51170//api/cuenta");
            var cuentasList = JsonConvert.DeserializeObject<List<Cuenta>>(cuentas);
            return View(cuentasList);
        }


        // GET: Cuenta/Create
        public async Task<ActionResult> Create()
        {
            Cuenta cta = new Cuenta();
            return View(cta);
        }

        // POST: Cuenta/Create
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

        // GET: Cuenta/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var httpClient = new HttpClient();
            var cuenta = await httpClient.GetStringAsync("http://localhost:51170//api/cuenta/" + id);
            var cuentaObj = JsonConvert.DeserializeObject<Cuenta>(cuenta);

            return View(cuentaObj);
        }

        // POST: Cuenta/Edit/5
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

        // GET: Cuenta/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var httpClient = new HttpClient();
            var cuenta = await httpClient.GetStringAsync("http://localhost:51170//api/cuenta/" + id);
            var cuentaObj = JsonConvert.DeserializeObject<Cuenta>(cuenta);

            return View(cuentaObj);
        }

        // POST: Cuenta/Delete/5
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
