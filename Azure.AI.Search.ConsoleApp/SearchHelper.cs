using System.Globalization;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using CsvHelper;

namespace Azure.AI.Search.ConsoleApp;
/// <summary>
/// Helper class for search operations.
/// </summary>
public static class SearchHelper
{
    /// <summary>
    /// Create Azure AI Search Index
    /// </summary>
    public static async Task CreateIndex()
    {
        
    }


    /// <summary>
    /// Upload the Documents to the newly Created Index
    /// </summary>
    public static async Task UploadDocuments()
    {

        var records = ReadCsvFile("customer_support_tickets.csv");
        foreach (var record in records)
        {
            System.Console.WriteLine(record.TicketId);
            System.Console.WriteLine(record.CustomerName);
            System.Console.WriteLine(record.TicketDescription);
        }
        
    }

    /// <summary>
    /// Search the Documents from the Index
    /// </summary>
    public static async Task SearchDocuments(string endpoint, string key, string indexName)
    {
        System.Console.WriteLine(endpoint);
        System.Console.WriteLine(key);
        System.Console.WriteLine(indexName);
        SearchIndexClient searchIndexClient = new SearchIndexClient(new Uri(endpoint), 
                                                        new AzureKeyCredential(key));
        var index = searchIndexClient.GetIndex(indexName);
        var searchClient = searchIndexClient.GetSearchClient(indexName);

        var searchOptions = new SearchOptions
        {
            Select = {"TicketId","CustomerName","TicketDescription"},
            IncludeTotalCount = true,
            SearchMode = SearchMode.Any,
            Size =5
        };

        SearchResults<CustomerService> results = await searchClient.SearchAsync<CustomerService>("Power Issue", searchOptions);
        await foreach (SearchResult<CustomerService> result in results.GetResultsAsync())
        {
            Console.WriteLine($"TicketId: {result.Document.TicketId}");
            Console.WriteLine($"CustomerName: {result.Document.CustomerName}");
            Console.WriteLine($"TicketDescription: {result.Document.TicketDescription}");
            Console.WriteLine();
        }
        string JsonResult = System.Text.Json.JsonSerializer.Serialize(results);
        System.Console.WriteLine(JsonResult);
    }

    private static List<CustomerService> ReadCsvFile(string filePath)
    {
       using(var reader = new StreamReader(filePath))
       using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
       {
        var records = csv.GetRecords<CustomerService>().ToList();
        return records;
       }        
    }
   
}
