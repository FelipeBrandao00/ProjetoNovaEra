using Application.DTOs.Matricula;
using Application.DTOs.Usuario;
using Application.Requests.Matricula;
using Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMatriculaService
    {
        Task<PagedResponse<List<MatriculaDto>>> GetMatriculasByTurmaId(GetMatriculasByTurmaIdRequest request);
        Task<Response<MatriculaDto>> AddMatricula(AddMatriculaRequest request);
        Task<Response<MatriculaDto>> GetMatriculaById(GetMatriculaByIdRequest request);
        Task<PagedResponse<List<UsuarioDto>>> EfetivarMatriculas(EfetivarMatriculasRequest request);
    }
}

