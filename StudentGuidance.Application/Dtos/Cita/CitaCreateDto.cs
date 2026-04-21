namespace StudentGuidance.Application.Dtos.Cita;

public class CitaCreateDto
{
    public int EstudianteId { get; set; }
    public int OrientadorId { get; set; }
    public DateTime FechaCita { get; set; }
    public string Motivo { get; set; } = string.Empty;
}