using PizzaX.Domain.Common;
using PizzaX.Domain.Employees.Enums;
using PizzaX.Domain.Employees.ValueObject;
using PizzaX.Domain.Users.Entities;

namespace PizzaX.Domain.Employees.Entities
{
    public sealed class Employee : BaseEntity
    {
        // Attributes
        public int UserId { get; private set; }
        public User User { get; private set; }
        public EmployeeDesignation Designation { get; private set; }
        public decimal Salary { get; private set; }
        public Contact Contact {  get; private set; }
        public Address Address { get; private set; }
        public DateTime JoinedDate { get; }
        public DateTime? LeftDate { get; private set; }
        public bool HasLeft => LeftDate is not null;

        // Constructors
        private Employee() { }

        private Employee(int userId, EmployeeDesignation designation, decimal salary, Contact contact, Address address, DateTime joinedDate, DateTime? leftDate)
        {
            Guard.AgainstZeroOrLess(salary, nameof(salary));

            UserId = userId;
            Designation = designation;
            Salary = salary;
            Contact = contact;
            Address = address;
            JoinedDate = joinedDate;
            LeftDate = leftDate;
        }

        // Method - Create a new Employee
        public static Employee Create(int userId, EmployeeDesignation designation, decimal salary, Contact contact, Address address, DateTime joinedDate, DateTime? leftDate = null) 
            => new(userId, designation, salary, contact, address, joinedDate, leftDate);

        // Method - Change Designation
        public void ChangeDesignation(EmployeeDesignation designation)
        {
            Designation = designation;
            MarkUpdated();
        }

        // Method - Update Salary
        public void UpdateSalary(decimal salary)
        {
            Guard.AgainstZeroOrLess(salary, nameof(salary));

            Salary = salary;
            MarkUpdated();
        }

        // Method - Update contact information
        public void UpdateContact(Contact contact)
        {
            Contact = contact;
            MarkUpdated();
        }

        // Method - Update address information
        public void UpdateAddress(Address address)
        {
            Address = address;
            MarkUpdated();
        }

        // Method - Mark leave date
        public void MarkLeaveDate(DateTime leaveDate)
        {
            if (leaveDate < JoinedDate)
                throw new DomainException("Leave date cannot be before joining date.");

            LeftDate = leaveDate;
            MarkUpdated();
        }
    }
}
