using DavidGroup.Core.Auth.StronglyTypedIds;
using DavidGroup.Core.Essentials.CompleteSample.Dtos.Manufacturer;
using DavidGroup.Core.Essentials.CompleteSample.StronglyTypedIds;

namespace DavidGroup.Core.Essentials.CompleteSample.Dtos.Product;

public record ProductReadDto(
    ProductId Id,
    string Name,
    decimal Price,
    int StockCount,
    ManufacturerReadDto Manufacturer,
    IdentityId CreatedByUserId,
    IdentityId? ModifiedByUserId,
    DateTime CreatedAtUtc,
    DateTime ModifiedAtUtc
);