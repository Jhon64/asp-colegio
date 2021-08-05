using System;

namespace EntitySQL
{
    public class Usuario
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int rol { get; set; }

        public int persona_id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updateAt { get; set; }

    }
}
