namespace StudentGuidance.Application.Dtos.Estudiante;

public class EstudianteCreateDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public string Carrera { get; set; } = string.Empty;
    public int Semestre { get; set; }
}