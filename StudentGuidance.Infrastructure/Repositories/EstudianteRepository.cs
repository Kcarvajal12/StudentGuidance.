using Microsoft.EntityFrameworkCore;
using StudentGuidance.Domain.Entities;
using StudentGuidance.Infrastructure.Context;
using StudentGuidance.Infrastructure.Core;
using StudentGuidance.Infrastructure.Interfaces;

namespace StudentGuidance.Infrastructure.Repositories;

public class EstudianteRepository : BaseRepository<Estudiante>, IEstudianteRepository
{
    public EstudianteRepository(StudentGuidanceContext context) : base(context)
    {
    }

    public async Task<Estudiante?> GetByMatriculaAsync(string matricula)
    {
        return await _context.Estudiantes.FirstOrDefaultAsync(e => e.Matricula == matricula);
    }
}
