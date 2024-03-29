﻿using FinalCase.Base.Response;
using FinalCase.Data.Enums;
using FinalCase.Schema.Entity.Responses;
using MediatR;

namespace FinalCase.Business.Features.Expenses.Queries.GetExpenseByParameter;
public record GetExpensesByParameterQuery // for creator employee id, there is jwt token restriction. The employee could only retrieve his/her own expenses
    (GetExpensesQueryParameters Parameters) : IRequest<ApiResponse<IEnumerable<ExpenseResponse>>>;

public record GetExpensesQueryParameters
{
    public int? EmployeeId { get; set; }
    public int? CategoryId { get; set; }
    public int? PaymentMethodId { get; set; }
    public int? MinAmount { get; set; }
    public int? MaxAmount { get; set; }
    public DateTime? InitialDate { get; set; }
    public DateTime? FinalDate { get; set; }
    public string? Location { get; set; }
    public ExpenseStatus Status { get; set; }
}