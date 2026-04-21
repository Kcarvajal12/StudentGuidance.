namespace StudentGuidance.Application.Dtos.Orientador;

public class OrientadorCreateDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string CodigoEmpleado { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;
}