using System;
using System.Collections.Generic;
using System.Data;

namespace Parical02
{
    public class ProductoDAO
    {
        public static List<Producto> getProducto(){
            string sql = "SELECT * FROM \"Product\"";

            DataTable dt = Conexion.realizarConsulta(sql);
            List<Producto> lista = new List<Producto>();
            foreach (DataRow fila in dt.Rows)
            {
                Producto u = new Producto();
                u.idProduct = Convert.ToInt32(fila[0].ToString());
                u.idBuisness = Convert.ToInt32(fila[1].ToString());
                u.nameP = fila[2].ToString();
                lista.Add(u);
            }
            return lista;
        }
    }
}