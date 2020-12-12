using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*1. Declare a dictionary based collection of Employee class objects         
Accept details for Employees  in a loop. Stop accepting based on user input (yes/no)'
Display the Employee with highest Salary
Accept EmpNo to be searched. Display all details for that employee.
Display details for the Nth Employee where N is a number accepted from the user.
*/
namespace Assignment5_1
{
    class Program
    {
        static int i;
        static void Main1(string[] args)
        {
            SortedList<int, Employee> obj = new SortedList<int, Employee>();

            while (true) {
                Console.WriteLine("Enter name and salary of Employee: ");
                string name = Console.ReadLine();
                decimal salary = Convert.ToDecimal(Console.ReadLine());
                Employee e = new Employee(name , salary);
                
                obj.Add(i++, e);
                
                Console.Write("Stop accepting input (y/n): ");

                if (Console.ReadLine() == "y") {
                    break;
                }                               
            }
            Console.WriteLine("Dictionary: ");
            foreach (KeyValuePair<int, Employee> k in obj)
            {
                Console.WriteLine(k.Key + " " + k.Value.Empno + " " + k.Value.Ename + " " + k.Value.Salary );
            }

            //Display the Employee with highest Salary
            IList<Employee> li = new List<Employee>();
            li = obj.Values;
            decimal max = li.First<Employee>().Salary;
            //Console.WriteLine("init max: " + max);
            
            foreach (Employee e in li )
            {
                if (max < e.Salary)
                    max = e.Salary;
            }
            //Console.WriteLine("Max Salary : " + max);
            foreach (KeyValuePair<int, Employee> k in obj)
            {
                if( k.Value.Salary == max )
                    Console.WriteLine( k.Value.Empno + " " +  k.Value.Ename + " " + k.Value.Salary);

            }

            //Accept EmpNo to be searched. Display all details for that employee.
            Console.WriteLine("Enter Empno : ");
            int empno = Convert.ToInt32(Console.ReadLine());
            foreach (KeyValuePair<int, Employee> k in obj)
            {
                if (k.Value.Empno == empno )
                    Console.WriteLine(k.Value.Empno + " " + k.Value.Ename + " " + k.Value.Salary);
            }

            //Display details for the Nth Employee where N is a number accepted from the user.
            Console.WriteLine("Enter nth number : ");
            int nth = Convert.ToInt32(Console.ReadLine());
            foreach (KeyValuePair<int, Employee> k in obj)
            {
                if (k.Key == nth )
                    Console.WriteLine(k.Value.Empno + " " + k.Value.Ename + " " + k.Value.Salary);
            }


            Console.ReadLine();
        }
    }
    public class Employee {

        public Employee( string ename, decimal salary)
        {
            this.Empno = ++empno1;
            this.Ename = ename;
            this.Salary = salary;
        }
        private int empno;
        private static int empno1 = 0;
        public int Empno {
            get { return empno; }
            set {
                empno = value;
            }
        }
        private string ename;
        public string Ename {
            get { return ename; }
            set {
                if ( value == "") {
                    Console.WriteLine("innvalid name");
                    ename = "No_name";
                }
                else {
                    ename = value;
                }
            }
        }
        private decimal salary;
        public decimal Salary {
            get { return salary; }
            set {
                salary = value;
            }
            
        }
    }
}



//2.Create an array of Employee objects. Convert it to a List<Employee>.  Display all the Employees in the list.

namespace Assignment5_2 {
    class Program { 
        public static void Main2(){

            Assignment5_1.Employee []  arr = new Assignment5_1.Employee[5];

            for (int i = 0; i < 5; i++)
            {
                arr[i] = new Assignment5_1.Employee(Console.ReadLine(),Convert.ToDecimal(Console.ReadLine())); 
            }
            List<Assignment5_1.Employee> li = arr.ToList();
            foreach (Assignment5_1.Employee i in li)
            {
                Console.WriteLine(i.Empno + " " + i.Ename + " " + i.Salary);
            }
            Console.ReadLine();
        }
    }
}


//3. Create a List<Employee>. Convert it to an array. Display all the array elements.

namespace Assignment5_3 {
    class Program
    {
        public static void Main()
        {

            Console.WriteLine("Enter size of list: ");
            int size = Convert.ToInt32(Console.ReadLine());
            List<Assignment5_1.Employee> li = new List<Assignment5_1.Employee>();
            Console.WriteLine(size );

            for (int i = 0; i < size ; i++)
            {
                li.Add(new Assignment5_1.Employee("name", 1000))  ;
            }

            //List<Assignment5_1.Employee> li = arr.ToList();
            Assignment5_1.Employee[] arr = li.ToArray();

            foreach (Assignment5_1.Employee i in arr )
            {
                Console.WriteLine(i.Empno + " " + i.Ename + " " + i.Salary);
            }
            Console.ReadLine();
        }
    }
}

