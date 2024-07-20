using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")] 
        public string Name { get; set; }
      
        public int DisplayOrder{ get; set; }
    }
}
