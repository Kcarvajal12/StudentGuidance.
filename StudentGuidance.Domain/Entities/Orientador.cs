using StudentGuidance.Domain.Core;

namespace StudentGuidance.Domain.Entities;

public class Orientador : Persona
{
    public string CodigoEmpleado { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;

    public virtual ICollection<Cita> Citas { get; set; } = new List<Cita>();

    public Orientador()
    {
    }

    public Orientador(string nombre, string apellido, string correo, string telefono,
        string codigoEmpleado, string especialidad)
        : base(nombre, apellido, correo, telefono)
    {
        CodigoEmpleado = codigoEmpleado;
        Especialidad = especialidad;
    }

    public override string ObtenerDescripcion()
    {
        return $"Orientador: {Nombre} {Apellido} - Especialidad: {Especialidad}";
    }
}