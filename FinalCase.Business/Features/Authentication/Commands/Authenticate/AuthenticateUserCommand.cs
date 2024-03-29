﻿using FinalCase.Base.Response;
using FinalCase.Schema.Authentication;
using MediatR;

namespace FinalCase.Business.Features.Authentication.Commands;

public record AuthenticateUserCommand(AuthenticationRequest Model) : IRequest<ApiResponse<AuthenticationResponse>>;