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
    public class SecurityQuestionProcessor
    {
        public static async Task<List<SecurityQuestionModel>> LoadSecurityQuestions()
        {
            string url = "api/SecurityQuestions";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<SecurityQuestionModel> SecurityQuestion = await response.Content.ReadAsAsync<List<SecurityQuestionModel>>();

                    return SecurityQuestion;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<SecurityQuestionModel>> LoadSecurityQuestionsByDecending()
        {
            string url = "api/SecurityQuestions/SecurityQuestionsByDecending";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<SecurityQuestionModel> SecurityQuestion = await response.Content.ReadAsAsync<List<SecurityQuestionModel>>();

                    return SecurityQuestion;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<SecurityQuestionModel> LoadSecurityQuestion(int Id)
        {
            string url = $"api/SecurityQuestions/SecurityQuestionsById/{Id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SecurityQuestionModel SecurityQuestion = await response.Content.ReadAsAsync<SecurityQuestionModel>();

                    return SecurityQuestion;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public static async Task<List<SecurityQuestionModel>> LoadSecurityQuestionsByUserId(int Id)
        {
            string url = $"api/SecurityQuestions/SecurityQuestionsByUserId/{Id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<SecurityQuestionModel> SecurityQuestion = await response.Content.ReadAsAsync<List<SecurityQuestionModel>>();

                    return SecurityQuestion;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<SecurityQuestionModel> LoadSecurityQuestionByName(string question)
        {
            ViewBySecurityQuestionModel question_model = new ViewBySecurityQuestionModel
            {
                Question = question
            };

            string url = $"api/SecurityQuestions/SecurityQuestionsByName";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, question_model))
            {
                if (response.IsSuccessStatusCode)
                {
                    SecurityQuestionModel SecurityQuestion = await response.Content.ReadAsAsync<SecurityQuestionModel>();

                    return SecurityQuestion;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<SecurityQuestionModel> SetSecurityQuestion(CreateSecurityQuestionModel question)
        {
            string url = "api/SecurityQuestions";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, question))
            {
                if (response.IsSuccessStatusCode)
                {
                    SecurityQuestionModel SecurityQuestion = await response.Content.ReadAsAsync<SecurityQuestionModel>();

                    return SecurityQuestion;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task ModifySecurityQuestion(int id, UpdateSecurityQuestionModel question)
        {
            string url = $"api/SecurityQuestions/{id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, question))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task DeleteSecurityQuestion(int id)
        {
            string url = $"api/SecurityQuestions/{id}";

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
