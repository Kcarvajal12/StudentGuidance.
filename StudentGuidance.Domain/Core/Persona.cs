namespace StudentGuidance.Domain.Core;

public abstract class Persona : BaseEntity
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;

    protected Persona()
    {
    }

    protected Persona(string nombre, string apellido, string correo, string telefono)
    {
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
        Telefono = telefono;
    }

    public abstract string ObtenerDescripcion();
}
