namespace StudentGuidance.Application.Dtos.Seguimiento;

public class SeguimientoUpdateDto
{
    public string Observaciones { get; set; } = string.Empty;
    public string Recomendaciones { get; set; } = string.Empty;
    public DateTime FechaSeguimiento { get; set; }
    public DateTime? FechaRecordatorio { get; set; }
}