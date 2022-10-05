using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEmployeeWageProblem
{
    public interface IComputeEmpWage
    {
        void addCompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth);
        void computeEmpWage();

    }
    public class CompanyEmpWage
    {
        public string company;
        public int empRatePerHour;
        public int numOfWorkingDays;
        public int maxHoursPerMonth;
        public int totalEmpWage;
        public CompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth)
        {
            this.company = company;
            this.empRatePerHour = empRatePerHour;
            this.numOfWorkingDays = numOfWorkingDays;
            this.maxHoursPerMonth = maxHoursPerMonth;
            this.totalEmpWage = 0;
        }
        public void setTotalEmpWage(int totalEmpWage)
        {
            this.totalEmpWage = totalEmpWage;

        }
        public string toStrig()
        {
            return "Total Emp Wage for company : " + this.company + " is " + this.totalEmpWage;
        }
    }
    public class EmpWageBuilder : IComputeEmpWage
    {
        public const int IS_PART_TIME = 1;
        public const int IS_FULL_TIME = 2;

        private LinkedList<CompanyEmpWage> companyEmpWageList;
        private Dictionary<string, CompanyEmpWage> companyToEmpWageMap;
        public EmpWageBuilder()
        {
            this.companyEmpWageList = new LinkedList<CompanyEmpWage>();
            this.companyToEmpWageMap = new Dictionary<string, CompanyEmpWage>();
        }
        public void addCompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth)
        {
            CompanyEmpWage companyEmpWage = new CompanyEmpWage(company, empRatePerHour, numOfWorkingDays, maxHoursPerMonth);
            this.companyEmpWageList.AddLast(companyEmpWage);
            this.companyToEmpWageMap.Add(company, companyEmpWage);
        }
        public void computeEmpWage()
        {
            foreach (CompanyEmpWage companyEmpWage in this.companyEmpWageList)
            {
                companyEmpWage.setTotalEmpWage(this.computeEmpWage(companyEmpWage));
                Console.WriteLine(companyEmpWage.toStrig());
            }
        }
        private int computeEmpWage(CompanyEmpWage companyEmpWage)
        {
            int totalworkingdays = 0;
            int totalemphours = 0;
            int emphours = 0;
            while (totalworkingdays < companyEmpWage.numOfWorkingDays && totalemphours <= companyEmpWage.maxHoursPerMonth)
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
                Console.WriteLine(companyEmpWage.company + " Day " + totalworkingdays + " Hours " + emphours);
            }
            return totalemphours * companyEmpWage.empRatePerHour;
        }
        void printTotalEmpWages()
        {
            Console.WriteLine("\nThe companies and the total employee wages are:");
            foreach(String CompanyName in companyToEmpWageMap.Keys)
            {
                Console.WriteLine(companyToEmpWageMap[CompanyName].toStrig());
            }
            
        }

        public static void Main(string[] args)
        {
            EmpWageBuilder employeeWageBuilder = new EmpWageBuilder();
            employeeWageBuilder.addCompanyEmpWage("Microsoft", 4, 30, 100);
            employeeWageBuilder.addCompanyEmpWage("Google", 5, 40, 170);
            employeeWageBuilder.addCompanyEmpWage("Apple", 9, 10, 70);
            employeeWageBuilder.computeEmpWage();
            employeeWageBuilder.printTotalEmpWages();
            Console.ReadLine();
        }

    }
}
