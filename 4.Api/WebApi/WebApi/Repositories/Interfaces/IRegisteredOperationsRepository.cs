using WebApi.DTOs.Requests;
using WebApi.DTOs.Responses;
using WebApi.Entities;

namespace WebApi.Repositories.Interfaces;

public interface IRegisteredOperationsRepository
{
    List<GetAllRegisteredOperationsResponse> GetAllRegisteredOperations(GetRegisteredOperationsRequest request);
}