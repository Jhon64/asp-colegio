namespace DTO
{
    public class UsuarioCreateDTO
    {
        public string username { get; set; }
        public string password { get; set; }
        public int rol { get;set; }
        public int persona_id { get; set; }
    }
}