using StudentGuidance.Application.Contracts;
using StudentGuidance.Application.Core;
using StudentGuidance.Application.Dtos.Orientador;
using StudentGuidance.Domain.Entities;
using StudentGuidance.Infrastructure.Interfaces;

namespace StudentGuidance.Application.Services;

public class OrientadorService : IOrientadorService
{
    private readonly IOrientadorRepository _repository;

    public OrientadorService(IOrientadorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResult<List<OrientadorDto>>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();

        var result = data.Select(o => new OrientadorDto
        {
            Id = o.Id,
            NombreCompleto = $"{o.Nombre} {o.Apellido}",
            Correo = o.Correo,
            CodigoEmpleado = o.CodigoEmpleado,
            Especialidad = o.Especialidad
        }).ToList();

        return ServiceResult<List<OrientadorDto>>.Ok(result);
    }

    public async Task<ServiceResult<OrientadorDto>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity is null)
            return ServiceResult<OrientadorDto>.Fail("Orientador no encontrado.");

        var dto = new OrientadorDto
        {
            Id = entity.Id,
            NombreCompleto = $"{entity.Nombre} {entity.Apellido}",
            Correo = entity.Correo,
            CodigoEmpleado = entity.CodigoEmpleado,
            Especialidad = entity.Especialidad
        };

        return ServiceResult<OrientadorDto>.Ok(dto);
    }

    public async Task<ServiceResult<OrientadorDto>> CreateAsync(OrientadorCreateDto dto)
    {
        var exists = await _repository.GetByCodigoEmpleadoAsync(dto.CodigoEmpleado);
        if (exists is not null)
            return ServiceResult<OrientadorDto>.Fail("Ya existe un orientador con ese código.");

        var entity = new Orientador(dto.Nombre, dto.Apellido, dto.Correo, dto.Telefono,
            dto.CodigoEmpleado, dto.Especialidad);

        await _repository.AddAsync(entity);

        return ServiceResult<OrientadorDto>.Ok(new OrientadorDto
        {
            Id = entity.Id,
            NombreCompleto = $"{entity.Nombre} {entity.Apellido}",
            Correo = entity.Correo,
            CodigoEmpleado = entity.CodigoEmpleado,
            Especialidad = entity.Especialidad
        }, "Orientador creado correctamente.");
    }

    public async Task<ServiceResult<string>> UpdateAsync(int id, OrientadorUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<string>.Fail("Orientador no encontrado.");

        entity.Nombre = dto.Nombre;
        entity.Apellido = dto.Apellido;
        entity.Correo = dto.Correo;
        entity.Telefono = dto.Telefono;
        entity.CodigoEmpleado = dto.CodigoEmpleado;
        entity.Especialidad = dto.Especialidad;

        await _repository.UpdateAsync(entity);

        return ServiceResult<string>.Ok("OK", "Orientador actualizado correctamente.");
    }

    public async Task<ServiceResult<string>> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<string>.Fail("Orientador no encontrado.");

        await _repository.DeleteAsync(entity);
        return ServiceResult<string>.Ok("OK", "Orientador eliminado correctamente.");
    }
}
