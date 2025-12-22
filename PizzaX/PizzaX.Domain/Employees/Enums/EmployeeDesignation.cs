namespace PizzaX.Domain.Employees.Enums
{
    public enum EmployeeDesignation
    {
        // Kitchen Staff
        Chef = 1,               // Prepares pizzas
        AssistantChef = 2,      // Helps chef, prep work

        // Front Counter
        Cashier = 3,            // Handles billing, walk-in orders
        OrderTaker = 4,         // Takes phone / counter orders

        // Delivery
        DeliveryRider = 5,      // Delivers orders

        // Operations
        Cleaner = 6,            // Maintains hygiene

        // Management
        Manager = 7,            // Manages daily operations (Also, Admin)
        ShiftSupervisor = 8,    // Manages a shift
        Owner = 9
    }
}
