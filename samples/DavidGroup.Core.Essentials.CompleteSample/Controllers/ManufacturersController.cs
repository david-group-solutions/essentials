using Asp.Versioning;
using DavidGroup.Core.Essentials.CompleteSample.Data;
using DavidGroup.Core.Essentials.CompleteSample.Dtos.Manufacturer;
using DavidGroup.Core.Essentials.CompleteSample.Services;
using DavidGroup.Core.Essentials.CompleteSample.StronglyTypedIds;
using DavidGroup.Core.Pagination.InfiniteScroll;
using DavidGroup.Core.Results.Generic;
using DavidGroup.Core.Swagger.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DavidGroup.Core.Essentials.CompleteSample.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
[SwaggerControllerOrder(1)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public class ManufacturersController(IManufacturersService manufacturersService) : ControllerBase
{
    [Authorize(Permissions.Manufacturers.Read)]
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType<OperationResult<InfinitePageData<ManufacturerReadDto>>>(StatusCodes.Status200OK)]
    [ProducesResponseType<OperationResult<InfinitePageData<ManufacturerReadDto>>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll([FromQuery] InfinitePageOptions options, [FromQuery] string? orderBy)
    {
        var result = await manufacturersService.GetAllAsync(options, orderBy,
            allowedToOrderBy:
            [
                e => e.Id,
                e => e.Name
            ]
        );

        return !result.Succeeded
            ? BadRequest(result)
            : Ok(result);
    }

    [Authorize(Permissions.Manufacturers.Read)]
    [HttpGet]
    [Route("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType<OperationResult<ManufacturerReadDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType<OperationResult<ManufacturerReadDto>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] ManufacturerId id)
    {
        var result = await manufacturersService.GetByIdAsync(id);

        return !result.Succeeded
            ? NotFound(result)
            : Ok(result);
    }

    [Authorize(Permissions.Manufacturers.Manage)]
    [HttpPost]
    [MapToApiVersion("1.0")]
    [ProducesResponseType<OperationResult<ManufacturerReadDto>>(StatusCodes.Status201Created)]
    [ProducesResponseType<OperationResult<ManufacturerReadDto>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] ManufacturerCreateDto dto)
    {
        var result = await manufacturersService.CreateAsync(dto);

        return !result.Succeeded
            ? BadRequest(result)
            : CreatedAtAction(nameof(GetById), new { result.Value.Id }, result);
    }

    [Authorize(Permissions.Manufacturers.Manage)]
    [HttpPut]
    [Route("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType<OperationResult<ManufacturerReadDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType<OperationResult<ManufacturerReadDto>>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute] ManufacturerId id, [FromBody] ManufacturerUpdateDto dto)
    {
        var result = await manufacturersService.UpdateAsync(id, dto);

        return !result.Succeeded
            ? BadRequest(result)
            : Ok(result);
    }

    [Authorize(Permissions.Manufacturers.Manage)]
    [HttpDelete]
    [Route("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType<OperationResult<ManufacturerReadDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType<OperationResult<ManufacturerReadDto>>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] ManufacturerId id)
    {
        var result = await manufacturersService.DeleteAsync(id);

        return !result.Succeeded
            ? NotFound(result)
            : Ok(result);
    }
}