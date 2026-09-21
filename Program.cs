using Super_Mario_Suika.Presentation;

namespace Super_Mario_Suika
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
            Config.CargarRecords();
            Application.Run(new Bienvenida());
        }
    }
}