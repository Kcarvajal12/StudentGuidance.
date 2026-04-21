using Microsoft.EntityFrameworkCore;
using StudentGuidance.Domain.Entities;
using StudentGuidance.Infrastructure.Context;
using StudentGuidance.Infrastructure.Core;
using StudentGuidance.Infrastructure.Interfaces;

namespace StudentGuidance.Infrastructure.Repositories;

public class CitaRepository : BaseRepository<Cita>, ICitaRepository
{
    public CitaRepository(StudentGuidanceContext context) : base(context)
    {
    }

    public override async Task<List<Cita>> GetAllAsync()
    {
        return await _context.Citas
            .Include(c => c.Estudiante)
            .Include(c => c.Orientador)
            .ToListAsync();
    }

    public override async Task<Cita?> GetByIdAsync(int id)
    {
        return await _context.Citas
            .Include(c => c.Estudiante)
            .Include(c => c.Orientador)
            .Include(c => c.Seguimientos)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Cita>> GetByEstudianteIdAsync(int estudianteId)
    {
        return await _context.Citas
            .Include(c => c.Estudiante)
            .Include(c => c.Orientador)
            .Where(c => c.EstudianteId == estudianteId)
            .ToListAsync();
    }

    public async Task<List<Cita>> GetByOrientadorIdAsync(int orientadorId)
    {
        return await _context.Citas
            .Include(c => c.Estudiante)
            .Include(c => c.Orientador)
            .Where(c => c.OrientadorId == orientadorId)
            .ToListAsync();
    }
}
