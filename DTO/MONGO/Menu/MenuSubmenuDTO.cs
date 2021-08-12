using System.Collections.Generic;

namespace DTO.mongo
{
    public class MenuSubmenuDTO
    {
        public string _id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string icono { get; set; }
        public string css { get; set; }
        public bool estado { get; set; }
        public string url { get; set; } 
        public string clases { get; set; }
        public string color { get; set; }
        public ICollection<SubmenuDTO> submenus { get; set; }
        
    }
}