using StudentGuidance.Application.Contracts;
using StudentGuidance.Application.Core;
using StudentGuidance.Application.Dtos.Estudiante;
using StudentGuidance.Domain.Entities;
using StudentGuidance.Infrastructure.Interfaces;

namespace StudentGuidance.Application.Services;

public class EstudianteService : IEstudianteService
{
    private readonly IEstudianteRepository _repository;

    public EstudianteService(IEstudianteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResult<List<EstudianteDto>>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();

        var result = data.Select(e => new EstudianteDto
        {
            Id = e.Id,
            NombreCompleto = $"{e.Nombre} {e.Apellido}",
            Correo = e.Correo,
            Matricula = e.Matricula,
            Carrera = e.Carrera,
            Semestre = e.Semestre
        }).ToList();

        return ServiceResult<List<EstudianteDto>>.Ok(result);
    }

    public async Task<ServiceResult<EstudianteDto>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity is null)
            return ServiceResult<EstudianteDto>.Fail("Estudiante no encontrado.");

        var dto = new EstudianteDto
        {
            Id = entity.Id,
            NombreCompleto = $"{entity.Nombre} {entity.Apellido}",
            Correo = entity.Correo,
            Matricula = entity.Matricula,
            Carrera = entity.Carrera,
            Semestre = entity.Semestre
        };

        return ServiceResult<EstudianteDto>.Ok(dto);
    }

    public async Task<ServiceResult<EstudianteDto>> CreateAsync(EstudianteCreateDto dto)
    {
        var exists = await _repository.GetByMatriculaAsync(dto.Matricula);
        if (exists is not null)
            return ServiceResult<EstudianteDto>.Fail("Ya existe un estudiante con esa matrícula.");

        var entity = new Estudiante(dto.Nombre, dto.Apellido, dto.Correo, dto.Telefono,
            dto.Matricula, dto.Carrera, dto.Semestre);

        await _repository.AddAsync(entity);

        return ServiceResult<EstudianteDto>.Ok(new EstudianteDto
        {
            Id = entity.Id,
            NombreCompleto = $"{entity.Nombre} {entity.Apellido}",
            Correo = entity.Correo,
            Matricula = entity.Matricula,
            Carrera = entity.Carrera,
            Semestre = entity.Semestre
        }, "Estudiante creado correctamente.");
    }

    public async Task<ServiceResult<string>> UpdateAsync(int id, EstudianteUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<string>.Fail("Estudiante no encontrado.");

        entity.Nombre = dto.Nombre;
        entity.Apellido = dto.Apellido;
        entity.Correo = dto.Correo;
        entity.Telefono = dto.Telefono;
        entity.Matricula = dto.Matricula;
        entity.Carrera = dto.Carrera;
        entity.Semestre = dto.Semestre;

        await _repository.UpdateAsync(entity);

        return ServiceResult<string>.Ok("OK", "Estudiante actualizado correctamente.");
    }

    public async Task<ServiceResult<string>> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<string>.Fail("Estudiante no encontrado.");

        await _repository.DeleteAsync(entity);
        return ServiceResult<string>.Ok("OK", "Estudiante eliminado correctamente.");
    }
}