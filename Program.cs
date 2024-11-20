using System.Diagnostics;

namespace Widget
{
    internal static class Program
    {
        public static int id = 0;
        public static Settings settings = null;
        public static List<FormWidget> formWidgets = new List<FormWidget>();

        public static FormWidget AddNewWidget() {
            FormWidget formWidget = new FormWidget();
            formWidgets.Add(formWidget);
            formWidget.Show();

            return formWidget;
        }

        public static void RemoveWidget(FormWidget formWidget)
        {
            formWidgets.Remove(formWidget);
        }

        public static void CloseApplication(FormWidget formWidget)
        {
            foreach (var widget in formWidgets)
            {
                widget.Close();
            }

           Application.Exit();
        }


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            id = Process.GetProcessesByName("widget").Length;
            settings = new Settings(id);
            settings.Load();

            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());

            settings.Save();
        }
    }
}