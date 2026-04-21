using StudentGuidance.Application.Contracts;
using StudentGuidance.Application.Core;
using StudentGuidance.Application.Dtos.Cita;
using StudentGuidance.Domain.Entities;
using StudentGuidance.Infrastructure.Interfaces;

namespace StudentGuidance.Application.Services;

public class CitaService : ICitaService
{
    private readonly ICitaRepository _repository;
    private readonly IEstudianteRepository _estudianteRepository;
    private readonly IOrientadorRepository _orientadorRepository;

    public CitaService(
        ICitaRepository repository,
        IEstudianteRepository estudianteRepository,
        IOrientadorRepository orientadorRepository)
    {
        _repository = repository;
        _estudianteRepository = estudianteRepository;
        _orientadorRepository = orientadorRepository;
    }

    public async Task<ServiceResult<List<CitaDto>>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();
        return ServiceResult<List<CitaDto>>.Ok(data.Select(Map).ToList());
    }

    public async Task<ServiceResult<CitaDto>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<CitaDto>.Fail("Cita no encontrada.");

        return ServiceResult<CitaDto>.Ok(Map(entity));
    }

    public async Task<ServiceResult<CitaDto>> CreateAsync(CitaCreateDto dto)
    {
        var estudiante = await _estudianteRepository.GetByIdAsync(dto.EstudianteId);
        if (estudiante is null)
            return ServiceResult<CitaDto>.Fail("El estudiante no existe.");

        var orientador = await _orientadorRepository.GetByIdAsync(dto.OrientadorId);
        if (orientador is null)
            return ServiceResult<CitaDto>.Fail("El orientador no existe.");

        var entity = new Cita(dto.EstudianteId, dto.OrientadorId, dto.FechaCita, dto.Motivo);

        await _repository.AddAsync(entity);

        var created = await _repository.GetByIdAsync(entity.Id);
        return ServiceResult<CitaDto>.Ok(Map(created!), "Cita creada correctamente.");
    }

    public async Task<ServiceResult<string>> UpdateAsync(int id, CitaUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<string>.Fail("Cita no encontrada.");

        entity.FechaCita = dto.FechaCita;
        entity.Motivo = dto.Motivo;
        entity.Estado = dto.Estado;

        await _repository.UpdateAsync(entity);

        return ServiceResult<string>.Ok("OK", "Cita actualizada correctamente.");
    }

    public async Task<ServiceResult<string>> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<string>.Fail("Cita no encontrada.");

        await _repository.DeleteAsync(entity);
        return ServiceResult<string>.Ok("OK", "Cita eliminada correctamente.");
    }

    public async Task<ServiceResult<List<CitaDto>>> GetByEstudianteIdAsync(int estudianteId)
    {
        var data = await _repository.GetByEstudianteIdAsync(estudianteId);
        return ServiceResult<List<CitaDto>>.Ok(data.Select(Map).ToList());
    }

    public async Task<ServiceResult<List<CitaDto>>> GetByOrientadorIdAsync(int orientadorId)
    {
        var data = await _repository.GetByOrientadorIdAsync(orientadorId);
        return ServiceResult<List<CitaDto>>.Ok(data.Select(Map).ToList());
    }

    private static CitaDto Map(Cita c)
    {
        return new CitaDto
        {
            Id = c.Id,
            Estudiante = c.Estudiante is null ? "" : $"{c.Estudiante.Nombre} {c.Estudiante.Apellido}",
            Orientador = c.Orientador is null ? "" : $"{c.Orientador.Nombre} {c.Orientador.Apellido}",
            FechaCita = c.FechaCita,
            Motivo = c.Motivo,
            Estado = c.Estado.ToString()
        };
    }
}