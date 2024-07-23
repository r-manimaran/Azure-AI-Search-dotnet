using CsvHelper.Configuration.Attributes;

namespace Azure.AI.Search.ConsoleApp;

public class CustomerService {
    [Name("Ticket ID")]
    public string TicketId { get; set; }
    [Name("Customer Name")]
    public string CustomerName { get; set; }
    [Name("Ticket Description")]
    public string TicketDescription { get; set; }
    [Name("Ticket Status")]
    public string TicketStatus { get; set; }
    [Name("Ticket Type")]
    public string TicketType { get; set; }
    [Name("Ticket Priority")]
    public string TicketPriority { get; set; }
}