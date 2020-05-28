using System;
using System.Collections.Generic;
using System.Data;

namespace Parical02
{
    public class OrdenesDAO
    {
        public static List<Ordenes> getOrdenes(){
            string sql = "SELECT * FROM \"AppOrder\"";

            DataTable dt = Conexion.realizarConsulta(sql);
            List<Ordenes> lista = new List<Ordenes>();
            foreach (DataRow fila in dt.Rows)
            {
                Ordenes u = new Ordenes();
                u.idOrder = Convert.ToInt32(fila[0].ToString());
                u.idProduct = Convert.ToInt32(fila[1].ToString());
                u.idAddress = Convert.ToInt32(fila[2].ToString());
                u.createDate = fila[3].ToString();
                lista.Add(u);
            }
            return lista;
        }
    }
}