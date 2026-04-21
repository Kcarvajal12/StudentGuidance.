using StudentGuidance.Domain.Enum;

namespace StudentGuidance.Application.Dtos.Cita;

public class CitaUpdateDto
{
    public DateTime FechaCita { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public EstadoCita Estado { get; set; }
}
