using CsvHelper.Configuration;

namespace WebApi.Entities;

public class RegisteredOperationsMap : ClassMap<RegisteredOperations>
{
    public RegisteredOperationsMap()
    {
        Map(m => m.Registro_ANS).Name("Registro_ANS");
        Map(m => m.CNPJ).Name("CNPJ");
        Map(m => m.Razao_Social).Name("Razao_Social");
        Map(m => m.Nome_Fantasia).Name("Nome_Fantasia").Optional();
        Map(m => m.Modalidade).Name("Modalidade");
        Map(m => m.Logradouro).Name("Logradouro");
        Map(m => m.Numero).Name("Numero");
        Map(m => m.Complemento).Name("Complemento").Optional();
        Map(m => m.Bairro).Name("Bairro");
        Map(m => m.Cidade).Name("Cidade");
        Map(m => m.UF).Name("UF");
        Map(m => m.CEP).Name("CEP");
        Map(m => m.DDD).Name("DDD");
        Map(m => m.Telefone).Name("Telefone");
        Map(m => m.Fax).Name("Fax").Optional();
        Map(m => m.Endereco_eletronico).Name("Endereco_eletronico");
        Map(m => m.Representante).Name("Representante");
        Map(m => m.Cargo_Representante).Name("Cargo_Representante");
        Map(m => m.Regiao_de_Comercializacao).Name("Regiao_de_Comercializacao");
        Map(m => m.Data_Registro_ANS).Name("Data_Registro_ANS").TypeConverterOption.Format("yyyy-MM-dd");

    }
}