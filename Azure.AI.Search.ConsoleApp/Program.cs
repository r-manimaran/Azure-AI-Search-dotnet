using Azure;
using Azure.AI.Search.ConsoleApp;
using Azure.Search.Documents;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

string indexName = configuration["indexName"]!;
string adminApiKey = configuration["adminKey"]!;
string endpoint = configuration["endpoint"]!;


Console.WriteLine("Starting Azure AI Search Tool");
Console.WriteLine("-----------------------------------");
Console.WriteLine("Options:");
Console.WriteLine("1. Create Index");
Console.WriteLine("2. Upload Documents");
Console.WriteLine("3. Search Documents");
Console.WriteLine("4. Exit");
Console.Write("Enter your choice: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string choice = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
Console.WriteLine("-----------------------------------");
switch (choice)
{
    case "1":
        await SearchHelper.CreateIndex();
        break;
    case "2":
        await SearchHelper.UploadDocuments();
        break;
    case "3":
        Console.WriteLine("Enter search query: ");
        await SearchHelper.SearchDocuments(endpoint,adminApiKey,indexName);
        break;
    case "4":
        return;
    default:
        Console.WriteLine("Invalid choice. Please try again.");
        break;
}
