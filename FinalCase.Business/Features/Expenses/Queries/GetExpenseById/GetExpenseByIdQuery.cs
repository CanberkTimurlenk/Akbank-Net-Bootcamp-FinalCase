﻿using FinalCase.Base.Response;
using FinalCase.Schema.Entity.Responses;
using MediatR;

namespace FinalCase.Business.Features.Expenses.Queries.GetAllExpenses;

public record GetExpenseByIdQuery(int UserId, string Role, int Id) : IRequest<ApiResponse<ExpenseResponse>>;