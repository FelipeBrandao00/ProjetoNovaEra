using Application.DTOs.Matricula;
using Application.Requests.Matricula;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MatriculaMapping : Profile
    {
        public MatriculaMapping()
        {
            CreateMap<Matricula, MatriculaDto>().ReverseMap();
            CreateMap<Matricula, AddMatriculaRequest>().ReverseMap();
        }
    }
}
