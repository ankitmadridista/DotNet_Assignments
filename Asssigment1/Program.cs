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
            private set {
                empno = value;
            }
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
        
        
        public Employee(string Name="", decimal Basic=0, short DeptNo=0)
        {
            empno1++;
            //empno = empno1;
            this.Empno = empno1;
            this.Name = Name;
            this.Basic = Basic;
            this.Deptno = DeptNo;
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

