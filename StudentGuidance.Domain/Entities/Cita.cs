using StudentGuidance.Domain.Core;
using StudentGuidance.Domain.Enum;

namespace StudentGuidance.Domain.Entities;

public class Cita : BaseEntity
{
    public int EstudianteId { get; set; }
    public virtual Estudiante? Estudiante { get; set; }

    public int OrientadorId { get; set; }
    public virtual Orientador? Orientador { get; set; }

    public DateTime FechaCita { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public EstadoCita Estado { get; set; } = EstadoCita.Pendiente;

    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();

    public Cita()
    {
    }

    public Cita(int estudianteId, int orientadorId, DateTime fechaCita, string motivo)
    {
        EstudianteId = estudianteId;
        OrientadorId = orientadorId;
        FechaCita = fechaCita;
        Motivo = motivo;
        Estado = EstadoCita.Pendiente;
    }

    // Sobrecarga
    public Cita(int estudianteId, int orientadorId, DateTime fechaCita, string motivo, EstadoCita estado)
    {
        EstudianteId = estudianteId;
        OrientadorId = orientadorId;
        FechaCita = fechaCita;
        Motivo = motivo;
        Estado = estado;
    }
}