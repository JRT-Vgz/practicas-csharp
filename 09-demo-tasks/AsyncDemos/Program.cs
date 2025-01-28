using AsyncDemos.Demo2;
using AsyncDemos.Demo3;
using AsyncDemos.Demo4;
using AsyncDemos.Demo5;
using AsyncDemos.Demo6;
using AsyncDemos.Demo7;

namespace AsyncDemos
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Demo7After());
        }
    }
}