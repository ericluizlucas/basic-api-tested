using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using minhaapi.Infrastructure.Interfaces;

namespace minhaapi.Infrastructure.Entities
{
    [Table("Product")]
    public class Product : BaseEntity, IBaseEntity
    {
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string CategoryUuid { get; set; } = string.Empty;

        public Product(string nome, string categoryUuid)
        {
            Nome = nome;
            CategoryUuid = categoryUuid;
        }

        public Product() { }
    }
}