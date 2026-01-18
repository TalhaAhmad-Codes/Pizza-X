using PizzaX.Domain.Common.Entities;
using PizzaX.Domain.Enums.Employee;
using PizzaX.Domain.ValueObjects.Common;
using PizzaX.Domain.ValueObjects.Employee;

namespace PizzaX.Domain.Entities
{
    public sealed class Employee : AuditableEntity
    {
        // Attributes
        public Guid UserId { get; private set; }
        public Name Name { get; private set; }
        public CNIC CNIC { get; private set; }
        public Address Address { get; private set; }
        public Contact Contact { get; private set; }
        public Role JobRole { get; private set; }
        public Salary Salary { get; private set; }
        public Shift Shift { get; private set; }
        public DateOnly JoiningDate { get; private set; }
        public DateOnly? LeftDate { get; private set; }

        // Navigation
        public User User { get; private set; }

        // Constructors
        private Employee() { }

        private Employee(Guid userId, Role jobRole, Salary salary, Name name)
        {
            UserId = userId;
            JobRole = jobRole;
            Salary = salary;
            Name = name;
        }

        // Method - Create a new employee
        public static Employee Create(Guid userId, Name name, Role jobRole, Salary salary)
            => new(userId, jobRole, salary, name);

        /*******************************/
        /* Methods - Update Properties */
        /*******************************/

        public void UpdateJobRole(Role jobRole)
        {
            JobRole = jobRole;

            MarkUpdated();
        }

        public void UpdateSalary(decimal salary)
        {
            Salary = Salary.Create(salary);

            MarkUpdated();
        }

        public void UpdateName()
        {

        }
    }
}
