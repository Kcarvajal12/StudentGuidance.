using StudentGuidance.Application.Core;
using StudentGuidance.Application.Dtos.Estudiante;

namespace StudentGuidance.Application.Contracts;

public interface IEstudianteService
{
    Task<ServiceResult<List<EstudianteDto>>> GetAllAsync();
    Task<ServiceResult<EstudianteDto>> GetByIdAsync(int id);
    Task<ServiceResult<EstudianteDto>> CreateAsync(EstudianteCreateDto dto);
    Task<ServiceResult<string>> UpdateAsync(int id, EstudianteUpdateDto dto);
    Task<ServiceResult<string>> DeleteAsync(int id);
}
