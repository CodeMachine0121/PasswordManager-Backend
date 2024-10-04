using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasswordManager.Models.Entities;

public class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public DateTimeOffset CreatedOn { get; set; }
    
    [Required]
    public string CreatedBy { get; set; }
    
    public DateTimeOffset ModifiedOn { get; set; }
    
    public string ModifiedBy { get; set; }
}