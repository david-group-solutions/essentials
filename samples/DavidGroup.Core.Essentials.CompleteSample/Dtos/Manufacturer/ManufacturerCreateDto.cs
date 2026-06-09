using System.ComponentModel.DataAnnotations;

namespace DavidGroup.Core.Essentials.CompleteSample.Dtos.Manufacturer;

public record ManufacturerCreateDto
{
    [Length(1, 100)]
    public required string Name { get; init; }
    
    public required DateTime IncorporationDateUtc { get; init; }
}