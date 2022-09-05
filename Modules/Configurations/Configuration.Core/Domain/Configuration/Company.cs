

using Shared.Abstractions.Types;

namespace  Domains.Configuration
{
    public class Company : BaseEntity
    {
        private Company(){}
        public Company(string name, string description, string logUrl, string tinNumber, string phoneOne, string phoneTwo)
        {
            Name = name;
            Description = description;
            LogUrl = logUrl;
            TinNumber = tinNumber;
            PhoneOne = phoneOne;
            PhoneTwo = phoneTwo;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string LogUrl { get; set; }
        public string TinNumber { get; set; }
        public string PhoneOne { get; set; }
        public string PhoneTwo { get; set; }
    }
}
