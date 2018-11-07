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
    public class CategoriaController : ApiController
    {
        // GET: api/Categoria
        public List<Categoria> Get()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("WalletConnectionString");
            DbCommand dbc = db.GetStoredProcCommand("dbo.paGetCategorias");
            DataSet dsCategorias = db.ExecuteDataSet(dbc);
            List<Categoria> listaCategorias = ConvertToList(dsCategorias);
            return listaCategorias;
        }

        // GET: api/Categoria/5
        public Categoria Get(int id)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("WalletConnectionString");
            DbCommand dbc = db.GetStoredProcCommand("dbo.paGetCategoriaById");
            db.AddInParameter(dbc, "@IdCategoria", DbType.Int32, id);
            DataSet dsCategorias = db.ExecuteDataSet(dbc);
            List<Categoria> listaCategorias = ConvertToList(dsCategorias);
            return listaCategorias[0];
        }

        // POST: api/Categoria
        [HttpPost]
        public void Post(Categoria cat)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("WalletConnectionString");
            DbCommand dbc = db.GetStoredProcCommand("dbo.paGuardarCategoria");
            //db.AddInParameter(dbc, "@Id", DbType.Int32, categoria.TipoMovimientoId);
            //db.AddInParameter(dbc, "@NombreCategoria", DbType.String, categoria.Nombre);
            //db.AddInParameter(dbc, "@TipoMovimientoId", DbType.Int32, categoria.TipoMovimientoId);
            //db.ExecuteNonQuery(dbc);
        }

        // PUT: api/Categoria/5
        [HttpPut]
        public void Put(int id, Categoria cat)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("WalletConnectionString");
            DbCommand dbc = db.GetStoredProcCommand("dbo.paEditarCategoria");
            //db.AddInParameter(dbc, "@Id", DbType.Int32, categoria.TipoMovimientoId);
            //db.AddInParameter(dbc, "@NombreCategoria", DbType.String, categoria.Nombre);
            //db.AddInParameter(dbc, "@TipoMovimientoId", DbType.Int32, categoria.TipoMovimientoId);
            //db.ExecuteNonQuery(dbc);
        }

        // DELETE: api/Categoria/5
        public void Delete(int id)
        {
        }

        private static List<Categoria> ConvertToList(DataSet dsCuentas)
        {
            DataTable dt = dsCuentas.Tables[0];
            List<Categoria> listacategorias = (from item in dt.AsEnumerable()
                                               select new Categoria()
                                               {
                                                   Id = item.Field<int>("Id"),
                                                   Nombre = item.Field<string>("Nombre"),
                                                   TipoMovimiento = item.Field<string>("TipoMovimiento"),
                                                   TipoMovimientoId = item.Field<int>("TipoMovimientoId")
                                               }).ToList();
            return listacategorias;
        }
    }
}
