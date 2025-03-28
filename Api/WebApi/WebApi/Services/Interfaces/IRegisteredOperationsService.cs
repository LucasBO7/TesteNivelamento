using WebApi.Entities;

namespace WebApi.Services.Interfaces;

public interface IRegisteredOperationsService
{
    IEnumerable<RegisteredOperations> SearchDataFromCsv(IFormFile file, string textToSearch);
}