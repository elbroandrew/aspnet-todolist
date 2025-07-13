using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Models;

public class TodoTask: BaseModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [MaxLength(200)]
    [Column(TypeName = "varchar(200)")]
    public required string Title { get; set; }
    
    [Required]
    public bool Completed { get; set; }
    
    public int UserId { get; set; }
    public User? User { get; set; } = null; // навигационное свойство

}