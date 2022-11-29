using Library_Records.Api_Common_Methods;
using Library_Records.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library_Records.Api_Processor
{
    public class UserProcessor
    {
        public static async Task<List<UserModel>> LoadUsers()
        {
            string url = "api/Users";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<UserModel> User = await response.Content.ReadAsAsync<List<UserModel>>();

                    return User;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<UserModel>> LoadUsersByDecending()
        {
            string url = "api/Users/UsersByDecending";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<UserModel> User = await response.Content.ReadAsAsync<List<UserModel>>();

                    return User;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<UserModel> LoadUser(int Id)
        {
            string url = $"api/Users/UsersById/{Id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    UserModel User = await response.Content.ReadAsAsync<UserModel>();

                    return User;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public static async Task<UserModel> LoadUserByName(string user_name)
        {
            ViewByUserNameModel user = new ViewByUserNameModel
            {
                UserName = user_name
            };

            string url = $"api/Users/UsersByName";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, user))
            {
                if (response.IsSuccessStatusCode)
                {
                    UserModel User = await response.Content.ReadAsAsync<UserModel>();

                    return User;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<UserModel> SetUser(CreateUserModel user)
        {
            string url = "api/Users";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, user))
            {
                if (response.IsSuccessStatusCode)
                {
                    UserModel User = await response.Content.ReadAsAsync<UserModel>();

                    return User;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task ModifyUser(int id, UpdateUserModel user)
        {
            string url = $"api/Users/{id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, user))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task DeleteUser(int id)
        {
            string url = $"api/Users/{id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(url))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
