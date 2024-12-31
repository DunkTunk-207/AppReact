public class ProjectDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Manager { get; set; }
    public string Director { get; set; }
    public Guid ClientId { get; set; }
    public string ClientName { get; set; }
    public string Currency { get; set; }
}