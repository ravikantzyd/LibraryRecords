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
    public class RecordProcessor
    {
        public static async Task<List<RecordModel>> LoadRecords()
        {
            string url = "api/Record";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<RecordModel> Record = await response.Content.ReadAsAsync<List<RecordModel>>();

                    return Record;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<RecordModel>> LoadRecordsByDecending()
        {
            string url = "api/Record/RecordsByDecending";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<RecordModel> Record = await response.Content.ReadAsAsync<List<RecordModel>>();

                    return Record;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<RecordModel> LoadRecord(int Id)
        {
            string url = $"api/Record/RecordsById/{Id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    RecordModel Record = await response.Content.ReadAsAsync<RecordModel>();

                    return Record;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<RecordModel>> LoadRecordByBookId(int Id)
        {
            string url = $"api/Record/RecordsByBookId/{Id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<RecordModel> Record = await response.Content.ReadAsAsync<List<RecordModel>>();

                    return Record;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public static async Task<List<RecordModel>> LoadRecordByMemberId(int Id)
        {
            string url = $"api/Record/RecordsByMemberId/{Id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<RecordModel> Record = await response.Content.ReadAsAsync<List<RecordModel>>();

                    return Record;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public static async Task<List<RecordModel>> LoadRecordByRIDandBookName(string record_id,string book_name)
        {
            ViewByRIDandBookNameModel record_data = new ViewByRIDandBookNameModel
            {
                RecordId = record_id,
                BookName = book_name
            };

            string url = $"api/Record/ViewByRIDandBookName";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, record_data))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<RecordModel> Record = await response.Content.ReadAsAsync<List<RecordModel>>();

                    return Record;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<RecordModel>> LoadRecordByRID(string record_id)
        {
            ViewByRIDandBookNameModel record_data = new ViewByRIDandBookNameModel
            {
                RecordId = record_id,
                BookName = ""
            };

            string url = $"api/Record/ViewByRID";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, record_data))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<RecordModel> Record = await response.Content.ReadAsAsync<List<RecordModel>>();

                    return Record;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<RecordModel>> LoadRecordBySearch(string search_word)
        {
            SearchByRecordDataModel record = new SearchByRecordDataModel
            {
                RecordData = search_word
            };

            string url = $"api/Record/RecordsBySearch";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, record))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<RecordModel> Record = await response.Content.ReadAsAsync<List<RecordModel>>();

                    return Record;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<RecordModel> SetRecord(CreateRecordModel record)
        {
            string url = "api/Record";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, record))
            {
                if (response.IsSuccessStatusCode)
                {
                    RecordModel Record = await response.Content.ReadAsAsync<RecordModel>();

                    return Record;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task ModifyRecord(int id, UpdateRecordModel record)
        {
            string url = $"api/Record/{id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, record))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task DeleteRecord(int id)
        {
            string url = $"api/Record/{id}";

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
