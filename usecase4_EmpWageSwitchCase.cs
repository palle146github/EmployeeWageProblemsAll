using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace usecase3
{
    public class Program
    {
        public const int EMP_RATE_PER_HOUR = 20;
        public const int IS_PART_TIME = 1;
        public const int IS_FULL_TIME = 2;
        public static void Main(string[] args)
        {
            int empwage = 0;
            int emphours = 0;
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
            Console.WriteLine("Employee wage==> "+empwage);

        }
    }
}
