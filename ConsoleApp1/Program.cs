using AutoMapper;
using BL.BLModels;
using BL.Services;
using ExpendituresALevel.App_Start;
using ExpendituresALevel.Models;
using ExpendituresALevel.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            int a = 0;
            try
            {
                var b = (object)a;
                long c = (long)b;
            }
            catch(Exception e)
            {
                log.Error(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
