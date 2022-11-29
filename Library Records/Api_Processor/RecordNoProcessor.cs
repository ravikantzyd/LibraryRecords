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
    public class RecordNoProcessor
    {
        public static async Task<List<RecordNoModel>> LoadRecordNos()
        {
            string url = "api/RecordNo";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<RecordNoModel> RecordNos = await response.Content.ReadAsAsync<List<RecordNoModel>>();

                    return RecordNos;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<RecordNoModel>> LoadRecordNosByDate(string date)
        {
            ViewRecordNoByDateModel voucher_no = new ViewRecordNoByDateModel
            {
                Date = date
            };

            string url = $"api/RecordNo/RecordNosByDate";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, voucher_no))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<RecordNoModel> RecordNos = await response.Content.ReadAsAsync<List<RecordNoModel>>();

                    return RecordNos;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<RecordNoModel> SetRecordNo(CreateRecordNoModel voucherNo)
        {
            string url = "api/RecordNo";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, voucherNo))
            {
                if (response.IsSuccessStatusCode)
                {
                    RecordNoModel RecordNos = await response.Content.ReadAsAsync<RecordNoModel>();

                    return RecordNos;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
