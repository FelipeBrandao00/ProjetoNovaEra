using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Permissao
{
    [Key]
    public int CdPermissao { get; set; }
    public required string NmPermissao { get; set; }
    
    public virtual ICollection<Permissao_Cargos>? PermissaoCargos { get; set; }
}