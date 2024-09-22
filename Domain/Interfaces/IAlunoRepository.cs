﻿using Domain.Entities;

namespace Domain.Interfaces;

public interface IAlunoRepository
{
    Task<List<Turma_Aluno>> GetAllTurmasByUsuarioId(Guid cdUsuario);
    Task<Turma_Aluno?> GetAtualTurmaByUsuarioId(Guid cdUsuario);
}