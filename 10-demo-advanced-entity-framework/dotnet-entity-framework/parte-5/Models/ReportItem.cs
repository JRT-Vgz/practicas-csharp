namespace Cf.Dotnet.EntityFramework.Parte5.Models;

public class ReportItem
{
    public int ReportId { get; set; }
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public decimal Quantity { get; set; }
    public DateTime ReportDate { get; set; }
}