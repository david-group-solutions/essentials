using DavidGroup.Core.Auth.StronglyTypedIds;

namespace DavidGroup.Core.Essentials.CompleteSample.Models.Product;

public record ProductUpdateModel(
    string Name,
    decimal Price,
    int StockCount,
    IdentityId UserId
);