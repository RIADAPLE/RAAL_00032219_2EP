namespace Parical02
{
    public class Usuario
    {
        public int idUser { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string contrasena { get; set; }
        public bool userType { get; set; }

        public Usuario()
        {
            idUser = 0;
            Username = "";
            Fullname = "";
            contrasena = "";
            userType = false;
        }
    }
}