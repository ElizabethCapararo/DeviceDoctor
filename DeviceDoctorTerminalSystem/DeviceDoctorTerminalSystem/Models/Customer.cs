namespace DeviceDoctorTerminalSystem.Models
{
    public record Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Notes { get; set; }

        public static Customer Create(string firstName, string lastName, string contactNumber, string notes = "")
        {
            return new()
            {
                FirstName = firstName,
                LastName = lastName,
                ContactNumber = contactNumber,
                Notes = notes
            };
        }
    }
}
