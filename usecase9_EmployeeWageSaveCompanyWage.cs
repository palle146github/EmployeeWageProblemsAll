using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeWageProblem
{
    public class EmployeeWageComputation
    {
        public const int IS_PART_TIME = 1;
        public const int IS_FULL_TIME = 2;
        private String CompanyName;
        private int EMP_RATE_PER_HOUR;
        private int NUM_OF_WORKING_DAYS;
        private int MAX_HRS_IN_MONTH;
        int totalEmpWage;

        public EmployeeWageComputation(String CompanyName, int EMP_RATE_PER_HOUR, int NUM_OF_WORKING_DAYS, int MAX_HRS_IN_MONTH)
        {
            this.CompanyName = CompanyName;
            this.EMP_RATE_PER_HOUR = EMP_RATE_PER_HOUR;
            this.NUM_OF_WORKING_DAYS = NUM_OF_WORKING_DAYS;
            this.MAX_HRS_IN_MONTH = MAX_HRS_IN_MONTH;
            this.totalEmpWage = 0;
        }
        public void CalculateTotalWage()
        {
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
                Console.WriteLine(" Day " + totalworkingdays + " Hours " + emphours);
            }
            totalEmpWage = totalemphours * EMP_RATE_PER_HOUR;
            Console.WriteLine("\nTotal Employee Wage of Company " + CompanyName + " is " + totalEmpWage + "\n");
        }
        public string toString()
        {
            return "Total Emp wage for " + this.CompanyName + " is " + this.totalEmpWage+"\n";
        }
        public static void Main(string[] args)
        {
            EmployeeWageComputation google = new EmployeeWageComputation("Google", 20, 20, 100);
            EmployeeWageComputation reliance = new EmployeeWageComputation("Reliance", 10, 4, 20);
            google.CalculateTotalWage();
            Console.WriteLine(google.toString());
            reliance.CalculateTotalWage();
            Console.WriteLine(reliance.toString());

            Console.ReadLine();
        }
    }
}
