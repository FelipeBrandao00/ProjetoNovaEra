using Application.DTOs.Certificado;
using Application.Requests.Certificado;
using Application.Requests.Conteudo;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings {
    public class CertificadoMapping : Profile {
        public CertificadoMapping()
        {
            CreateMap<Certificado, CertificadoDto>().ReverseMap();
            CreateMap<Certificado, AddCertificadoRequest>().ReverseMap();
            CreateMap<Certificado, DeleteCertificadoRequest>().ReverseMap();
        }
    }
}
