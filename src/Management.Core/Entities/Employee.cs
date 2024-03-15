// <summary> Employee, Class responsible for expressing data related to the employee </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
namespace Management.Core.Entities
{
    public class Employee : Entity
    {
        public Employee() { }

        public Employee(string name, string document, string departament, string role, int companyId)
        {
            CompanyId = companyId;
            Name = name;
            Document = document;
            Departament = departament;
            Role = role;
            IndActive = true;
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Departament { get; set; }
        public string Role { get; set; }
        public bool IndActive { get; set; }

        /*EF Relations*/
        public Company Company { get; set; }
    }
}
