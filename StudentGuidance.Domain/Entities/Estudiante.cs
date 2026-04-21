using StudentGuidance.Domain.Core;

namespace StudentGuidance.Domain.Entities;

public class Estudiante : Persona
{
    public string Matricula { get; set; } = string.Empty;
    public string Carrera { get; set; } = string.Empty;
    public int Semestre { get; set; }

    public virtual ICollection<Cita> Citas { get; set; } = new List<Cita>();

    public Estudiante()
    {
    }

    public Estudiante(string nombre, string apellido, string correo, string telefono,
        string matricula, string carrera, int semestre)
        : base(nombre, apellido, correo, telefono)
    {
        Matricula = matricula;
        Carrera = carrera;
        Semestre = semestre;
    }

    public override string ObtenerDescripcion()
    {
        return $"Estudiante: {Nombre} {Apellido} - Matrícula: {Matricula}";
    }
}