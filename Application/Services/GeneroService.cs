using Application.DTOs.Cursos;
using Application.DTOs.Generos;
using Application.Interfaces;
using Application.Requests.Generos;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services {
    public class GeneroService : IGeneroService {
        public Dictionary<int, string> Generos { get; set; }
        public GeneroService()
        {
            Generos = Enum.GetValues(typeof(Genero)).Cast<Genero>().ToDictionary(t => (int)t, t => t.ToString());
        }

        public async Task<Response<GeneroDto>> GetGeneroById(GetGeneroByIdRequest request) {
            try {
                var genero = Generos.Where(x => x.Key == request.CdGenero).ToList().FirstOrDefault();

                if(genero.Key == 0 || string.IsNullOrEmpty(genero.Value)) return new Response<GeneroDto>(null, 500, "O genero informado não existe.");

                var dto = new GeneroDto { CdGenero = genero.Key, NmGenero = genero.Value };
                return new Response<GeneroDto>(dto, 200, "Genero encontrado!");
            }
            catch (Exception e) {
                return new Response<GeneroDto>(null, 500, "Algo deu errado tentando buscar o genero.");
            }
        }

        public async Task<PagedResponse<List<GeneroDto>>> GetGeneros(GetGenerosRequest request) {
            try {
                var generos = Generos
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

                List<GeneroDto> result = new();
                foreach (var genero in generos) {
                    result.Add(new GeneroDto { CdGenero = genero.Key, NmGenero = genero.Value });
                }

                return new PagedResponse<List<GeneroDto>>(
                    result,
                    Generos.Count,
                    request.PageNumber,
                    request.PageSize);
            }
            catch (Exception e) {
                return new PagedResponse<List<GeneroDto>>(null, 500, "Não foi possível consultar os generos");
            }
        }
    }
}
