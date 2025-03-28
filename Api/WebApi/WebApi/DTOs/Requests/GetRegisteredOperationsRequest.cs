namespace WebApi.DTOs.Requests;

public class GetRegisteredOperationsRequest
{
    public required IFormFile File { get; set; }
    public string? SearchText { get; set; }
}