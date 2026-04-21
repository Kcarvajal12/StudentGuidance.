namespace StudentGuidance.Domain.Core;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public bool Activo { get; set; } = true;
}