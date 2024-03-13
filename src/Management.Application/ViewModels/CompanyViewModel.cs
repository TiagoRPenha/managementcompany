using Management.Core.Entities;

namespace Management.Application.ViewModels
{
    public class CompanyViewModel
    {
        public CompanyViewModel(string name, Address address, string phone, bool indActive)
        {
            Name = name;
            Address = address;
            Phone = phone;
            IndActive = indActive;
        }

        public string Name { get; private set; }
        public Address Address { get; private set; }
        public string Phone { get; private set; }
        public bool IndActive { get; private set; }
    }
}
