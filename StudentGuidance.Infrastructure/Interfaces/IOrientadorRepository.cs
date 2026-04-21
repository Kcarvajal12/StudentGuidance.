using StudentGuidance.Domain.Entities;
using StudentGuidance.Infrastructure.Core;

namespace StudentGuidance.Infrastructure.Interfaces;

public interface IOrientadorRepository : IBaseRepository<Orientador>
{
    Task<Orientador?> GetByCodigoEmpleadoAsync(string codigoEmpleado);
}