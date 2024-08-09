﻿using Application.DTOs;
using Application.DTOs.Jwt;
using Application.DTOs.Usuario;
using Application.Requests.Usuarios;
using Application.Responses;

namespace Application.Interfaces {
    public interface IUsuarioService {
        Task<Response<UsuarioDto>> AddUsuario(CreateUsuarioRequest request);
        Task<Response<UsuarioDto>> UpdateUsuario(UpdateUsuarioRequest request);
        Task<Response<UsuarioDto>> GetUsuarioByCpf(GetUsuarioByCpfRequest request);
        Task<PagedResponse<List<UsuarioDto>>> GetUsuarios(GetAllUsuariosRequest request);
    }
}
