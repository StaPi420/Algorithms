using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("C:\\Users\\kuram\\.vscode\\csproj\\fileIn.txt"))
        {
            int n = int.Parse(reader.ReadLine());
            Employee[] employees = new Employee[n];
            char[] sep = {' '};
            for (int i = 0; i < n; ++i)
            {
                employees[i] = new Employee();
                string[] employee = reader.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                employees[i].lastName = employee[0];
                employees[i].firstName = employee[1];
                employees[i].middleName = employee[2];
                employees[i].hireYear = int.Parse(employee[3]);
                employees[i].position = employee[4];
                employees[i].salary = int.Parse(employee[5]);
                employees[i].experience = int.Parse(employee[6]);
            }
            int salaryLevel = int.Parse(Console.ReadLine());
            var ans = from employee in employees
                      where employee.salary <= salaryLevel
                      orderby employee.experience
                      select employee;
            using (StreamWriter writer = new StreamWriter("C:\\Users\\kuram\\.vscode\\csproj\\fileOut.txt"))
            {
                foreach (Employee employee in ans)
                {
                    writer.WriteLine(employee.getFullName());
                }
            }
        }
    }
}

struct Employee
{
    public string lastName, firstName, middleName, position;
    public int hireYear, salary, experience;

    public string getFullName()
    {
        return String.Format("{0} {1} {2} {3} {4} {5} {6}",
        lastName, firstName, middleName, hireYear, position, salary, experience);
    }
}
