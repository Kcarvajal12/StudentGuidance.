using StudentGuidance.Application.Dtos.Common;

namespace StudentGuidance.Application.Dtos.Estudiante;

public class EstudianteDto : DtoBase
{
    public string NombreCompleto { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public string Carrera { get; set; } = string.Empty;
    public int Semestre { get; set; }
}
