namespace Parical02
{
    public class Ordenes
    {
        public int idOrder { get; set; }
        
        public int idProduct { get; set; }
        
        public int idAddress { get; set; }
        
        public string createDate { get; set; }
       

        public Ordenes()
        {
            idOrder = 0;
            idProduct = 0;
            idAddress = 0;
            createDate = "";
        }
    }
}