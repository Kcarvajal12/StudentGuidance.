using Microsoft.EntityFrameworkCore;
using StudentGuidance.Domain.Entities;
using StudentGuidance.Infrastructure.Context;
using StudentGuidance.Infrastructure.Core;
using StudentGuidance.Infrastructure.Interfaces;

namespace StudentGuidance.Infrastructure.Repositories;

public class SeguimientoRepository : BaseRepository<Seguimiento>, ISeguimientoRepository
{
    public SeguimientoRepository(StudentGuidanceContext context) : base(context)
    {
    }

    public override async Task<List<Seguimiento>> GetAllAsync()
    {
        return await _context.Seguimientos
            .Include(s => s.Cita)
            .ToListAsync();
    }

    public async Task<List<Seguimiento>> GetByCitaIdAsync(int citaId)
    {
        return await _context.Seguimientos
            .Include(s => s.Cita)
            .Where(s => s.CitaId == citaId)
            .ToListAsync();
    }
}
