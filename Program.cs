using System.Diagnostics;

namespace Timer
{
    internal static class Program
    {
        public static int id = 0;
        public static Settings settings = null;
        public static FormTimer formTimer = null;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            id = Process.GetProcessesByName("timer").Length;

            settings = new Settings(id);
            settings.Load();

            ApplicationConfiguration.Initialize();
            Application.Run(new FormTimer());

            settings.Save();
        }
    }
}