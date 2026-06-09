using System.ComponentModel.DataAnnotations;
using DavidGroup.Core.Essentials.CompleteSample.StronglyTypedIds;

namespace DavidGroup.Core.Essentials.CompleteSample.Dtos.Product;

public record ProductCreateDto
{
    [Length(1, 100)]
    public required string Name { get; init; }

    [Range(0, double.MaxValue)]
    public required decimal Price { get; init; }

    [Range(0, int.MaxValue)]
    public required int StockCount { get; init; }

    public required ManufacturerId ManufacturerId { get; init; }
}