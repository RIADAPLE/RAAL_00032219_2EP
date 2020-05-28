namespace Parical02
{
    public class Producto
    {
        public int idProduct { get; set; }
        
        public int idBuisness { get; set; }
        
        public string nameP { get; set; }
       

        public Producto()
        {
            idProduct = 0;
            idBuisness = 0;
            nameP = "";
        }
    }
}