﻿namespace FinalCase.Schema.Responses;

public record ExpenseCategoryResponse
{
    public string Name { get; init; }
    public string Description { get; init; }
}