using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class RequestChangePassword
{
    [Key]
    [Required]
    public int CdRequest { get; set; }
    public Guid CdUsuario { get; set; }
    public string DsCodigoRedefinicao { get; set; }
    public DateTime DtValidade { get; set; }
    public DateTime? DtTrocaSenha { get; set; }
}