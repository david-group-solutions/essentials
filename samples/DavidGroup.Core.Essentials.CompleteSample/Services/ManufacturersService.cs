using System.Linq.Expressions;
using DavidGroup.Core.DataIO.Services;
using DavidGroup.Core.DataIO.UnitOfWork.EfCore;
using DavidGroup.Core.Essentials.CompleteSample.Database;
using DavidGroup.Core.Essentials.CompleteSample.Dtos.Manufacturer;
using DavidGroup.Core.Essentials.CompleteSample.Entities;
using DavidGroup.Core.Essentials.CompleteSample.Mappers;
using DavidGroup.Core.Essentials.CompleteSample.Repositories;
using DavidGroup.Core.Essentials.CompleteSample.StronglyTypedIds;

namespace DavidGroup.Core.Essentials.CompleteSample.Services;

public class ManufacturersService(IManufacturersRepository repository, IEfUnitOfWork<ApplicationDbContext> unitOfWork)
    : BaseService<ApplicationDbContext, IManufacturersRepository, Manufacturer, ManufacturerId, ManufacturerCreateDto,
            ManufacturerUpdateDto, ManufacturerReadDto>(repository, unitOfWork),
        IManufacturersService
{
    protected override Expression<Func<Manufacturer, ManufacturerReadDto>> ToReadDto => e => e.ToReadDto();
}