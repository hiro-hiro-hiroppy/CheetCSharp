using System;

namespace Lib_NLog_Console
{
    class Program
    {
        public static NLog.Logger _Logger = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            _Logger.Trace("Trace!");
            _Logger.Debug("Debug!");
            _Logger.Info("Info!");
            _Logger.Warn("Warn!");
            _Logger.Error("Error!");
            _Logger.Fatal("Fatal!");

            Console.ReadKey();
        }
    }
}
