using System;

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
// ———————————————————————————————————————————————————— 【1】
        // public decimal Salary()
        // {
        //     return salary;
        // }

        // public decimal Salary
        // {
        //     get { return salary; }
        // }

        //public decimal Salary {get;}=5000;
// ———————————————————————————————————————————————————— 【2】
          // public decimal Salary(int a)
          // {
          //     return a*10;
          // }      
// ———————————————————————————————————————————————————— 【3】

          // public void Salary(int a,out int result)
          // {
          //     result=a*10;
          // } 

    }

    class Tax
    {
        public static decimal CalcTax(Employee E)
        {
            // ———————————————————————————————————————————————————— 【1】
            // return 0.08m * E.Salary();
            // ———————————————————————————————————————————————————— 【2】
            // int a=4000;
            // return 0.08m * E.Salary(a);
            // ————————————————————————————————————————————————————【3】
            // int rs;
            // E.Salary(600,out rs)
            // return 0.08m * rs;

        }
    }

    class Program
    {
        static void Main()
        {
            Employee E1 = new Employee("Mingda Pan", "mpan");

            E1.printEmployee();
        }
    }

