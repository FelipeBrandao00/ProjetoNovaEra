using Application.DTOs.PasswordChange;
using Application.Requests.PasswordChange;
using Application.Responses;
using Domain.Entities;

namespace Application.Interfaces;

public interface IPasswordChangeService
{
    Task<Response<PasswordChangeDto>> AddPasswordChange(AddPasswordChangeRequest request);
    Task<Response<PasswordChangeDto>> VerifyPasswordChangeCode(VerifyPasswordChangeCodeRequest request);
}