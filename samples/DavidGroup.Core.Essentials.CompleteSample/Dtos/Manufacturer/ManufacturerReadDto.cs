using DavidGroup.Core.Essentials.CompleteSample.StronglyTypedIds;

namespace DavidGroup.Core.Essentials.CompleteSample.Dtos.Manufacturer;

public record ManufacturerReadDto(
    ManufacturerId Id,
    string Name,
    DateTime IncorporationDateUtc
);