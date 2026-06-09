using DavidGroup.Core.DataIO.Services;
using DavidGroup.Core.Essentials.CompleteSample.Dtos.Manufacturer;
using DavidGroup.Core.Essentials.CompleteSample.Entities;
using DavidGroup.Core.Essentials.CompleteSample.StronglyTypedIds;

namespace DavidGroup.Core.Essentials.CompleteSample.Services;

public interface IManufacturersService :
    IBaseService<Manufacturer, ManufacturerId, ManufacturerCreateDto, ManufacturerUpdateDto, ManufacturerReadDto>;