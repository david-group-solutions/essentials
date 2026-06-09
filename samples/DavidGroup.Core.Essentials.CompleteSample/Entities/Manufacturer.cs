using DavidGroup.Core.DataIO.Entities;
using DavidGroup.Core.Essentials.CompleteSample.Dtos.Manufacturer;
using DavidGroup.Core.Essentials.CompleteSample.StronglyTypedIds;
using MassTransit;

namespace DavidGroup.Core.Essentials.CompleteSample.Entities;

public sealed class Manufacturer : Entity<ManufacturerId>,
    ISelfManageable<Manufacturer, ManufacturerCreateDto, ManufacturerUpdateDto>
{
    public string Name { get; set; } = null!;
    public DateTime IncorporationDateUtc { get; init; }

    public static Manufacturer Create(ManufacturerCreateDto model)
    {
        return new Manufacturer
        {
            Id = new ManufacturerId(NewId.NextGuid()),
            Name = model.Name,
            IncorporationDateUtc = model.IncorporationDateUtc
        };
    }

    public void Update(ManufacturerUpdateDto model)
    {
        Name = model.Name;
    }
}