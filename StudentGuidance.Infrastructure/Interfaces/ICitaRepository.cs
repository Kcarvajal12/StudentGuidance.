using StudentGuidance.Domain.Entities;
using StudentGuidance.Infrastructure.Core;

namespace StudentGuidance.Infrastructure.Interfaces;

public interface ICitaRepository : IBaseRepository<Cita>
{
    Task<List<Cita>> GetByEstudianteIdAsync(int estudianteId);
    Task<List<Cita>> GetByOrientadorIdAsync(int orientadorId);
}