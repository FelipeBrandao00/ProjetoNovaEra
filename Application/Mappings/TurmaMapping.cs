using Application.DTOs.CargoUsuario;
using Application.DTOs.Turma;
using Application.Requests.CargoUsuario;
using Application.Requests.Turma;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings {
    public class TurmaMapping : Profile{
        public TurmaMapping()
        {
            CreateMap<TurmaDto, Turma>().ReverseMap();
            CreateMap<AddTurmaRequest, Turma>().ReverseMap();
            CreateMap<UpdateTurmaRequest, Turma>().ReverseMap();
        }
    }
}
