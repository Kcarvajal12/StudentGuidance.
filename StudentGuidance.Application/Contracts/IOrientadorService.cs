using StudentGuidance.Application.Core;
using StudentGuidance.Application.Dtos.Orientador;

namespace StudentGuidance.Application.Contracts;

public interface IOrientadorService
{
    Task<ServiceResult<List<OrientadorDto>>> GetAllAsync();
    Task<ServiceResult<OrientadorDto>> GetByIdAsync(int id);
    Task<ServiceResult<OrientadorDto>> CreateAsync(OrientadorCreateDto dto);
    Task<ServiceResult<string>> UpdateAsync(int id, OrientadorUpdateDto dto);
    Task<ServiceResult<string>> DeleteAsync(int id);
}