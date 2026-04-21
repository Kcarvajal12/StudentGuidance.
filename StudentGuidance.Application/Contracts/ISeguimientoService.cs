using StudentGuidance.Application.Core;
using StudentGuidance.Application.Dtos.Seguimiento;

namespace StudentGuidance.Application.Contracts;

public interface ISeguimientoService
{
    Task<ServiceResult<List<SeguimientoDto>>> GetAllAsync();
    Task<ServiceResult<SeguimientoDto>> GetByIdAsync(int id);
    Task<ServiceResult<SeguimientoDto>> CreateAsync(SeguimientoCreateDto dto);
    Task<ServiceResult<string>> UpdateAsync(int id, SeguimientoUpdateDto dto);
    Task<ServiceResult<string>> DeleteAsync(int id);
    Task<ServiceResult<List<SeguimientoDto>>> GetByCitaIdAsync(int citaId);
}