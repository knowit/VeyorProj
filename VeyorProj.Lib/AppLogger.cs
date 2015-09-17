using Serilog;

namespace VeyorProj.Lib
{
    public static class AppLogger
    {

        static AppLogger()
        {
            Log.Logger = new LoggerConfiguration()
                               .ReadFrom.AppSettings()
                               .CreateLogger();
        }

        public static ILogger Logger { get { return Log.Logger; } }
    }
}
