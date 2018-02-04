using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xitaso.Logging.MessageGenerator
{
    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private static bool isRunning = true;

        static void Main(string[] args)
        {
            Action checkFunc = new Action(CheckConsoleForExit);
            checkFunc.BeginInvoke(null, null);

            while (isRunning)
            {
                _logger.Trace("Trace message.");
                _logger.Debug("Debug message.");
                _logger.Info("Info message.");
                _logger.Warn("Warning message.");
                _logger.Error("Error message.");
                _logger.Fatal("Fatal message.");
            }
        }

        private static void CheckConsoleForExit()
        {
            Console.WriteLine("Press x to exit.");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Contains("x")) isRunning = false;
            }

        }
    }
}
