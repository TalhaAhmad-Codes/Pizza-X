using PizzaX.Domain.Common;
using PizzaX.Domain.Employees.Enums;
using PizzaX.Domain.Employees.ValueObject;
using PizzaX.Domain.Users.Entities;
using System.ComponentModel.DataAnnotations;

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
        public DateTime JoiningDate { get; }
        public DateTime? LeaveDate { get; private set; }

        // Constructors
        private Employee() { }

        private Employee(int userId, EmployeeDesignation designation, decimal salary, Contact contact, Address address, DateTime joiningDate, DateTime? leaveDate)
        {
            Guard.AgainstZeroOrLess(salary, nameof(salary));

            UserId = userId;
            Designation = designation;
            Salary = salary;
            Contact = contact;
            Address = address;
            JoiningDate = joiningDate;
            LeaveDate = leaveDate;
        }

        // Method - Create a new Employee
        public static Employee Create(int userId, EmployeeDesignation designation, decimal salary, Contact contact, Address address, DateTime joiningDate, DateTime? leaveDate = null) 
            => new(userId, designation, salary, contact, address, joiningDate, leaveDate);

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
            if (leaveDate < JoiningDate)
                throw new DomainException("Leave date cannot be before joining date.");

            LeaveDate = leaveDate;
            MarkUpdated();
        }
    }
}
