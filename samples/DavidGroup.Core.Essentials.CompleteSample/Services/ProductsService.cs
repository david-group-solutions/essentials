using System.Linq.Expressions;
using DavidGroup.Core.DataIO;
using DavidGroup.Core.DataIO.Helpers;
using DavidGroup.Core.DataIO.Services;
using DavidGroup.Core.DataIO.UnitOfWork.EfCore;
using DavidGroup.Core.Essentials.CompleteSample.Database;
using DavidGroup.Core.Essentials.CompleteSample.Dtos.Product;
using DavidGroup.Core.Essentials.CompleteSample.Entities;
using DavidGroup.Core.Essentials.CompleteSample.Mappers;
using DavidGroup.Core.Essentials.CompleteSample.Models.Product;
using DavidGroup.Core.Essentials.CompleteSample.Repositories;
using DavidGroup.Core.Essentials.CompleteSample.StronglyTypedIds;
using DavidGroup.Core.Pagination.InfiniteScroll;
using DavidGroup.Core.Results;
using DavidGroup.Core.Results.Generic;
using Microsoft.EntityFrameworkCore;

namespace DavidGroup.Core.Essentials.CompleteSample.Services;

public class ProductsService(IProductsRepository repository, IEfUnitOfWork<ApplicationDbContext> unitOfWork)
    : BaseService<ApplicationDbContext, IProductsRepository, Product, ProductId, ProductCreateModel,
            ProductUpdateModel, ProductReadDto>(repository, unitOfWork),
        IProductsService
{
    protected override Expression<Func<Product, ProductReadDto>> ToReadDto => e => e.ToReadDto();

    public override async Task<OperationResult<InfinitePageData<ProductReadDto>>> GetAllAsync(
        InfinitePageOptions options,
        string? orderBy = null,
        IReadOnlyList<Expression<Func<Product, object>>>? allowedToOrderBy = null,
        CancellationToken cancellationToken = default)
    {
        InfinitePageData<ProductReadDto> result;

        if (orderBy is null)
        {
            result = await Repository.GetAllAsync(options,
                orderBy: [e => e.Id],
                isDescending: [true],
                selector: ToReadDto,
                include: i => i.Include(e => e.Manufacturer),
                cancellationToken: cancellationToken);
        }
        else
        {
            var validationResult = DynamicOrderingHelper.Validate(orderBy, allowedToOrderBy);
            if (!validationResult.Succeeded)
                return OperationResult<InfinitePageData<ProductReadDto>>.Failure(validationResult.Messages[0]);

            result = await Repository.GetAllAsync(options,
                orderByString: orderBy,
                selector: ToReadDto,
                include: i => i.Include(e => e.Manufacturer),
                cancellationToken: cancellationToken);
        }

        return OperationResult<InfinitePageData<ProductReadDto>>.Success(result);
    }

    public override async Task<OperationResult<ProductReadDto>> GetByIdAsync(ProductId id,
        CancellationToken cancellationToken = default)
    {
        var entity = await Repository.FirstOrDefaultAsync(
            selector: e => e,
            predicate: e => e.Id == id,
            include: i => i.Include(e => e.Manufacturer),
            cancellationToken: cancellationToken
        );

        if (entity is null)
        {
            return OperationResult<ProductReadDto>.Failure(
                new OperationResultMessage(ErrorMessages.NotFound, OperationResultSeverity.Error));
        }

        var readDto = CacheHelper.CompileToReadDtoExpression(ToReadDto).Invoke(entity);

        return OperationResult<ProductReadDto>.Success(readDto);
    }

    public override async Task<OperationResult<ProductReadDto>> CreateAsync(ProductCreateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = Product.Create(model);

        await Repository.CreateAsync(entity, cancellationToken);
        await UnitOfWork.SaveAsync(cancellationToken);

        await Repository.Context.Entry(entity).Reference(e => e.Manufacturer).LoadAsync(cancellationToken);

        var readDto = CacheHelper.CompileToReadDtoExpression(ToReadDto).Invoke(entity);

        return OperationResult<ProductReadDto>.Success(readDto);
    }

    public override async Task<OperationResult<ProductReadDto>> UpdateAsync(ProductId id,
        ProductUpdateModel model,
        CancellationToken cancellationToken = default)
    {
        var entity = await Repository.FirstOrDefaultAsync(
            selector: e => e,
            predicate: e => e.Id == id,
            include: i => i.Include(e => e.Manufacturer),
            cancellationToken: cancellationToken
        );

        if (entity is null)
        {
            return OperationResult<ProductReadDto>.Failure(
                new OperationResultMessage(ErrorMessages.NotFound, OperationResultSeverity.Error));
        }

        entity.Update(model);

        Repository.Update(entity);
        await UnitOfWork.SaveAsync(cancellationToken);

        var readDto = CacheHelper.CompileToReadDtoExpression(ToReadDto).Invoke(entity);

        return OperationResult<ProductReadDto>.Success(readDto);
    }
}