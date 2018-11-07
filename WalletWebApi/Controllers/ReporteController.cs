using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Web.Http.Cors;

namespace WalletWebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ReporteController : ApiController
    {
        // GET: api/Reporte
        [HttpGet]
        public List<ReporteResultados> GetReporte(int TipoMovimientoId, int CuentaId, int CategoriaId, string FechaInicio, string FechaFin)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("WalletConnectionString");
            DbCommand dbc = db.GetStoredProcCommand("dbo.paGetReporte");
            db.AddInParameter(dbc, "@TipoMovimientoId", DbType.Int32, TipoMovimientoId);
            db.AddInParameter(dbc, "@CuentaId", DbType.Int32, CuentaId);
            db.AddInParameter(dbc, "@CategoriaId", DbType.Int32, CategoriaId);
            db.AddInParameter(dbc, "@FechaInicio", DbType.String, FechaInicio);
            db.AddInParameter(dbc, "@FechaFin", DbType.String, FechaFin);
            DataSet dsReporteResultados = db.ExecuteDataSet(dbc);
            List<ReporteResultados> listaReporteResultados = ConvertToList(dsReporteResultados);
            return listaReporteResultados;
            
        }


        private static List<ReporteResultados> ConvertToList(DataSet dsReporteResultados)
        {
            DataTable dt = dsReporteResultados.Tables[0];
            List<ReporteResultados> listaReporteResultados = (from item in dt.AsEnumerable()
                                                              select new ReporteResultados()
                                                              {
                                                                  TipoMovimiento = item.Field<string>("TipoMovimiento"),
                                                                  Categoria = item.Field<string>("Categoria"),
                                                                  Cuenta = item.Field<string>("Cuenta"),
                                                                  Valor = item.Field<decimal>("Valor")
                                                              }).ToList();
            return listaReporteResultados;
        }
    }
}
