using Application.DTOs.Aula;
using Application.Requests.Aula;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings {
    public class AulaMapping : Profile {
        public AulaMapping()
        {
            CreateMap<Aula, AulaDto>().ReverseMap();
            CreateMap<Aula, AddAulaRequest>().ReverseMap();
            CreateMap<Aula, DeleteAulaRequest>().ReverseMap();
            CreateMap<Aula, UpdateAulaRequest>().ReverseMap();
        }
    }
}
