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
    public class MovimientoController : ApiController
    {
        // GET: api/Movimiento
        public List<Movimiento> Get()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("WalletConnectionString");
            DbCommand dbc = db.GetStoredProcCommand("dbo.paGetMovimientos");
            DataSet dsMovimientos = db.ExecuteDataSet(dbc);
            List<Movimiento> listaMovimientos = ConvertToList(dsMovimientos);
            return listaMovimientos;
        }

        // GET: api/Movimiento/5
        public Movimiento Get(int id)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("WalletConnectionString");
            DbCommand dbc = db.GetStoredProcCommand("dbo.paGetMovimientoById");
            db.AddInParameter(dbc, "@IdMovimiento", DbType.Int32, id);
            DataSet dsMovimientos = db.ExecuteDataSet(dbc);
            List<Movimiento> listaMovimientos = ConvertToList(dsMovimientos);
            return listaMovimientos[0];
        }

        // POST: api/Movimiento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Movimiento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Movimiento/5
        public void Delete(int id)
        {
        }

        private static List<Movimiento> ConvertToList(DataSet dsMovimientos)
        {
            DataTable dt = dsMovimientos.Tables[0];
            List<Movimiento> listamovimientos = (from item in dt.AsEnumerable()
                                                 select new Movimiento()
                                                 {
                                                     Id = item.Field<int>("Id"),
                                                     Descripcion = item.Field<string>("Descripcion"),
                                                     Valor = item.Field<decimal>("Valor"),
                                                     Fecha = item.Field<DateTime>("Fecha"),
                                                     TipoMovimiento = item.Field<string>("TipoMovimiento"),
                                                     TipoMovimientoId = item.Field<int>("TipoMovimientoId"),
                                                     Categoria = item.Field<string>("Categoria"),
                                                     CategoriaId = item.Field<int>("CategoriaId"),
                                                     Cuenta = item.Field<string>("Cuenta"),
                                                     CuentaId = item.Field<int>("CuentaId"),
                                                 }).ToList();
            return listamovimientos;
        }
    }
}
