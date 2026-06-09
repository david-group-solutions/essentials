using DavidGroup.Core.DataIO.Repositories;
using DavidGroup.Core.Essentials.CompleteSample.Database;
using DavidGroup.Core.Essentials.CompleteSample.Entities;
using DavidGroup.Core.Essentials.CompleteSample.StronglyTypedIds;

namespace DavidGroup.Core.Essentials.CompleteSample.Repositories;

public class ProductsRepository(ApplicationDbContext context)
    : BaseRepository<Product, ProductId>(context),
        IProductsRepository;