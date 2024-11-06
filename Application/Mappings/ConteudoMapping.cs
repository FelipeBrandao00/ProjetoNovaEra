using Application.DTOs.Conteudo;
using Application.DTOs.Cursos;
using Application.Requests.Conteudo;
using Application.Requests.Curso;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings {
    public class ConteudoMapping : Profile {
        public ConteudoMapping()
        {
            CreateMap<Conteudo, ConteudoDto>().ReverseMap();
            CreateMap<Conteudo, AddConteudoRequest>().ReverseMap();
            CreateMap<Conteudo, UpdateConteudoRequest>().ReverseMap();
            CreateMap<Conteudo, DeleteConteudoRequest>().ReverseMap();
        }
    }
}
