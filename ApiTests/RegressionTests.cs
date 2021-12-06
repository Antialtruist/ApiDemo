using ApiDemo;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiTests
{
    [TestClass]
    public class RegressionTests
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            var dir = testContext.TestRunDirectory;
            Reporter.SetupExtentReport("API Regression Test", "API Regression Test Report", dir);
        }

        [TestInitialize]
        public void SetupTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status logStatus;

            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    logStatus = Status.Fail;
                    Reporter.TestStatus(logStatus.ToString());
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;
            }
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            Reporter.FlushReport();
        }

        [TestMethod]
        public void VerifyUsers()
        {
            var demo = new Demo<UsersDto>();
            var user = demo.GetUsers("api/users?page=2");

            Assert.AreEqual(2, user.Page);
            Reporter.LogToReport(Status.Fail, "Page number doesn't match");

            Assert.AreEqual("Michael", user.Data[0].first_name);
            Reporter.LogToReport(Status.Fail, "User first name doesn't match");
        }

        [TestMethod]
        public void CreateNewUser()
        {
            string payload = @"{
                                ""name"": ""John Snow"",
                                ""job"": ""Dark Knight""
                               }";
            var demo = new Demo<CreateUserDto>();
            var user = demo.CreateUser("api/users", payload);

            Assert.AreEqual("John Snow", user.Name);
            Assert.AreEqual("Dark Knight", user.Job);
        }
    }
}
