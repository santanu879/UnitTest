using EF_Api.External_Api.Interface;
using EF_Api.External_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System;

using System.Text.Json;

namespace EF_Api.External_Api
{
    public class HolidaysApiService : IHolidaysApiService
    {
        private  readonly HttpClient client;
        public HolidaysApiService(IHttpClientFactory httpClientFactory)
        {
            client= httpClientFactory.CreateClient("PublicHolidaysApi");
        }
        public async Task<List<HolidayModel>> GetHolidays(string countryCode, int year)
        {
            var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", year, countryCode);
            var result = new List<HolidayModel>();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<HolidayModel>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
