using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usecase2
{
    class Program
    {
        static void Main(string[] args)
        {
            int IS_FULL_TIME = 1;
            int EMP_RATE_PER_HOUR = 20;
            int emphours = 0;
            int empwage = 0;
            Random random = new Random();
            int empcheck = random.Next(0, 2);
            if(empcheck== IS_FULL_TIME)
            {
                emphours = 8;
            }
            else
            {
                emphours = 0;

            }
            empwage = emphours * EMP_RATE_PER_HOUR;
            Console.WriteLine("Employee daily wage==> " + empwage);
        }
    }
}
