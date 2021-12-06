using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDemo
{
    public class Demo
    {
        public UsersDto GetUsers()
        {
            var restClient = new RestClient("https://reqres.in");
            var restRequest = new RestRequest("/api/users?page=2", Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;

            var users = JsonConvert.DeserializeObject<UsersDto>(content);
            return users;
        }

        //public CreateUserDto CreateUser()
        //{
        //    var restClient = new RestClient("https://reqres.in");
        //    var restRequest = new RestRequest("/api/users?page=2", Method.GET);
        //    restRequest.AddHeader("Accept", "application/json");
        //    restRequest.RequestFormat = DataFormat.Json;

        //    IRestResponse response = restClient.Execute(restRequest);
        //    var content = response.Content;

        //    var users = JsonConvert.DeserializeObject<UsersDto>(content);
        //    return users;
        //}
    }
}
