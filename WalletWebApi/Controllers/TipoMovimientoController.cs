using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace WalletWebApi.Controllers
{
    public class TipoMovimientoController : ApiController
    {
        // GET: api/TipoMovimiento
        public List<TipoMovimiento> Get()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("WalletConnectionString");
            DbCommand dbc = db.GetStoredProcCommand("dbo.paGetTiposMovimiento");
            DataSet dsTiposMovimiento = db.ExecuteDataSet(dbc);
            List<TipoMovimiento> listaTiposMovimiento = ConvertToList(dsTiposMovimiento);
            return listaTiposMovimiento;
        }

        // GET: api/TipoMovimiento/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TipoMovimiento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TipoMovimiento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TipoMovimiento/5
        public void Delete(int id)
        {
        }

        private static List<TipoMovimiento> ConvertToList(DataSet dsTiposMovimiento)
        {
            DataTable dt = dsTiposMovimiento.Tables[0];
            List<TipoMovimiento> listatiposmovimiento = (from item in dt.AsEnumerable()
                                                         select new TipoMovimiento()
                                                         {
                                                             Id = item.Field<int>("Id"),
                                                             Nombre = item.Field<string>("Nombre")
                                                         }).ToList();
            return listatiposmovimiento;
        }
    }
}
