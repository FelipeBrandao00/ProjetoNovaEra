namespace Application.DTOs.PasswordChange;

public record PasswordChangeDto(Guid CdUsuario,string DsCodigoRedefinicao,DateTime DtValidade);