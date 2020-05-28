namespace Parical02
{
    public class Dirección
    {
        public int idAddress { get; set; }
        
        public int idUser1 { get; set; }
        
        public string address { get; set; }
       

        public Dirección()
        {
            idAddress = 0;
            idUser1 = 0;
            address = "";
        }
    }
}