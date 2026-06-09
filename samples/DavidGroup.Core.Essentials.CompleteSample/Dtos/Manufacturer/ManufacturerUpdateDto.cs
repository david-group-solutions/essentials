using System.ComponentModel.DataAnnotations;

namespace DavidGroup.Core.Essentials.CompleteSample.Dtos.Manufacturer;

public record ManufacturerUpdateDto
{
    [Length(1, 100)]
    public required string Name { get; init; }
}