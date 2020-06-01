using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparcial.Modelo
{
    public class Inventario
    {
        //Se puso public a todos los getters y se le añadieron setters
        public string idArticulo { get; set; }
        public string producto { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }
        public string stock { get; set; }

        public Inventario(string idArticulo, string producto, string descripcion, string precio, string stock)
        {
            this.idArticulo = idArticulo;
            this.producto = producto;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }
    }
}
