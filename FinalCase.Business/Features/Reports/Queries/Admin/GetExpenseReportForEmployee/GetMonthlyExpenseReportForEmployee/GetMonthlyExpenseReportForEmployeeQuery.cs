﻿using FinalCase.Base.Response;
using FinalCase.Schema.Reports;
using MediatR;

namespace FinalCase.Business.Features.Reports.Queries.Admin.GetExpenseReportForEmployee.GetMonthlyExpenseReportForEmployee;
public record GetMonthlyExpenseReportForEmployeeQuery(int Id) : IRequest<ApiResponse<IEnumerable<EmployeeExpenseReport>>>;
