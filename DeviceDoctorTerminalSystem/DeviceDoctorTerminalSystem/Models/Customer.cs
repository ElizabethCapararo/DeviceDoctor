﻿namespace DeviceDoctorTerminalSystem.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }

        public static Customer Create(string firstName, string lastName, string contactNumber)
        {
            return new()
            {
                FirstName = firstName,
                LastName = lastName,
                ContactNumber = contactNumber
            };
        }
    }
}