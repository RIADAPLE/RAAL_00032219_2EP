using System;
using System.Collections.Generic;
using System.Data;

namespace Parical02
{
    public class UsuarioDAO
    {
        public static List<Usuario> getLista()
        {
            string sql = "SELECT * FROM \"AppUser\"";

            DataTable dt = Conexion.realizarConsulta(sql);
            List<Usuario> lista = new List<Usuario>();
            foreach (DataRow fila in dt.Rows)
            {
                Usuario u = new Usuario();
                u.idUser = Convert.ToInt32(fila[0].ToString());
                u.Fullname = fila[1].ToString();
                u.contrasena = fila[2].ToString();
                u.userType = Convert.ToBoolean(fila[3].ToString());
                u.Username = fila[4].ToString();
                lista.Add(u);
            }
            return lista;
        }
    }
}