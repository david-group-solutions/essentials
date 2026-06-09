using DavidGroup.Core.DataIO.Services;
using DavidGroup.Core.Essentials.CompleteSample.Dtos.Product;
using DavidGroup.Core.Essentials.CompleteSample.Entities;
using DavidGroup.Core.Essentials.CompleteSample.Models.Product;
using DavidGroup.Core.Essentials.CompleteSample.StronglyTypedIds;

namespace DavidGroup.Core.Essentials.CompleteSample.Services;

public interface IProductsService :
    IBaseService<Product, ProductId, ProductCreateModel, ProductUpdateModel, ProductReadDto>;