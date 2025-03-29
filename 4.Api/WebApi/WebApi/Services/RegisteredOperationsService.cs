using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using WebApi.Entities;
using System.Reflection;
using WebApi.Services.Interfaces;

namespace WebApi.Services;

public class RegisteredOperationsService : IRegisteredOperationsService
{
    private readonly string _csvFilePath;
    public RegisteredOperationsService(IConfiguration configuration)
    {
        _csvFilePath = configuration["CsvFilePath"] ?? "DataSource/Relatorio_cadop.csv";
    }

    public IEnumerable<RegisteredOperations> SearchDataFromCsv(string textToSearch)
    {
        List<RegisteredOperations> csvRegisteredOperations = ReadCsvFile(_csvFilePath);

        bool SearchInProperties(RegisteredOperations obj, string queryText)
        {
            var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    var value = property.GetValue(obj)?.ToString();
                    if (!String.IsNullOrEmpty(value) && value.Contains(queryText, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
            }

            return false;
        }

        IEnumerable<RegisteredOperations> searchedRegisteredOperations =
            String.IsNullOrEmpty(textToSearch)
            ? csvRegisteredOperations
            : csvRegisteredOperations.Where(e => SearchInProperties(e, textToSearch));

        return searchedRegisteredOperations;
    }

    private List<RegisteredOperations> ReadCsvFile(string file)
    {
        using var reader = new StreamReader(file);
        IReaderConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
        };

        using var csvReader = new CsvReader(reader, configuration);

        var records = csvReader.GetRecords<RegisteredOperations>().ToList();

        return records;
    }
}