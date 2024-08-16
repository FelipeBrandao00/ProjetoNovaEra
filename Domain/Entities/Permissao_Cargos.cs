namespace Domain.Entities;

public class Permissao_Cargos
{
    public int CdCargo { get; set; }
    public int CdPermissao { get; set; }

    public virtual required Cargo Cargo { get; set; }
    public virtual required Permissao Permissao { get; set; }
}