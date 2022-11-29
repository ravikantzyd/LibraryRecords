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
    public class CategoryProcessor
    {
        public static async Task<List<CategoryModel>> LoadCategories()
        {
            string url = "api/Category";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<CategoryModel> Category = await response.Content.ReadAsAsync<List<CategoryModel>>();

                    return Category;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<CategoryModel>> LoadCategoriesByDecending()
        {
            string url = "api/Category/CategoriesByDecending";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<CategoryModel> Category = await response.Content.ReadAsAsync<List<CategoryModel>>();

                    return Category;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<CategoryModel> LoadCategory(int Id)
        {
            string url = $"api/Category/CategoriesById/{Id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    CategoryModel Category = await response.Content.ReadAsAsync<CategoryModel>();

                    return Category;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public static async Task<CategoryModel> LoadCategoryByName(string category_name)
        {
            ViewByCategoryNameModel category = new ViewByCategoryNameModel
            {
                CategoryName = category_name
            };

            string url = $"api/Category/CategoriesByName";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, category))
            {
                if (response.IsSuccessStatusCode)
                {
                    CategoryModel Category = await response.Content.ReadAsAsync<CategoryModel>();

                    return Category;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        
        public static async Task<CategoryModel> SetCategory(CreateCategoryModel category)
        {
            string url = "api/Category";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, category))
            {
                if (response.IsSuccessStatusCode)
                {
                    CategoryModel Category = await response.Content.ReadAsAsync<CategoryModel>();

                    return Category;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task ModifyCategory(int id, UpdateCategoryModel category)
        {
            string url = $"api/Category/{id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, category))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task DeleteCategory(int id)
        {
            string url = $"api/Category/{id}";

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
