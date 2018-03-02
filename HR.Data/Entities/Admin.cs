
using System.ComponentModel.DataAnnotations;
namespace HR.Data.Entities
{
    public class Admin : BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
