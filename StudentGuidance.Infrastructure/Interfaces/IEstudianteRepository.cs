using StudentGuidance.Domain.Entities;
using StudentGuidance.Infrastructure.Core;

namespace StudentGuidance.Infrastructure.Interfaces;

public interface IEstudianteRepository : IBaseRepository<Estudiante>
{
    Task<Estudiante?> GetByMatriculaAsync(string matricula);
}
