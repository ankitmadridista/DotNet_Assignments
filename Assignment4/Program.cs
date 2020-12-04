using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 1. Create an array of Employee class objects
        Accept details for all Employees
        Display the Employee with highest Salary
        Accept EmpNo to be searched. Display all details for that employee.
*/
namespace Assignment4_1
{
    class Employee
    {
        private int empno;
        private decimal salary;
        private string name;
        private string dept;

        public Employee(int empno, decimal salary, string name, string dept)
        {
            this.empno = empno;
            this.salary = salary;
            this.name = name;
            this.dept = dept;
        }
        public override string ToString()
        {
            return String.Concat("Empno: ", empno, " Salary: ", salary, " Name: ", name, " Dept: ", dept);
        }
        public decimal Salary
        {
            get
            {
                return salary;
            }
        }
        public int Empno
        {
            get
            {
                return empno;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of the array: ");

            Employee[] arr = new Employee[Convert.ToInt32(Console.ReadLine())];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Emter empno: ");
                int empno = Convert.ToInt32(Console.ReadLine());
                Console.Write("Emter salary: ");
                decimal salary = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Emter name: ");
                string name = Console.ReadLine();
                Console.Write("Emter dept name: ");
                string dept = Console.ReadLine();

                Employee e = new Employee(empno, salary, name, dept);
                arr[i] = e;
                Console.WriteLine();
            }
            foreach (Employee e in arr)
            {
                Console.WriteLine(e.ToString());
            }

            decimal sal;
            sal = arr[0].Salary;

            foreach (Employee item in arr)
            {
                if (item.Salary > sal)
                {
                    sal = item.Salary;
                }
            }
            Console.WriteLine("Max sal: " + sal);

            Console.WriteLine("Enter empno: ");
            int no = Convert.ToInt32(Console.ReadLine());

            foreach (Employee item in arr)
            {
                if (item.Empno == no)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            Console.ReadLine();
        }
    }
}


/*2. CDAC has certain number of batches. each batch has certain number of students
         accept number of batches from the user. for each batch accept number of students.
         create an array to store mark for each student. 
         accept the marks.
         display the marks.


Create a struct Student with the following properties. Put in appropriate validations.
string Name
int RollNo
decimal Marks

Create a parameterized constructor.

Create an array to accept details for 5 students
 
 */

namespace Assignment4_2
{
    class Program
    {
        static void Main2(string[] args)
        {
            Console.WriteLine("Enter no. of batches : ");
            int batches = Convert.ToInt32(Console.ReadLine());

            int[][] arr = new int[batches][];

            Console.WriteLine("no of batches: " + arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter no of students of batch {0} ", i);
                int sizeStd = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("size of std: " + sizeStd);
                int[] marks = new int[sizeStd];

                Console.WriteLine("Enter marks of students of batch {0} ", i );
                for (int j = 0; j < sizeStd; j++)
                {
                    marks[j] = Convert.ToInt32(Console.ReadLine()); 
                }
                arr[i] = marks;

            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine(arr[i][j]);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}


/*
    3. Create a struct Student with the following properties. Put in appropriate validations.
    string Name
    int RollNo
    decimal Marks

    Create a parameterized constructor.

    Create an array to accept details for 5 students
 */
namespace Assignment4_3 {
    class Program { 
        public static void Main() {
 
            Student[] arr = new Student[5];

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter details of student {0} " , i);
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Roll no.: ");
                int rollno = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Marks: ");
                decimal marks = Convert.ToDecimal(Console.ReadLine());

                Student s = new Student(name, rollno, marks);
                arr[i] = s;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i].RollNo + " " + arr[i].Name + " " + arr[i].Marks);
            }
            Console.ReadLine();
        }
    }
    public struct Student {
        public string name;
        public int rollNo;
        public decimal marks;
        public string Name {
            get { return name; }
            set {
                if (value == "")
                {
                    Console.WriteLine("invalid name");
                    name = "no_name";
                }
                else
                    name = value;

            }


        }
        public int RollNo{
            get { return rollNo; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("invalid rollno");
                    rollNo = 1;
                }
                else
                    rollNo = value;

            }
        }
        public decimal Marks {
            get { return marks; }
            set
            {
                if (value < 0 && value > 100)
                {
                    Console.WriteLine("invalid marks");
                    marks = 0;
                }
                else
                    marks = value;
            }
        }

        public Student(string name, int rollNo, decimal marks)
        {
            this.name = "";
            this.rollNo = 0;
            this.marks = 0;
            this.Name = name;
            this.RollNo = rollNo;
            this.Marks = marks;
        }
    }
}
