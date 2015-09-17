
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using VeyorProj.Lib;

namespace VeyorProj.Tests
{
    [TestClass]
    public class LoggerTests
    {
        private ILogger _l;


        [TestInitialize]
        public void init()
        {
            _l = AppLogger.Logger.ForContext<LoggerTests>();
        }


        [TestMethod]
        public void log_debug()
        {
            _l.Debug("Debug from test method {g}", "gah");
        }

        [TestMethod]
        public void log_info()
        {
            _l.Information("Info from test method");
        }


        [TestMethod]
        public void log_warn()
        {
            _l.Warning("Info from test method");
        }
    }
}
