using StudentGuidance.Application.Dtos.Common;

namespace StudentGuidance.Application.Dtos.Orientador;

public class OrientadorDto : DtoBase
{
    public string NombreCompleto { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string CodigoEmpleado { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;
}