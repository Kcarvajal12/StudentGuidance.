using StudentGuidance.Domain.Core;

namespace StudentGuidance.Domain.Entities;

public class Seguimiento : BaseEntity
{
    public int CitaId { get; set; }
    public virtual Cita? Cita { get; set; }

    public string Observaciones { get; set; } = string.Empty;
    public string Recomendaciones { get; set; } = string.Empty;
    public DateTime FechaSeguimiento { get; set; } = DateTime.Now;
    public DateTime? FechaRecordatorio { get; set; }

    public Seguimiento()
    {
    }

    public Seguimiento(int citaId, string observaciones, string recomendaciones, DateTime fechaSeguimiento)
    {
        CitaId = citaId;
        Observaciones = observaciones;
        Recomendaciones = recomendaciones;
        FechaSeguimiento = fechaSeguimiento;
    }
}