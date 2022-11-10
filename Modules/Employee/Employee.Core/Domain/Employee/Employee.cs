using System;
using System.Collections;

namespace Employee.Core.Domain.Employee
{
    public class Employee
    {
        public Employee(string employeeId, string firstName, string middleName, string lastName, DateTimeOffset dateOfBirth, Gender gender)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }

        public string EmployeeId { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTimeOffset DateOfBirth { get; private set; }
        public Gender Gender { get; private set; }
        private List<Address> addresses = new List<Address>();
        public IReadOnlyList<Address> Addresses => addresses.AsReadOnly();
        private List<Language> languages = new List<Language>();
        public IReadOnlyList<Language> Languages => languages.AsReadOnly();

        public void Update(string firstName, string middleName, string lastName, DateTimeOffset dateOfBirth, Gender gender)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }

        public void AddAddress(int nationalityId, string worda, string kebel, string city)
        {
            addresses.Add(new Address(nationalityId, worda, kebel, city));
        }

        public void RemoveAddress(Address address)
        {
            addresses.Remove(address);
        }

        public void SetImageUrl(string imageUrl)
        {
            ImageUrl = imageUrl;
        }
    }
}