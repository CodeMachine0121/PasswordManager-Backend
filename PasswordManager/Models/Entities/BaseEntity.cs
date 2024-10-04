using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace PasswordManager.Models.Entities;

public class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public Timestamp CreatedOn { get; set; }
    
    [Required]
    public string CreatedBy { get; set; }
    
    public Timestamp ModifiedOn { get; set; }
    
    public string ModifiedBy { get; set; }
}