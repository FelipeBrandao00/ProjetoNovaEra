namespace Application.Requests.Professor;

public class CreateProfessorRequest
{
    public Guid CdProfessor { get; set; }
    public bool IcHabilitadoTurma { get; set; }
}