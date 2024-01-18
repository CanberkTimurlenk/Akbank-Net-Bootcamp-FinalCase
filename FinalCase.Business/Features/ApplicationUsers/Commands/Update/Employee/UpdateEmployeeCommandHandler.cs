﻿using AutoMapper;
using FinalCase.Base.Helpers.Encryption;
using FinalCase.Base.Response;
using FinalCase.Business.Features.ApplicationUsers.Constants;
using FinalCase.Data.Contexts;
using FinalCase.Data.Entities;
using MediatR;

namespace FinalCase.Business.Features.ApplicationUsers.Commands.Create.Admin;

public class UpdateEmployeeCommandHandler(FinalCaseDbContext dbContext)
    : IRequestHandler<UpdateEmployeeCommand, ApiResponse>
{
    private readonly FinalCaseDbContext dbContext = dbContext;

    public async Task<ApiResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        // To adhere to the Single Responsibility Principle
        // UpdateAdmin and UpdateEmployee was created as two distinct classes.        

        var employee = await dbContext.FindAsync<ApplicationUser>(request.Id, cancellationToken);

        if (employee is null)
            return new ApiResponse(ApplicationUserMessages.UserNotFound);

        employee.Username = request.Model.Username;
        employee.Firstname = request.Model.Firstname;
        employee.Lastname = request.Model.Lastname;
        employee.Email = request.Model.Email;

        employee.Password = Md5Extension.Create(request.Model.Password);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}