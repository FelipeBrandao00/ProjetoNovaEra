using Application.DTOs.PasswordChange;
using Application.Requests.PasswordChange;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class PasswordChangeMapping : Profile
{
    public PasswordChangeMapping()
    {
        CreateMap<RequestChangePassword, AddPasswordChangeRequest>().ReverseMap(); 
    }
}