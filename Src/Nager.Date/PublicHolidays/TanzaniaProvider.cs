using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Tanzania
    /// </summary>
    public class TanzaniaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// TanzaniaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public TanzaniaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.TZ;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var firstMondayInJuly = DateSystem.FindDay(year, 7, DayOfWeek.Monday, 1);
            var tuesdayFollowingFirstMondayInJuly = firstMondayInJuly.AddDays(1);
            var firstMondayInAugust = DateSystem.FindDay(year, 8, DayOfWeek.Monday, 2);

            var items = new List<PublicHoliday>();

            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 12, "Zanzibar Revolution Day", "Zanzibar Revolution Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 7, "Karume Day","Karume Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 4, 26, "Union Day", "Union Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));

            //26 June, Monday	Eid al-Fitr	Marks the end of the holy month of Ramadan
            items.Add(new PublicHoliday(year, 7, 7, "Saba Saba Day", "Saba Saba Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 8, "Nane Nane Day", "Nane Nane Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 14, "Nyerere Day", "Nyerere Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 1, "Maulid Day", "Maulid Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 9, "Independence Day", "Independence Day", countryCode));


            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Boxing Day", "Boxing Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Zambia"
            };
        }
    }
}
