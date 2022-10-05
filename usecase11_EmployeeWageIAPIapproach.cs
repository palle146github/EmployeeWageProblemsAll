using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEmployeeWageProblem
{
    public interface IEmployeeWageComputation
    {
        void addCompanyEmpWage(String CompanyName, int EMP_RATE_PER_HOUR, int NUM_OF_WORKING_DAYS, int MAX_HRS_IN_MONTH);
        void computeEmpWage();
    }
    public class CompanyEmpWage
    {
        public string CompanyName;
        public int EMP_RATE_PER_HOUR;
        public int NUM_OF_WORKING_DAYS;
        public int MAX_HRS_IN_MONTH;
        public int totalEmpWage;
        public CompanyEmpWage(String CompanyName, int EMP_RATE_PER_HOUR, int NUM_OF_WORKING_DAYS, int MAX_HRS_IN_MONTH)
        {
            this.CompanyName = CompanyName;
            this.EMP_RATE_PER_HOUR = EMP_RATE_PER_HOUR;
            this.NUM_OF_WORKING_DAYS = NUM_OF_WORKING_DAYS;
            this.MAX_HRS_IN_MONTH = MAX_HRS_IN_MONTH;
            this.totalEmpWage = 0;
        }
        public void setTotalEmpWage(int totalEmpWage)
        {
            this.totalEmpWage = totalEmpWage;

        }
        public string toStrig()
        {
            return "Total Emp Wage for company : " + this.CompanyName + " is " + this.totalEmpWage;
        }
    }
    public class EmployeeWageComputation : IEmployeeWageComputation
    {
        public const int IS_PART_TIME = 1;
        public const int IS_FULL_TIME = 2;
        private int noOfCompanies = 0;
        private CompanyEmpWage[] companyEmpWageArray;
        public EmployeeWageComputation()
        {
            this.companyEmpWageArray = new CompanyEmpWage[10];
        }
        public void addCompanyEmpWage(String CompanyName, int EMP_RATE_PER_HOUR, int NUM_OF_WORKING_DAYS, int MAX_HRS_IN_MONTH)
        {
            companyEmpWageArray[this.noOfCompanies] = new CompanyEmpWage(CompanyName, EMP_RATE_PER_HOUR, NUM_OF_WORKING_DAYS, MAX_HRS_IN_MONTH);
            noOfCompanies++;
        }
        public void computeEmpWage()
        {
            for (int i = 0; i < noOfCompanies; i++)
            {
                companyEmpWageArray[i].setTotalEmpWage(this.computeEmpWage(this.companyEmpWageArray[i]));
                Console.WriteLine(this.companyEmpWageArray[i].toStrig());
            }
        }
        private int computeEmpWage(CompanyEmpWage companyEmpWage)
        {
            int totalworkingdays = 0;
            int totalemphours = 0;
            int emphours = 0;
            while (totalworkingdays < companyEmpWage.NUM_OF_WORKING_DAYS && totalemphours <= companyEmpWage.MAX_HRS_IN_MONTH)
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
                Console.WriteLine(companyEmpWage.CompanyName + " Day " + totalworkingdays + " Hours " + emphours);
            }
            return totalemphours * companyEmpWage.EMP_RATE_PER_HOUR;
        }

        public static void Main(string[] args)
        {
            EmployeeWageComputation employeeWageComputation = new EmployeeWageComputation();
            employeeWageComputation.addCompanyEmpWage("Microsoft", 4, 30, 100);
            employeeWageComputation.addCompanyEmpWage("Google", 5, 40, 170);
            employeeWageComputation.addCompanyEmpWage("Apple", 9, 10, 70);
            employeeWageComputation.computeEmpWage();
            Console.ReadLine();
        }
    }
}
