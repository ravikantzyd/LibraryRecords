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
    public class BookProcessor
    {
        public static async Task<List<BookModel>> LoadBooks()
        {
            string url = "api/Book";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<BookModel> Book = await response.Content.ReadAsAsync<List<BookModel>>();

                    return Book;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<BookModel>> LoadBooksByDecending()
        {
            string url = "api/Book/BooksByDecending";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<BookModel> Book = await response.Content.ReadAsAsync<List<BookModel>>();

                    return Book;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<BookModel> LoadBook(int Id)
        {
            string url = $"api/Book/BooksById/{Id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    BookModel Book = await response.Content.ReadAsAsync<BookModel>();

                    return Book;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public static async Task<BookModel> LoadBookByName(string book_name)
        {
            ViewByBookNameModel book = new ViewByBookNameModel
            {
                BookName = book_name
            };

            string url = $"api/Book/BooksByName";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, book))
            {
                if (response.IsSuccessStatusCode)
                {
                    BookModel Book = await response.Content.ReadAsAsync<BookModel>();

                    return Book;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<BookModel>> LoadBookBySearch(string search_word)
        {
            SearchByBookDataModel member = new SearchByBookDataModel
            {
                BookData = search_word
            };

            string url = $"api/Book/BooksBySearch";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, member))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<BookModel> Book = await response.Content.ReadAsAsync<List<BookModel>>();

                    return Book;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<BookModel> LoadBookByBookId(string book_id)
        {
            ViewByBookIdModel book = new ViewByBookIdModel
            {
                BookId = book_id
            };

            string url = $"api/Book/BooksByBookId";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, book))
            {
                if (response.IsSuccessStatusCode)
                {
                    BookModel Book = await response.Content.ReadAsAsync<BookModel>();

                    return Book;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<BookModel>> LoadBookByCategoryId(int category_id)
        {
            ViewByCategoryIdModel book = new ViewByCategoryIdModel
            {
                CategoryId = category_id
            };

            string url = $"api/Book/BooksByCategoryId";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, book))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<BookModel> Book = await response.Content.ReadAsAsync<List<BookModel>>();

                    return Book;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        public static async Task<BookModel> SetBook(CreateBookModel book)
        {
            string url = "api/Book";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, book))
            {
                if (response.IsSuccessStatusCode)
                {
                    BookModel Book = await response.Content.ReadAsAsync<BookModel>();

                    return Book;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task ModifyBook(int id, UpdateBookModel book)
        {
            string url = $"api/Book/{id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, book))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task DeleteBook(int id)
        {
            string url = $"api/Book/{id}";

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
