using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp
{
    class Program
    {
        static void Main(string[] args)
        {


            //1. decimal SimpleInterest(decimal P, decimal N, decimal R) -> returns calculated SimpleInterest
            Func<decimal, decimal, decimal, decimal> SimpleInt = (p, n, r) =>  (p * n * r) / 100;
            Console.WriteLine(SimpleInt(100,2,10) );

            //2. bool IsGreater(int a, int b) -> returns true if a is > b
            Func<int, int, bool> obj2 = (a, b) => a > b ;
            Console.WriteLine( obj2(5, 45) );


            //3. decimal GetBasic(Employee e) -> returns the Basic salary of the employee
            Func<Employee, decimal> GetBasic = (x) => x.Basic;
            Employee e = new Employee("Ram", 1000000);
            Console.WriteLine( GetBasic( e ));

            //4. bool IsEven(int num) -> returns true if the number is an even number
            Predicate<int> obj3 = (a) => a % 2 == 0;
            Console.WriteLine( obj3(7) );

            //5. bool IsGreaterThan10000(Employee e) -> returns true if the Basic Salary is > 10000
            Predicate<Employee> obj4 = (d) => d.Basic > 10000;
            Console.WriteLine(obj4(e));


            Console.ReadLine();
        }
       
      
    }
    public class Employee {
        private static int empno1;
        private int empno;
        private decimal basic;
        private string ename;
        public string Ename
        {
            get { return ename; }
            set { if (ename != null)
                    ename = value;
                else
                    ename = "noname";
                }
        }
        public decimal Basic { get { return basic; }
            set { basic = value; }
        }
        public Employee(string ename, decimal basic)
        {
            this.empno = ++empno1;
            this.Ename = ename;
            this.Basic = basic;
        }
    }
 

}

