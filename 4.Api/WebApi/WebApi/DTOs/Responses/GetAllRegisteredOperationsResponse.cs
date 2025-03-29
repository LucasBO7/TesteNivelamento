namespace WebApi.DTOs.Responses;

public record GetAllRegisteredOperationsResponse
(
    string? RegistroANS,
    string? CNPJ,
    string? RazaoSocial,
    string? NomeFantasia,
    string Modalidade,
    string Logradouro,
    string Numero,
    string? Complemento,
    string Bairro,
    string Cidade,
    string UF,
    string CEP,
    string DDD,
    string Telefone,
    string? Fax,
    string EnderecoEletronico,
    string Representante,
    string CargoRepresentante,
    int? RegiaoComercializacao,
    DateTime? DataRegistroANS
);