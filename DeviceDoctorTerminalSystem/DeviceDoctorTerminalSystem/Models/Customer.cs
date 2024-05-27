namespace DeviceDoctorTerminalSystem.Models
{
    public record Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
