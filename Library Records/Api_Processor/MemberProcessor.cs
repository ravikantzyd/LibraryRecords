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
    public class MemberProcessor
    {
        public static async Task<List<MemberModel>> LoadMembers()
        {
            string url = "api/Member";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<MemberModel> Member = await response.Content.ReadAsAsync<List<MemberModel>>();

                    return Member;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<MemberModel>> LoadMembersByDecending()
        {
            string url = "api/Member/MembersByDecending";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<MemberModel> Member = await response.Content.ReadAsAsync<List<MemberModel>>();

                    return Member;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<MemberModel> LoadMember(int Id)
        {
            string url = $"api/Member/MembersById/{Id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    MemberModel Member = await response.Content.ReadAsAsync<MemberModel>();

                    return Member;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public static async Task<MemberModel> LoadMemberByName(string member_name)
        {
            ViewByMemberNameModel member = new ViewByMemberNameModel
            {
                MemberName = member_name
            };

            string url = $"api/Member/MembersByName";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, member))
            {
                if (response.IsSuccessStatusCode)
                {
                    MemberModel Member = await response.Content.ReadAsAsync<MemberModel>();

                    return Member;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<MemberModel>> LoadMemberBySearch(string search_word)
        {
            SearchByMemberDataModel member = new SearchByMemberDataModel
            {
                MemberData = search_word
            };

            string url = $"api/Member/MembersBySearch";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, member))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<MemberModel> Member = await response.Content.ReadAsAsync<List<MemberModel>>();

                    return Member;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<MemberModel> LoadMemberByMemberId(string member_id)
        {
            ViewByMemberIdModel member = new ViewByMemberIdModel
            {
                MemberId = member_id
            };

            string url = $"api/Member/MembersByMemberId";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, member))
            {
                if (response.IsSuccessStatusCode)
                {
                    MemberModel Member = await response.Content.ReadAsAsync<MemberModel>();

                    return Member;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<MemberModel> SetMember(CreateMemberModel user)
        {
            string url = "api/Member";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, user))
            {
                if (response.IsSuccessStatusCode)
                {
                    MemberModel Member = await response.Content.ReadAsAsync<MemberModel>();

                    return Member;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task ModifyMember(int id, UpdateMemberModel user)
        {
            string url = $"api/Member/{id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(url, user))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task DeleteMember(int id)
        {
            string url = $"api/Member/{id}";

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
