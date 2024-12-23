﻿using Application.DTOs;
using Application.DTOs.Jwt;
using Application.DTOs.Usuario;
using Application.Requests.Usuarios;
using Application.Responses;
using Domain.Entities;

namespace Application.Interfaces {
    public interface IUsuarioService {
        Task<Response<UsuarioDto>> AddUsuario(CreateUsuarioRequest request);
        Task<Response<UsuarioDto>> UpdateUsuario(UpdateUsuarioRequest request);
        Task<Response<UsuarioDto>> GetUsuarioByCpf(GetUsuarioByCpfRequest request);
        Task<PagedResponse<List<UsuarioDto>>> GetUsuarios(GetAllUsuariosRequest request);
        Task<PagedResponse<List<UsuarioDto>>> GetUsuariosByCargo(GetAllUsuariosByCargoRequest request);
        Task<Response<UsuarioDto>> GetUsuarioByEmail(GetUsuarioByEmailRequest request);
        Task<Response<UsuarioDto>> UpdatePasswordUsuario(UpdateUsuarioPasswordRequest request);
        Task<PagedResponse<List<UsuarioDto>>> GetUsuariosByCargos(GetUsuariosByCargosRequest request);
        string GeneratePasswordResetToken();
    }
}
