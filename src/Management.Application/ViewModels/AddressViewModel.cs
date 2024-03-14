// <summary> AddressViewModel, Class responsible for expressing address-related data </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
namespace Management.Application.ViewModels
{
    public class AddressViewModel
    {
        public string Street { get; set; }
        public string ResidenceNumber { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
