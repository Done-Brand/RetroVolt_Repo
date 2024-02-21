using System.ComponentModel;
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
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; } //will have a not null setting -> required

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1-100")] //built in validation, min = 1, max = 100
        public int DisplayOrder { get; set; }

    }
}
