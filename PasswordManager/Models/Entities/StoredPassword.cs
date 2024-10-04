using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Models.Entities;

public class StoredPassword: BaseEntity
{
    [Required]
    [StringLength(100)]
    public string DomainName { get; set; }
    
    [Required]
    [StringLength(20)]
    public string AccountName { get; set; }

    [Required]
    [StringLength(50)]
    public string Password { get; set; }
}