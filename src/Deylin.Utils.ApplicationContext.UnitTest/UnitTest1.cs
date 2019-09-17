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
        public void TestConfiguration1()
        {
            try
            {
                using (this.appctx = ApplicationContext.Current.Instance)
                {
                    void handler(object obj, Exception exc) => Assert.Fail(exc.Message);

                    this.appctx.OnException += handler;
                    this.config = this.appctx.GetConfigurationData(Configuration.Settings.Current);


                    Assert.AreEqual(new Guid("2964204F-0041-47FF-BA16-D7D4220B6EB5"), this.config.GUID);
                    Assert.AreEqual("Deylin.Utils.ApplicationContext.UnitTests", this.config.ApplicationName);
                    Assert.AreEqual(ApplicationContext.Configuration.EnvironmentTypes.Development, this.config.Environment);
                    Assert.AreEqual("LocalRelease", this.config.Release);
                    Assert.AreEqual(new Version(1, 2, 3, 4), this.config.Version);
                    Assert.AreEqual(typeof(Configuration.UnitTestClass), this.config.TestClass.GetType());
                    Assert.AreEqual("qwerty", this.config.TestClass.TestString);

                    this.appctx.OnException -= handler;
                }
            }
            catch(Exception exc)
            {
                Assert.Fail(exc.Message);
            }
        }

        [TestMethod]
        public void TestConfiguration2()
        {
            using (this.appctx = ApplicationContext.Current.Instance)
            {
                void handler(object obj, Exception exc)
                {
                    Console.WriteLine($"Exception thrown in TestConfiguration2: {exc.Message}");

                    Assert.IsTrue(exc.Message.StartsWith("Could not find file"));
                }
                this.appctx.OnException += handler;
                
                this.config = this.appctx.GetConfigurationData(Configuration.Settings2.Current);
                Assert.IsNull(this.config);
                this.appctx.OnException -= handler;
            }
        }

        [TestMethod]
        public void TestLogging()
        {
            try
            {
                using (this.appctx = ApplicationContext.Current.Instance)
                {
                    void handler(object obj, Exception exc) => Assert.Fail(exc.Message);
                    this.appctx.OnException += handler;

                    this.appctx.Log(Logging.Level.Debug, "DebugMessage");
                    this.appctx.Log(Logging.Level.Error, "ErrorMessage");
                    this.appctx.Log(Logging.Level.Fatal, "FatalMessage", new Exception("UnitTestException"));
                    this.appctx.Log(Logging.Level.Info, "InfoMessage");
                    this.appctx.Log(Logging.Level.Trace, "TraceMessage");
                    this.appctx.Log(Logging.Level.Warning, "WarningMessage");

                    this.appctx.OnException -= handler;
                }
            }
            catch (Exception exc)
            {
                Assert.Fail(exc.Message);
            }
        }

        
    }
}
