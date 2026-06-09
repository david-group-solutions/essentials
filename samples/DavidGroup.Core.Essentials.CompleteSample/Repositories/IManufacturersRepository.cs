using DavidGroup.Core.DataIO.Repositories;
using DavidGroup.Core.Essentials.CompleteSample.Entities;
using DavidGroup.Core.Essentials.CompleteSample.StronglyTypedIds;

namespace DavidGroup.Core.Essentials.CompleteSample.Repositories;

public interface IManufacturersRepository :
    IBaseRepository<Manufacturer, ManufacturerId>,
    IBaseAggregationRepository<Manufacturer>;
