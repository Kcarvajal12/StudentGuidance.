using StudentGuidance.Application.Contracts;
using StudentGuidance.Application.Core;
using StudentGuidance.Application.Dtos.Seguimiento;
using StudentGuidance.Domain.Entities;
using StudentGuidance.Infrastructure.Interfaces;

namespace StudentGuidance.Application.Services;

public class SeguimientoService : ISeguimientoService
{
    private readonly ISeguimientoRepository _repository;
    private readonly ICitaRepository _citaRepository;

    public SeguimientoService(ISeguimientoRepository repository, ICitaRepository citaRepository)
    {
        _repository = repository;
        _citaRepository = citaRepository;
    }

    public async Task<ServiceResult<List<SeguimientoDto>>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();

        var result = data.Select(Map).ToList();
        return ServiceResult<List<SeguimientoDto>>.Ok(result);
    }

    public async Task<ServiceResult<SeguimientoDto>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<SeguimientoDto>.Fail("Seguimiento no encontrado.");

        return ServiceResult<SeguimientoDto>.Ok(Map(entity));
    }

    public async Task<ServiceResult<SeguimientoDto>> CreateAsync(SeguimientoCreateDto dto)
    {
        var cita = await _citaRepository.GetByIdAsync(dto.CitaId);
        if (cita is null)
            return ServiceResult<SeguimientoDto>.Fail("La cita no existe.");

        var entity = new Seguimiento(dto.CitaId, dto.Observaciones, dto.Recomendaciones, dto.FechaSeguimiento)
        {
            FechaRecordatorio = dto.FechaRecordatorio
        };

        await _repository.AddAsync(entity);

        return ServiceResult<SeguimientoDto>.Ok(Map(entity), "Seguimiento creado correctamente.");
    }

    public async Task<ServiceResult<string>> UpdateAsync(int id, SeguimientoUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<string>.Fail("Seguimiento no encontrado.");

        entity.Observaciones = dto.Observaciones;
        entity.Recomendaciones = dto.Recomendaciones;
        entity.FechaSeguimiento = dto.FechaSeguimiento;
        entity.FechaRecordatorio = dto.FechaRecordatorio;

        await _repository.UpdateAsync(entity);

        return ServiceResult<string>.Ok("OK", "Seguimiento actualizado correctamente.");
    }

    public async Task<ServiceResult<string>> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return ServiceResult<string>.Fail("Seguimiento no encontrado.");

        await _repository.DeleteAsync(entity);
        return ServiceResult<string>.Ok("OK", "Seguimiento eliminado correctamente.");
    }

    public async Task<ServiceResult<List<SeguimientoDto>>> GetByCitaIdAsync(int citaId)
    {
        var data = await _repository.GetByCitaIdAsync(citaId);
        return ServiceResult<List<SeguimientoDto>>.Ok(data.Select(Map).ToList());
    }

    private static SeguimientoDto Map(Seguimiento s)
    {
        return new SeguimientoDto
        {
            Id = s.Id,
            CitaId = s.CitaId,
            Observaciones = s.Observaciones,
            Recomendaciones = s.Recomendaciones,
            FechaSeguimiento = s.FechaSeguimiento,
            FechaRecordatorio = s.FechaRecordatorio
        };
    }
}