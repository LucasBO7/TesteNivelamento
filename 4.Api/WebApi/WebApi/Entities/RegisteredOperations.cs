namespace WebApi.Entities;

public class RegisteredOperations
{
    public string? Registro_ANS { get; set; }
    public string? CNPJ { get; set; }
    public string? Razao_Social { get; set; }
    public string? Nome_Fantasia { get; set; }
    public string Modalidade { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string? Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string UF { get; set; }
    public string CEP { get; set; }
    public string DDD { get; set; }
    public string Telefone { get; set; }
    public string? Fax { get; set; }
    public string Endereco_eletronico { get; set; }
    public string Representante { get; set; }
    public string Cargo_Representante { get; set; }
    public string? Regiao_de_Comercializacao { get; set; }
    public string? Data_Registro_ANS { get; set; }
};

//namespace WebApi.Entities;

//public record RegisteredOperations
//(
//    string? Registro_ANS,
//    string? CNPJ,
//    string? Razao_Social,
//    string? Nome_Fantasia,
//    string Modalidade,
//    string Logradouro,
//    string Numero,
//    string? Complemento,
//    string Bairro,
//    string Cidade,
//    string UF,
//    string CEP,
//    string DDD,
//    string Telefone,
//    string? Fax,
//    string Endereco_eletronico,
//    string Representante,
//    string Cargo_Representante,
//    string? Regiao_de_Comercializacao,
//    string? Data_Registro_ANS
//);