
using System;
using System.Collections.Generic;

// defind the abstract base class Person
abstract class Person
{
    protected string name;
    protected string address;

    // constructor
    public Person(string name, string address)
    {
        this.name = name;
        this.address = address;
    }

    // properties 
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    // abstract method display information
    public abstract void Display();
}

// define the  employee class 
class Employee : Person
{
    private readonly int salary;

    // Constructor
    public Employee(string name, string address, int salary)
        : base(name, address)
    {
        this.salary = salary;
    }

    // override the Display method 
    public override void Display()
    {
        Console.WriteLine($"employee Name: {name}, Address: {address}, Salary: {salary}");
    }

    // p roperty get the salary
    public int Salary
    {
        get { return salary; }
    }
}

// define the Customer class from Person
class Customer : Person
{
    private int balance;

    //constructor
    public Customer(string name, string address, int balance)
        : base(name, address)
    {
        this.balance = balance;
    }

    // override the Display method 
    public override void Display()
    {
        Console.WriteLine($"Customer Name: {name}, Address: {address}, Balance: {balance}");
    }

    // property to get the balance
    public int Balance
    {
        get {return balance;}
    }
}

// main class
class Program
{
    static void Main(string[] args)
    {
        // create lists to save store employees and customers
        List<Employee> employees = new List<Employee>();
        List<Customer> customers = new List<Customer>();

        // Menu loop
        while (true)
        {
            Menu();

            if (!int.TryParse(Console.ReadLine(), result: out int choice))
            {
                Console.WriteLine("invalid input");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddEmployee(employees);
                    break;
                case 2:
                    AddCustomer(customers);
                    break;
                case 3:
                    FindHighestSalary(employees);
                    break;
                case 4:
                    FindLowestBalance(customers);
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

    // Show menu options
    static void Menu()
    {
        Console.WriteLine("1. Add Employee: ");
        Console.WriteLine("2. Add Customer: ");
        Console.WriteLine("3. Find Employee with Highest Salary: ");
        Console.WriteLine("4. Find Customer with Lowest Balance: ");
        Console.WriteLine("5. Search Employee by Name: ");
        Console.WriteLine("6.Exit");
        Console.Write("Choose an option: ");
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
            if (!int.TryParse(Console.ReadLine(), out int salary))
            {
                Console.WriteLine("Invalid input. Salary must be a number.");
                return;
            }

            employees.Add(new Employee(name, address, salary));
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
        try
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.Write("Enter balance: ");
            if (!int.TryParse(Console.ReadLine(), out int balance))
            {
                Console.WriteLine("Invalid input. input number");
                return;
            }

            customers.Add(new Customer(name, address, balance));
            Console.WriteLine(" added success! ");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error{e.Message}");
        }
    }

    // method to find the employee with the highest salary
    static void FindHighestSalary(List<Employee> employees)
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        Employee highestSalaryEmployee = employees[0];
        foreach (var employee in employees)
        {
            if (employee.Salary > highestSalaryEmployee.Salary)
            {
                highestSalaryEmployee = employee;
            }
        }

        Console.WriteLine("Employee with the highest salary:");
        highestSalaryEmployee.Display();
    }

    // method to find the customer with the lowest balance
    static void FindLowestBalance(List<Customer> customers)
    {
        if (customers.Count == 0)
        {
            Console.WriteLine("no customers to found.");
            return;
        }

        Customer lowestBalanceCustomer = customers[0];
        foreach (var customer in customers)
        {
            if (customer.Balance < lowestBalanceCustomer.Balance)
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
        foreach (var employee in employees)
        Console.Write("Enter name to search: ");
        string name = Console.ReadLine();
        bool found = false;

        foreach (var employee in employees)
        {
            if (employee.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                employee.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("not found! ");
        }
    }
}

