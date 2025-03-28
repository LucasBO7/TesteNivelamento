using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Requests;
using WebApi.Repositories.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisteredOperationsController : ControllerBase
{
    private readonly IRegisteredOperationsRepository _registeredOperationsRepository;

    public RegisteredOperationsController(IRegisteredOperationsRepository registeredOperationsRepository)
    {
        _registeredOperationsRepository = registeredOperationsRepository;
    }

    [HttpPost("SearchAll")]
    public IActionResult GetRegisteredOperations([FromForm] GetRegisteredOperationsRequest file)
    {
        try
        {
            var registeredOperations = _registeredOperationsRepository.GetAllRegisteredOperations(file);

            return Ok(registeredOperations);
        }
        catch (Exception ex)
        {
            return BadRequest("Houve um erro: " + ex.Message);
        }
    }
}