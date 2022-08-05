using EF_Api.External_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EF_Api.External_Api.Interface
{
    public interface IHolidaysApiService
    {
        Task<List<HolidayModel>> GetHolidays(string countryCode, int year);
    }
}
