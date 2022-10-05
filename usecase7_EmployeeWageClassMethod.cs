using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace usecase5
{
    public class Program
    {
        public const int EMP_RATE_PER_HOUR = 20;
        public const int IS_PART_TIME = 1;
        public const int IS_FULL_TIME = 2;
        public const int NUM_OF_WORKING_DAYS = 20;
        public const int MAX_HRS_IN_MONTH = 100;
        public static int EmployeeWageComputation()
        {
            int totalEmpWage;
            int totalemphours = 0;
            int totalworkingdays = 0;
            int emphours = 0;
            while (totalemphours <= MAX_HRS_IN_MONTH && totalworkingdays < NUM_OF_WORKING_DAYS)
            {
                totalworkingdays++;
                Random random = new Random();
                int empcheck = random.Next(0, 3);
                switch (empcheck)
                {
                    case IS_FULL_TIME:
                        emphours = 8;
                        break;
                    case IS_PART_TIME:
                        emphours = 4;
                        break;
                    default:
                        emphours = 0;
                        break;
                }

                totalemphours += emphours;
                Console.WriteLine("Day " + totalworkingdays + " Hours " + emphours);

            }
            totalEmpWage = totalemphours * EMP_RATE_PER_HOUR;
            Console.WriteLine("Employee Total Wage : " + totalEmpWage);
            return totalEmpWage;
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            EmployeeWageComputation();

        }
    }
}
