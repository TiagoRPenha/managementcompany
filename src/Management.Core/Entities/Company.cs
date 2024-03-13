namespace Management.Core.Entities
{
    public class Company : Entity
    {
        protected Company() { }

        public Company(string name, Address address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;

            IndActive = true;

            Employees = new List<Employee>();
        }

        public string Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public List<Employee> Employees { get; set; }
        public bool IndActive { get; set; }
    }
}
