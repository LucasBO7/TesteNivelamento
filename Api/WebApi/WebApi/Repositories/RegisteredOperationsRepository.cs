using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using WebApi.DTOs.Requests;
using WebApi.DTOs.Responses;
using WebApi.Entities;
using WebApi.Repositories.Interfaces;
using WebApi.Services;

namespace WebApi.Repositories;

public class RegisteredOperationsRepository : IRegisteredOperationsRepository
{
    private readonly RegisteredOperationsService _registeredOperationsService;
    public RegisteredOperationsRepository()
    {
        _registeredOperationsService = new();
    }

    public List<GetAllRegisteredOperationsResponse> GetAllRegisteredOperations(GetRegisteredOperationsRequest request)
    {

        List<RegisteredOperations> searchedRegisteredOperations = _registeredOperationsService.SearchDataFromCsv(request.File, request.SearchText).ToList();


        List<GetAllRegisteredOperationsResponse> response = searchedRegisteredOperations.Select(e => new GetAllRegisteredOperationsResponse
            (
                e.Registro_ANS,
                e.CNPJ,
                e.Razao_Social,
                e.Nome_Fantasia,
                e.Modalidade,
                e.Logradouro,
                e.Numero,
                e.Complemento,
                e.Bairro,
                e.Cidade,
                e.UF,
                e.CEP,
                e.DDD,
                e.Telefone,
                e.Fax,
                e.Endereco_eletronico,
                e.Representante,
                e.Cargo_Representante,
                String.IsNullOrWhiteSpace(e.Regiao_de_Comercializacao) ? 0 : int.Parse(e.Regiao_de_Comercializacao!),
                DateTime.Parse(e.Data_Registro_ANS!)
            )
        ).ToList();

        return response;
    }
}