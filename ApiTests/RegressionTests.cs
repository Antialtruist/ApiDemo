using ApiDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ApiTests
{
    [TestClass]
    public class RegressionTests
    {
        [TestMethod]
        public void VerifyUsers()
        {
            var demo = new Demo<UsersDto>();
            var user = demo.GetUsers("api/users?page=2");

            Assert.AreEqual(2, user.Page);
            Assert.AreEqual("Michael", user.Data[0].first_name);
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
