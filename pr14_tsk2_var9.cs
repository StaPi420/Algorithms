using System;
using System.IO;

class Program
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("C:\\Users\\contest\\fileIn2.txt"))
        {
            int n = int.Parse(reader.ReadLine());
            Student[] studentArray = new Student[n];
            char[] sep = { ' ' };
            for (int i = 0; i < n; ++i)
            {
                string[] studentLine = reader.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                studentArray[i] = new Student(studentLine[0],
                                            studentLine[1],
                                            int.Parse(studentLine[2]),
                                            int.Parse(studentLine[3]),
                                            int.Parse(studentLine[4]),
                                            int.Parse(studentLine[5]),
                                            int.Parse(studentLine[6]),
                                            int.Parse(studentLine[7]),
                                            int.Parse(studentLine[8]));
            }
            Array.Sort(studentArray);
            using (StreamWriter writer = new StreamWriter("C:\\Users\\contest\\fileOut.txt"))
            {
                foreach (Student student in studentArray)
                {
                   Console.WriteLine($"{student.name} {student.faculty} {student.course} {student.group} {student.firstGrade} {student.secondGrade} {student.thirdGrade} {student.fourthGrade} {student.fifthGrade}");
                   if (student.has2Grade())
                   {
                       writer.WriteLine($"{student.name} {student.faculty} {student.course} {student.group} {student.firstGrade} {student.secondGrade} {student.thirdGrade} {student.fourthGrade} {student.fifthGrade}");
                   }
                }
            }
            
        }
    }
}

struct Student : IComparable<Student>
{
    public string name, faculty;
    public int course, group, firstGrade, secondGrade, thirdGrade, fourthGrade, fifthGrade;

    public Student(string name, string faculty, int course, int group, int firstGrade,
    int secondGrade, int thirdGrade, int fourthGrade, int fifthGrade)
    {
        this.name = name;
        this.faculty = faculty;
        this.course = course;
        this.group = group;
        this.firstGrade = firstGrade;
        this.secondGrade = secondGrade;
        this.thirdGrade = thirdGrade;
        this.fourthGrade = fourthGrade;
        this.fifthGrade = fifthGrade;
    }

    public bool has2Grade()
    {
        if (this.firstGrade == 2 || this.secondGrade == 2 || this.thirdGrade == 2 || this.fourthGrade == 2 || this.fifthGrade == 2)
        {
            return true;
        }
        return false;
    }

    public int CompareTo(Student obj)
    {
        if (this.course > obj.course)
        {
            return 1;
        }
        if (this.course == obj.course)
        {
            return 0;
        }
        return -1;
    }
}
