using PizzaX.Domain.Common;
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
        public Contact? Contact { get; private set; }
        public EmployeeJobRole JobRole { get; private set; }
        public Salary Salary { get; private set; }
        public EmployeeShift Shift { get; private set; }
        public DateOnly JoiningDate { get; private set; }
        public DateOnly? LeftDate { get; private set; }
        public bool HasLeft => LeftDate != null;

        // Navigation
        public User User { get; private set; }

        // Constructors
        private Employee() { }

        private Employee(Guid userId, Address address, CNIC cnic, Contact contact, EmployeeJobRole jobRole, EmployeeShift employeeShift, Salary salary, Name name, DateOnly joiningDate, DateOnly? leftDate)
        {
            Guard.AgainstInvalidDateRange(joiningDate, leftDate);

            UserId = userId;
            JobRole = jobRole;
            Shift = employeeShift;
            Salary = salary;
            Name = name;
            JoiningDate = joiningDate;
            LeftDate = leftDate;
            Address = address;
            Contact = contact;
            CNIC = cnic;
        }

        // Method - Create a new employee
        public static Employee Create(Guid userId, Address address, CNIC cnic, Contact contact, EmployeeJobRole jobRole, EmployeeShift employeeShift, Salary salary, Name name, DateOnly joiningDate, DateOnly? leftDate = null)
            => new(userId, address, cnic, contact, jobRole, employeeShift, salary, name, joiningDate, leftDate);

        /*******************************/
        /* Methods - Update Properties */
        /*******************************/

        public void UpdateJobRole(EmployeeJobRole jobRole)
        {
            JobRole = jobRole;

            MarkUpdated();
        }

        public void UpdateSalary(decimal salary)
        {
            Salary = Salary.Create(salary);

            MarkUpdated();
        }

        public void UpdateName(string firstName, string? midName, string lastName, string fatherName)
        {
            Name = Name.Create(firstName, midName, lastName, fatherName);

            MarkUpdated();
        }

        public void UpdateAddress(string house, string area, string street, string city, string province, string? country)
        {
            Address = Address.Create(house, area, street, city, province, country);

            MarkUpdated();
        }

        public void UpdateContact(string number)
        {
            Contact = Contact.Create(number);

            MarkUpdated();
        }

        public void UpdateCNIC(string cnic)
        {
            CNIC = CNIC.Create(cnic);

            MarkUpdated();
        }

        public void UpdateEmployeeShift(EmployeeShift empshift)
        {
            Shift = empshift;

            MarkUpdated();
        }

        public void MarkJobLeaved(DateOnly date)
        {
            Guard.AgainstInvalidDateRange(JoiningDate, date);

            if (HasLeft)
                throw new DomainException("Employee had already been left.");

            LeftDate = date;

            MarkUpdated();
        }
    }
}
