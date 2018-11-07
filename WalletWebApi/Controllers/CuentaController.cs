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
    public class CuentaController : ApiController
    {
        // GET: api/Cuenta
        public List<Cuenta> Get()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("WalletConnectionString");
            DbCommand dbc = db.GetStoredProcCommand("dbo.paGetCuentas");
            DataSet dsCuentas = db.ExecuteDataSet(dbc);
            List<Cuenta> listaCuentas = ConvertToList(dsCuentas);
            return listaCuentas;
        }

        // GET: api/Cuenta/5
        public Cuenta Get(int id)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("WalletConnectionString");
            DbCommand dbc = db.GetStoredProcCommand("dbo.paGetCuentaById");
            db.AddInParameter(dbc, "@IdCuenta", DbType.Int32, id);
            DataSet dsCuentas = db.ExecuteDataSet(dbc);
            List<Cuenta> listaCuentas = ConvertToList(dsCuentas);
            return listaCuentas[0];
        }

        // POST: api/Cuenta
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cuenta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cuenta/5
        public void Delete(int id)
        {
        }


        private static List<Cuenta> ConvertToList(DataSet dsCuentas)
        {
            DataTable dt = dsCuentas.Tables[0];
            List<Cuenta> listacuentas = (from item in dt.AsEnumerable()
                                         select new Cuenta()
                                         {
                                             Id = item.Field<int>("Id"),
                                             Nombre = item.Field<string>("Nombre"),
                                             FechaCreacion = item.Field<DateTime>("Fecha_creacion")
                                         }).ToList();
            return listacuentas;
        }
    }
}
