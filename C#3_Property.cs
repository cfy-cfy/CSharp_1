using System;

namespace HelloWorld
{
      class Employee
    {
        private string name;
        private string alias;
        private decimal salary = 3000.00m;

        // Constructor:
        public Employee(string name, string alias)
        {
            // Use this to qualify the fields, name and alias:
            this.name = name;
            this.alias = alias;
        }

        // Printing method:
        public void printEmployee()
        {
            Console.WriteLine("Name: {0}\nAlias: {1}", this.name, alias);
            // Passing the object to the CalcTax method by using this:
            Console.WriteLine("Taxes: {0:C}", Tax.CalcTax(this));
        }

        public decimal Salary
        {
            get { return salary; }
        }

        //public decimal Salary {get;}=5000;
    }

    class Tax
    {
        public static decimal CalcTax(Employee E)
        {
            return 0.08m * E.Salary;
        }
    }

    class MainClass
    {
        static void Main()
        {
            Employee E1 = new Employee("Mingda Pan", "mpan");

            E1.printEmployee();
        }
    }

}
