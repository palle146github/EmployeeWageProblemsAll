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
        public const int NUM_OF_WORKING_DAYS=20;
        public static void Main(string[] args)
        {
            int empwage = 0;
            int emphours = 0;
            int totalempwage = 0;
            for (int day = 0; day < NUM_OF_WORKING_DAYS; day++)
            {
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

                empwage = emphours * EMP_RATE_PER_HOUR;
                totalempwage = totalempwage + empwage;
                Console.WriteLine("Employee Daily Wage==> "+ empwage);
               
            }
            Console.WriteLine("Employee Total Wage==> " + totalempwage);
            Console.ReadLine();
        }
    }
}
