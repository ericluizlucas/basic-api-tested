using System.ComponentModel.DataAnnotations;

namespace minhaapi.Common.Models
{
    public class ProductModel : BaseModel
    {
        [Required]
        public string? Nome { get; set; }
        
        [Required]
        public string? CategoryUuid { get; set; }
    }
}