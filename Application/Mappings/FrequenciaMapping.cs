using Application.DTOs.Frequencia;
using Application.Requests.Frequencia;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings {
    public class FrequenciaMapping : Profile {
        public FrequenciaMapping()
        {
            CreateMap<Frequencia, FrequenciaDto>().ReverseMap();
            CreateMap<Frequencia, AddFrequenciaRequest>().ReverseMap();
            CreateMap<Frequencia, DeleteFrequenciaRequest>().ReverseMap();
        }
    }
}
