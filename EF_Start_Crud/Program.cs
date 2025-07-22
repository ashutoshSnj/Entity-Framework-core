using System;
using System.Linq;

namespace Entity_freamwork_Start
{
    public class mainapp
    {
        public static void Main(string[] args)
        {
            using (var dBConnection = new DBConnection())
            {
                dBConnection.Database.EnsureCreated();

                // 🔸 1. CREATE
                var employee = new Employee("Ashutosh", 50000);
                dBConnection.Employees.Add(employee);
                dBConnection.SaveChanges();
                Console.WriteLine("✅ New employee added.");

                // 🔸 2. READ - ALL
                var employees = dBConnection.Employees.ToList();
                Console.WriteLine("\n📋 All Employees:");
                foreach (var emp in employees)
                {
                    Console.WriteLine($"ID: {emp.id}, Name: {emp.Name}, Salary: {emp.Salary}");
                }

                // 🔸 3. READ - BY ID
                int searchId = employee.id;
                var singleEmp = dBConnection.Employees.Find(searchId);
                if (singleEmp != null)
                    Console.WriteLine($"\n🔎 Found Employee: ID={singleEmp.id}, Name={singleEmp.Name}");

                // 🔸 4. UPDATE
                if (singleEmp != null)
                {
                    singleEmp.Name = "Ashutosh Shelke";
                    singleEmp.Salary = 60000;
                    dBConnection.SaveChanges();
                    Console.WriteLine("✏️ Employee updated.");
                }

                // 🔸 5. DELETE
                if (singleEmp != null)
                {
                    dBConnection.Employees.Remove(singleEmp);
                    dBConnection.SaveChanges();
                    Console.WriteLine("❌ Employee deleted.");
                }
            }
        }
    }
}
