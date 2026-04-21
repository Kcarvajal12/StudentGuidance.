using Microsoft.AspNetCore.Mvc;
using StudentGuidance.Application.Contracts;
using StudentGuidance.Application.Dtos.Orientador;
using System.Runtime.InteropServices;

namespace StudentGuidance.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrientadoresController : ControllerBase
{
    private readonly IOrientadorService _service;

    public OrientadoresController(IOrientadorService service)
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

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OrientadorCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] OrientadorUpdateDto dto)
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