using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Core.Entities
{
    public class Address : Entity
    {
        public Address(string street, string residenceNumber, string neighborhood, string complement, string city, string state, string country)
        {
            Street = street;
            ResidenceNumber = residenceNumber;
            Neighborhood = neighborhood;
            Complement = complement;
            City = city;
            State = state;
            Country = country;
        }

        public int CompanyId { get; set; }
        public string Street { get; set; }
        public string ResidenceNumber { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        /*EF Relations*/
        [NotMapped]
        public Company Company { get; set; }
    }
}
