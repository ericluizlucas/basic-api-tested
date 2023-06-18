using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using minhaapi.Infrastructure.Interfaces;

namespace minhaapi.Infrastructure.Entities
{
    [Table("Category")]
    public class Category : BaseEntity, IBaseEntity
    {
        [Required]
        public string Nome { get; set; } = string.Empty;

        public Category(string nome)
        {
            Nome = nome;
        }

        public Category() { }
    }
}