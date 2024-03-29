﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using FinalCase.Data.Enums;
using FinalCase.Schema.Reports;
using FinalCase.Base.Response;
using FinalCase.Data.Constants.Storage;
using FinalCase.Data.Constants.DbObjects;
using FinalCase.BackgroundJobs.MicroOrm.Dapper;
using System.Data.SqlClient;
using FinalCase.Data.Entities;

namespace FinalCase.Business.Features.Reports.Queries.Employee.GetEmployeeAllExpenseReportById;

public class GetEmployeeAllExpenseReportByIdQueryHandler(IConfiguration configuration) : IRequestHandler<GetEmployeeAllExpenseReportByIdQuery, ApiResponse<IEnumerable<EmployeeExpenseReport>>>
{
    private readonly IConfiguration configuration = configuration;

    public async Task<ApiResponse<IEnumerable<EmployeeExpenseReport>>> Handle(GetEmployeeAllExpenseReportByIdQuery request, CancellationToken cancellationToken)
    {
        var expenses = await GetEmployeeAllExpensesByUserId(request.Id, cancellationToken);

        return new ApiResponse<IEnumerable<EmployeeExpenseReport>>(expenses);
    }

    private async Task<IEnumerable<EmployeeExpenseReport>> GetEmployeeAllExpensesByUserId(int id, CancellationToken cancellationToken)
    {        
        var connStr = configuration.GetConnectionString(DbKeys.SqlServer);

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", id, DbType.Int32);

        return await DapperReportHelper.GetEmployeeExpenseReports(connStr, StoredProcedures.GetEmployeeAllExpenses, parameters, cancellationToken);

    }
}