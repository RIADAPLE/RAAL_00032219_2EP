using System;
using System.Collections.Generic;
using System.Data;

namespace Parical02
{
    public class EmpresaDAO
    {
        public static List<Empresa> getEmpresa(){
            string sql = "SELECT * FROM \"Buisness\"";

            DataTable dt = Conexion.realizarConsulta(sql);
            List<Empresa> lista = new List<Empresa>();
            foreach (DataRow fila in dt.Rows)
            {
                Empresa u = new Empresa();
                u.idBuisness = Convert.ToInt32(fila[0].ToString());
                u.NameE = fila[1].ToString();
                u.Description = fila[2].ToString();
                lista.Add(u);
            }
            return lista;
        }
    }
}