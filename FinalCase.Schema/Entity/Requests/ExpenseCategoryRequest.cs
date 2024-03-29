﻿namespace FinalCase.Schema.Entity.Requests;

public record ExpenseCategoryRequest
{
    public string Name { get; init; }
    public string Description { get; init; }
}
