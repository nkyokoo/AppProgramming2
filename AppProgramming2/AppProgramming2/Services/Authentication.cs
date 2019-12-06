using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppProgramming2.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppProgramming2.Services
{
    public class Authentication
    {
        public async Task<Boolean> login(string email, string password)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://10.130.54.151:3333");

                JObject jsonData = new JObject();
                jsonData.Add("email", email);
                jsonData.Add("password", password);

                var content = new StringContent(jsonData.ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/user/login", content);

                var result = await response.Content.ReadAsStringAsync();
                var jo = JObject.Parse(result);

                string token = jo["data"]["token"].ToString();


                SecureStorage.SetAsync("auth_token", token).Wait();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<string> getUser(string token)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3333");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            
            HttpResponseMessage response = client.GetAsync("/user").Result;

            var result =  response.Content.ReadAsStringAsync().Result;

            return result;
        }   
    }
}