using System.ComponentModel.DataAnnotations;

namespace RetroVolt.Models
{
    public class Category 
    {
        //columns in table (properties)
        //Use data annotation to allocate Key

        [Key]
        public int Id { get; set; } //PK
        [Required]
        public string Name { get; set; } //will have a not null setting -> required
        public int DisplayOrder { get; set; }

    }
}
