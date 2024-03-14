// <summary> EmployeeViewModel, Class responsible for expressing data related to the employee </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
namespace Management.Application.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel(string name, string document, string departament, string role, bool indActive)
        {
            Name = name;
            Document = document;
            Departament = departament;
            Role = role;
            IndActive = indActive;
        }

        public string Name { get; set; }
        public string Document { get; set; }
        public string Departament { get; set; }
        public string Role { get; set; }
        public bool IndActive { get; set; }
    }
}
