
using System.ComponentModel.DataAnnotations;

namespace minhaapi.Infrastructure.Interfaces
{
    public interface IBaseEntity
    {
        [Key]
        long Id { get; set; }
    }
}