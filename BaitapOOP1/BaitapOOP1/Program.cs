using System;
using System.Collections.Generic;

// define the abstract Person class
abstract class Person
{
    protected string name;
    protected string address;
    // constructors
    public Person(string name, string address){
        this.name = name;
        this.address = address;
    }
    public void SetName(string name)
    {
        this.name = name;
    }
    public string GetName(){
        return name;
    }
    public void SetAddress(string address){
        this.address = address;
    }

    public string GetAddress(){
        return address;
    }

    // abstract method to be implemented 
    public abstract void Display();
}

// define the Employee class that inherits 
class Employee : Person
{
    private int salary;

    public Employee(string name, string address, int salary)
        : base(name, address)
    {
        this.salary = salary;
    }

    public override void Display()
    {
        Console.WriteLine($"Employee Name: {name}, Address: {address}, Salary: {salary}");
    }

    public int GetSalary()
    {
        return salary;
    }
}

// define the Customer class that inherits 
class Customer : Person
{
    private int balance;

    public Customer(string name, string address, int balance)
        : base(name, address)
    {
        this.balance = balance;
    }

    public override void Display()
    {
        Console.WriteLine($"Customer Name: {name}, Address: {address}, Balance: {balance}");
    }

    public int GetBalance()
    {
        return balance;
    }
}

// main class
class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        List<Customer> customers = new List<Customer>();
        //loop use to check choose input
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Add Customer");
            Console.WriteLine("3. Find Employee with Highest Salary");
            Console.WriteLine("4. Find Customer with Lowest Balance");
            Console.WriteLine("5. Search Employee by Name");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());
            // wwitch choice in the user
            switch (choice)
            {
                case 1:
                    AddEmployee(employees);
                    break;
                case 2:
                    AddCustomer(customers);
                    break;
                case 3:
                    FindHighestSalaryEmployee(employees);
                    break;
                case 4:
                    FindLowestBalanceCustomer(customers);
                    break;
                case 5:
                    SearchEmployeeByName(employees);
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // method to add an employee
    static void AddEmployee(List<Employee> employees)
    {
        try
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.Write("Enter salary: ");
            int salary = int.Parse(Console.ReadLine());

            var employee = new Employee(name, address, salary);
            employees.Add(employee);
            Console.WriteLine("Employee added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to add a customer
    static void AddCustomer(List<Customer> customers)
    {
        // enter customer 
        try
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.Write("Enter balance: ");
            int balance = int.Parse(Console.ReadLine());

            var customer = new Customer(name, address, balance);
            customers.Add(customer);
            Console.WriteLine("Customer added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to find the employee with the highest salary
    static void FindHighestSalaryEmployee(List<Employee> employees)
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }
        // find the employess hoighest from to 0
        Employee highestSalaryEmployee = employees[0];

        foreach (var employee in employees)
        {
            if (employee.GetSalary() > highestSalaryEmployee.GetSalary())
            {
                highestSalaryEmployee = employee;
            }
        }

        Console.WriteLine("Employee with the highest salary:");
        highestSalaryEmployee.Display();
    }

    // method to find the customer with the lowest balance
    static void FindLowestBalanceCustomer(List<Customer> customers)
    {
        if (customers.Count == 0)
        {
            Console.WriteLine("No customers found.");
            return;
        }

        Customer lowestBalanceCustomer = customers[0];
        // loop check blance for customer
        foreach (var customer in customers)
        {
            if (customer.GetBalance() < lowestBalanceCustomer.GetBalance())
            {
                lowestBalanceCustomer = customer;
            }
        }

        Console.WriteLine("Customer with the lowest balance:");
        lowestBalanceCustomer.Display();
    }

    // method to search for an employee by name
    static void SearchEmployeeByName(List<Employee> employees)
    {
        Console.Write("Enter name to search: ");
        string name = Console.ReadLine();
        // loop check name in employee equals in employees
        bool found = false;
        foreach (var employee in employees)
        {
            if (employee.GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                employee.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Employee not found.");
        }
    }
}
