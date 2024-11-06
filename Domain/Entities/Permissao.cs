using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Permissao
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CdPermissao { get; set; }
    public required string NmPermissao { get; set; }
    
    public virtual ICollection<Permissao_Cargos>? PermissaoCargos { get; set; }
}