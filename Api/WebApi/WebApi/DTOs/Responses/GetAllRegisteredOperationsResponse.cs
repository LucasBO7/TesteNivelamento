namespace WebApi.DTOs.Responses;

public record GetAllRegisteredOperationsResponse
(
    string? Registro_ANS,
    string? CNPJ,
    string? Razao_Social,
    string? Nome_Fantasia,
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
    string Endereco_eletronico,
    string Representante,
    string Cargo_Representante,
    int? Regiao_de_Comercializacao,
    DateTime? Data_Registro_ANS
);