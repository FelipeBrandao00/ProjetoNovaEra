namespace Domain.Entities;

public class Permissao_Cargos
{
    public int CdCargo { get; set; }
    public int CdPermissao { get; set; }

    public virtual Cargo Cargo { get; set; }
    public virtual Permissao Permissao { get; set; }
}