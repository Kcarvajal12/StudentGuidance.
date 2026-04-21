using Microsoft.AspNetCore.Mvc;
using StudentGuidance.Application.Contracts;
using StudentGuidance.Application.Dtos.Cita;
using System.Runtime.InteropServices;

namespace StudentGuidance.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitasController : ControllerBase
{
    private readonly ICitaService _service;

    public CitasController(ICitaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpGet("estudiante/{estudianteId:int}")]
    public async Task<IActionResult> GetByEstudiante(int estudianteId)
    {
        var result = await _service.GetByEstudianteIdAsync(estudianteId);
        return Ok(result);
    }

    [HttpGet("orientador/{orientadorId:int}")]
    public async Task<IActionResult> GetByOrientador(int orientadorId)
    {
        var result = await _service.GetByOrientadorIdAsync(orientadorId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CitaCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] CitaUpdateDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }
}