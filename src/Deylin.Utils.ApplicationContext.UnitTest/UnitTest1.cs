using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Deylin.Utils.ApplicationContext.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private ApplicationContext.Current appctx;
        private Configuration.Data config;


        [TestMethod]
        public void TestConfiguration()
        {
            try
            {
                this.appctx = ApplicationContext.Current.Instance;
                this.appctx.OnException += (obj, exc) => Assert.Fail(exc.Message);
                this.config = this.appctx.GetConfigurationData(Configuration.Settings.Current);

                
                Assert.AreEqual(new Guid("2964204F-0041-47FF-BA16-D7D4220B6EB5"), this.config.GUID);
                Assert.AreEqual("Deylin.Utils.ApplicationContext.UnitTests", this.config.ApplicationName);
                Assert.AreEqual(ApplicationContext.Configuration.EnvironmentTypes.Development, this.config.Environment);
                Assert.AreEqual("LocalRelease", this.config.Release);
                Assert.AreEqual(new Version(1,2,3,4), this.config.Version);
                Assert.AreEqual(typeof(Configuration.UnitTestClass), this.config.TestClass.GetType());
                Assert.AreEqual("qwerty", this.config.TestClass.TestString);                

                this.appctx.Dispose();
            }
            catch(Exception exc)
            {
                Assert.Fail(exc.Message);
            }
        }

        [TestMethod]
        public void TestLogging()
        {
            try
            {
                this.appctx = ApplicationContext.Current.Instance;
                this.appctx.OnException += (obj, exc) => Assert.Fail(exc.Message);

                this.appctx.Log(Logging.Level.Debug, "DebugMessage");
                this.appctx.Log(Logging.Level.Error, "ErrorMessage");
                this.appctx.Log(Logging.Level.Fatal, "FatalMessage", new Exception("UnitTestException"));
                this.appctx.Log(Logging.Level.Info, "InfoMessage");
                this.appctx.Log(Logging.Level.Trace, "TraceMessage");
                this.appctx.Log(Logging.Level.Warning, "WarningMessage");


                this.appctx.Dispose();
            }
            catch (Exception exc)
            {
                Assert.Fail(exc.Message);
            }
        }

    }
}
