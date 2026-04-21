using Microsoft.EntityFrameworkCore;
using StudentGuidance.Domain.Entities;
using StudentGuidance.Infrastructure.Context;
using StudentGuidance.Infrastructure.Core;
using StudentGuidance.Infrastructure.Interfaces;

namespace StudentGuidance.Infrastructure.Repositories;

public class OrientadorRepository : BaseRepository<Orientador>, IOrientadorRepository
{
    public OrientadorRepository(StudentGuidanceContext context) : base(context)
    {
    }

    public async Task<Orientador?> GetByCodigoEmpleadoAsync(string codigoEmpleado)
    {
        return await _context.Orientadores.FirstOrDefaultAsync(o => o.CodigoEmpleado == codigoEmpleado);
    }
}