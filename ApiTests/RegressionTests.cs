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
            var demo = new Demo();
            var response = demo.GetUsers();
            Assert.AreEqual(2, response.Page);
            Assert.AreEqual("Michael", response.Data[0].first_name);
        }

        [TestMethod]
        public void CreateNewUser()
        {
            string payload = @"{
                                ""name"": ""John Snow"",
                                ""job"": ""Dark Knight""
                               }";
            var user = new ApiHelper<CreateUserDto>();
            var url = user.SetUrl("api/users");
            var request = user.CreatePostRequest(payload);
            var response = user.GetResponse(url, request);
            CreateUserDto content = user.GetContent<CreateUserDto>(response);

            Assert.AreEqual("John Snow", content.Name);
            Assert.AreEqual("Dark Knight", content.Job);
        }
    }
}
