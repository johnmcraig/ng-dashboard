namespace DataDashboard.Core.Entities
{
    public class Server : BaseEntity
    {
        public string Name { get; set; }
        public bool IsOnline { get; set; }
    }
}