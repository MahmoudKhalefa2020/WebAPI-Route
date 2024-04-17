using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.EmployeeSpecs
{
    public class EmployeeWithDepartmentSpecifications : BaseSpecifications<Employee>
    {
        public EmployeeWithDepartmentSpecifications()
            : base()
        {
            Includes.Add(E => E.Department);
        }

        public EmployeeWithDepartmentSpecifications(int id)
            : base(E => E.Id == id)
        {

        }
    }
}
