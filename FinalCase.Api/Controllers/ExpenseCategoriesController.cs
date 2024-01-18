﻿using FinalCase.Base.Response;
using FinalCase.Business.Features.ExpenseCategories.Commands.Create;
using FinalCase.Business.Features.ExpenseCategories.Commands.Delete;
using FinalCase.Business.Features.ExpenseCategories.Commands.Update;
using FinalCase.Business.Features.ExpenseCategories.Queries.GetAll;
using FinalCase.Business.Features.ExpenseCategories.Queries.GetById;
using FinalCase.Schema.Entity.Requests;
using FinalCase.Schema.Entity.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalCase.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseCategoriesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpGet]
    public async Task<ApiResponse<IEnumerable<ExpenseCategoryResponse>>> GetExpenseCategories()
    {
        return await mediator.Send(new GetAllExpenseCategoriesQuery());
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<ExpenseCategoryResponse>> GetExpenseCategoryById(int id)
    {
        return await mediator.Send(new GetExpenseCategoryByIdQuery(id));
    }

    [HttpPost]
    public async Task<ApiResponse<ExpenseCategoryResponse>> CreateExpenseCategory(ExpenseCategoryRequest request)
    {
        return await mediator.Send(new CreateExpenseCategoryCommand(request));
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse> UpdateExpenseCategory(int id, ExpenseCategoryRequest request)
    {
        return await mediator.Send(new UpdateExpenseCategoryCommand(id, request));
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse> DeleteExpenseCategory(int id)
    {
        return await mediator.Send(new DeleteExpenseCategoryCommand(id));
    }
}
