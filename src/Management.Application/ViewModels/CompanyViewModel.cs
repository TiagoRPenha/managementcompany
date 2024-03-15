// <summary> CompanyViewModel, Class responsible for expressing data related to the company </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
namespace Management.Application.ViewModels
{
    public class CompanyViewModel
    {
        protected CompanyViewModel() { }
        public CompanyViewModel(string name, AddressViewModel address, string phone, bool indActive)
        {
            Name = name;
            Address = address;
            Phone = phone;
            IndActive = indActive;
        }

        public string Name { get; private set; }
        public AddressViewModel Address { get; private set; }
        public string Phone { get; private set; }
        public bool IndActive { get; private set; }
    }
}
