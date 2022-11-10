namespace Employee.Core.Domain.Employee
{
    public class Address
    {
        public Address(int nationalityId, string worda, string kebel, string city)
        {
            NationalityId = nationalityId;
            Worda = worda;
            Kebel = kebel;
            City = city;
        }

        public int NationalityId { get; }
        public string Worda { get; }
        public string Kebel { get; }
        public string City { get; }
        public string Name { get; set; }
            
    }
}