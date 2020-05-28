using System;
using System.Collections.Generic;
using System.Data;

namespace Parical02
{
    public class DirecciónDAO
    {
        public static List<Dirección> getDirección(){
            string sql = "SELECT * FROM \"Address\"";

            DataTable dt = Conexion.realizarConsulta(sql);
            List<Dirección> lista = new List<Dirección>();
            foreach (DataRow fila in dt.Rows)
            {
                Dirección u = new Dirección();
                u.idAddress = Convert.ToInt32(fila[0].ToString());
                u.idUser1 = Convert.ToInt32(fila[1].ToString());
                u.address = fila[2].ToString();
                lista.Add(u);
            }
            return lista;
        }
    }
}