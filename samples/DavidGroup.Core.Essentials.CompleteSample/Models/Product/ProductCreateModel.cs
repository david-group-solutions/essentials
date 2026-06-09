using DavidGroup.Core.Auth.StronglyTypedIds;
using DavidGroup.Core.Essentials.CompleteSample.StronglyTypedIds;

namespace DavidGroup.Core.Essentials.CompleteSample.Models.Product;

public record ProductCreateModel(
    string Name,
    decimal Price,
    int StockCount,
    ManufacturerId ManufacturerId,
    IdentityId UserId
);