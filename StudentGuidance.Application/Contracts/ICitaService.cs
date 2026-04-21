using StudentGuidance.Application.Core;
using StudentGuidance.Application.Dtos.Cita;

namespace StudentGuidance.Application.Contracts;

public interface ICitaService
{
    Task<ServiceResult<List<CitaDto>>> GetAllAsync();
    Task<ServiceResult<CitaDto>> GetByIdAsync(int id);
    Task<ServiceResult<CitaDto>> CreateAsync(CitaCreateDto dto);
    Task<ServiceResult<string>> UpdateAsync(int id, CitaUpdateDto dto);
    Task<ServiceResult<string>> DeleteAsync(int id);
    Task<ServiceResult<List<CitaDto>>> GetByEstudianteIdAsync(int estudianteId);
    Task<ServiceResult<List<CitaDto>>> GetByOrientadorIdAsync(int orientadorId);
}
