using StudentGuidance.Application.Dtos.Common;

namespace StudentGuidance.Application.Dtos.Cita;

public class CitaDto : DtoBase
{
    public string Estudiante { get; set; } = string.Empty;
    public string Orientador { get; set; } = string.Empty;
    public DateTime FechaCita { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}