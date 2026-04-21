using StudentGuidance.Domain.Entities;
using StudentGuidance.Infrastructure.Core;

namespace StudentGuidance.Infrastructure.Interfaces;

public interface ISeguimientoRepository : IBaseRepository<Seguimiento>
{
    Task<List<Seguimiento>> GetByCitaIdAsync(int citaId);
}