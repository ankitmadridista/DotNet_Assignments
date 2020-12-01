using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Employee
    {
        #region properties
        private string name;
        public string Name
        {
            set
            {
                if (value != "")
                {
                    name = value;
                }
                else {
                    Console.WriteLine("invalid name (employee name can not be blank)");
                    name = "Emp_name";
                }
            }
            get
            {
                return name;
            }
        }
        private static int empno1 = 0;
        private int empno;
        public int Empno
        {
            get
            {
                return empno;
            }
        }
        private decimal basic;
        public decimal Basic
        {

            set
            {
                if (value > 2000 && value < 8000)
                {
                    basic = value;
                }
                else {
                    Console.WriteLine("invalid basic assigned to 2000");
                    basic = 2000;
                }
            }
            get { return basic; }
        }
        private short deptno;
        public short Deptno
        {
            set
            {
                if (value > 0 )
                {
                    deptno = value;                   
                }
                else {
                    Console.WriteLine("assigned to dept no 1");
                    deptno = 1;
                }
            }
            get
            {
                return deptno;
            }
        }
        #endregion properties
        #region Methods
        public decimal GetNetSalary()
        {
            decimal salary = Basic + (Basic * 10);
            return salary;
        }
        #endregion Methods
        #region constructor
        
        public Employee(string Name, decimal Basic, short DeptNo)
        {
            empno1++;
            empno = empno1;
            this.Name = Name;
            this.Basic = Basic;
            this.Deptno = DeptNo;
        }
        public Employee(string Name, decimal Basic)
        {
            empno1++;
            empno = empno1;
            this.Name = Name;
            this.Basic = Basic;
            this.Deptno = 0;
        }
        public Employee(string Name)
        {
            empno1++;
            empno = empno1;
            this.Name = Name;
            this.Basic = 0;
            this.Deptno = 0;
        }
        public Employee()
        {
            empno1++;
            empno = empno1;
            this.Name = "";
            this.Basic = 0;
            this.Deptno = 0;

        }
        #endregion constructor
    }
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("in main");

            Employee o1 = new Employee();
            Employee o2 = new Employee();
            Employee o3 = new Employee();
            
           

            Console.WriteLine(o1.Empno);
            Console.WriteLine(o2.Empno);
            Console.WriteLine(o3.Empno);

            Console.WriteLine("==================================");
            Console.WriteLine();
            Console.WriteLine(o3.Empno);
            Console.WriteLine(o2.Empno);
            Console.WriteLine(o1.Empno);

            Console.WriteLine("==================================");
            Console.WriteLine();
            Console.WriteLine(o1.Deptno);
            Console.WriteLine(o1.Basic);
            Console.WriteLine(o1.Name);

            Console.WriteLine("==================================");

            Employee o4 = new Employee("Amol", 123465, 10);
            Console.WriteLine(o4.Empno);
            Console.WriteLine(o4.Deptno);
            Console.WriteLine(o4.Basic);
            Console.WriteLine(o4.Name);
            Console.WriteLine("==================================");


            Employee o5 = new Employee("Amol", 123465);
            Console.WriteLine(o5.Empno);
            Console.WriteLine(o5.Deptno);
            Console.WriteLine(o5.Basic);
            Console.WriteLine(o5.Name);
            Console.WriteLine("==================================");


            Employee o6 = new Employee("Amol");
            Console.WriteLine(o6.Empno);
            Console.WriteLine(o6.Deptno);
            Console.WriteLine(o6.Basic);
            Console.WriteLine(o6.Name);
            Console.WriteLine("==================================");

            Console.ReadLine();

        }
    }
}


//namespace assignment_no1
//{

//    class Employee
//    {
//        #region properties
//        private string name;
//        public string Name
//        {
//            set
//            {
//                if (value == "")
//                {
//                    name = "employee name";
//                }
//            }
//            get
//            {
//                return name;
//            }
//        }
//        private static int empno1 = 0;
//        private int empno;
//        public int Empno
//        {
//            get
//            {
//                return empno;
//            }
//        }
//        private decimal basic;
//        public decimal Basic
//        {

//            set
//            {
//                if (value < 2000)
//                {
//                    basic = 2000;
//                }
//            }
//            get { return basic; }
//        }
//        private short deptno;
//        public short Deptno
//        {
//            set
//            {
//                if (value < 1)
//                {
//                    Console.WriteLine("assigned to dept no 1");
//                    deptno = 1;
//                }
//            }
//            get
//            {
//                return deptno;
//            }
//        }
//        #endregion properties
//        #region Methods
//        public decimal GetNetSalary()
//        {
//            decimal salary = Basic + (Basic * 10);
//            return salary;
//        }
//        #endregion Methods
//        #region constructor
//        /* Employee o1 = new Employee("Amol", 123465, 10);
//         Employee o2 = new Employee("Amol", 123465);
//         Employee o3 = new Employee("Amol");
//         Employee o4 = new Employee();*/
//        public Employee(string Name, decimal Basic, short DeptNo)
//        {
//            empno1++;
//            empno = empno1;
//            this.Name = Name;
//            this.Basic = Basic;
//            this.Deptno = Deptno;
//        }
//        public Employee(string Name, decimal Basic)
//        {
//            empno1++;
//            empno = empno1;
//            this.Name = Name;
//            this.Basic = Basic;
//            this.Deptno = 0;
//        }
//        public Employee(string Name)
//        {
//            empno1++;
//            empno = empno1;
//            this.Name = Name;
//            this.Basic = 0;
//            this.Deptno = 0;
//        }
//        public Employee()
//        {
//            empno1++;
//            empno = empno1;
//            this.Name = "";
//            this.Basic = 0;
//            this.Deptno = 0;

//        }

//        #endregion constructor


//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            System.Console.WriteLine("hello world");
//            string s = System.Console.ReadLine();
//            System.Console.WriteLine(s);
//            System.Console.ReadLine();
//            Employee o1 = new Employee();//2
//            Employee o2 = new Employee();
//            Employee o3 = new Employee();
//            Console.WriteLine(o1.Empno);
//            Console.WriteLine(o2.Empno);
//            Console.WriteLine(o3.Empno);

//            Console.WriteLine(o1.Deptno);
//            Console.WriteLine(o1.Basic);
//            Console.WriteLine(o1.Name);

//            Console.ReadLine();

//        }
//    }
//}

/*
 * Create a Class Employee with te following specifications


Properties
----------
string Name -> no blank names should be allowed
int EmpNo -> must be readonly and autogenerated
decimal Basic -> must be between some range
short DeptNo -> must be > 0

Methods
-------
decimal GetNetSalary() -> returns calculated net salary (Use any formula to get net salary based on Basic salary)


Create overloaded constructors to accept initial values for Employee obj
Employee o1 = new Employee("Amol",123465, 10);
Employee o2 = new Employee("Amol",123465);
Employee o3 = new Employee("Amol");
Employee o4 = new Employee();




EmpNo must be autogenerated ... i.e.
first object should automatically get EmpNo 1
second object should automatically get EmpNo 2
third object should automatically get EmpNo 3
...and so on...

Test Cases
Employee o1 = new Employee()
Employee o2 = new Employee()
Employee o3 = new Employee()
cw(o1.EmpNo)
cw(o2.EmpNo)
cw(o3.EmpNo)

cw(o3.EmpNo)
cw(o2.EmpNo)
cw(o1.EmpNo)
 */
