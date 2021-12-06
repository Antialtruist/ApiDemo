namespace ApiDemo
{
    public class Demo<T>
    {
        public UsersDto GetUsers(string endpoint)
        {
            var user = new ApiHelper<UsersDto>();
            var url = user.SetUrl(endpoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);
            UsersDto content = user.GetContent<UsersDto>(response);
            return content;
        }

        public CreateUserDto CreateUser(string endpoint, dynamic payload)
        {
            var user = new ApiHelper<CreateUserDto>();
            var url = user.SetUrl(endpoint);
            var request = user.CreatePostRequest(payload);
            var response = user.GetResponse(url, request);
            CreateUserDto content = user.GetContent<CreateUserDto>(response);
            return content;
        }
    }
}
