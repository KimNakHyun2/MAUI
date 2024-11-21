using Icecream.Shared.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icecream.App.Services;

public interface IAuthApi
{
    [Post("/api/auth/signup")]
    Task<ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto);

    [Post("/api/auth/signin")]
    Task<ResultWithDataDto<AuthResponseDto>> SigninAsync(SigninRequestDto dto);

    [Headers("Authorization: Bearer")]
    [Post("/api/auth/change-password")]    
    Task<ResultDto> ChangePasswordAsync(ChangePasswordDto dto);
}
