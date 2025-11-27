using System;
using System.IO;
using System.Linq;
class Program
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("C:\\Users\\contest\\fileIn.txt"))
        {
            char[] sep = { ' ', '.', ',', ';', '\n', '\t', '\r' };
            String[] content = reader.ReadToEnd().Split(sep, StringSplitOptions.RemoveEmptyEntries);
            Employee[] employees = new Employee[content.Length / 7];
            for (int i = 0; i < content.Length / 7; ++i)
            {
                employees[i] = new Employee();
                employees[i].lastName = content[7 * i];
                employees[i].firstName = content[7 * i + 1];
                employees[i].middleName = content[7 * i + 2];
                employees[i].hireYear = int.Parse(content[7 * i + 3]);
                employees[i].position = content[7 * i + 4];
                employees[i].salary = int.Parse(content[7 * i + 5]);
                employees[i].experience = int.Parse(content[7 * i + 6]);
            }
            var ans = employees.GroupBy(employee => employee.position);
            using (StreamWriter writer = new StreamWriter("C:\\Users\\contest\\fileOut.txt"))
            {
                foreach (var group in ans)
                {
                    writer.WriteLine($"{group.Key}:");
                    foreach (Employee employee in group)
                    {
                        writer.WriteLine($"{employee.lastName} {employee.middleName} {employee.firstName}");
                    }
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
