using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Zambia
    /// </summary>
    public class ZambiaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// ZambiaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ZambiaProvider(ICatholicProvider catholicProvider)
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
            var countryCode = CountryCode.ZM;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var firstMondayInJuly = DateSystem.FindDay(year,7,DayOfWeek.Monday,1);
            var tuesdayFollowingFirstMondayInJuly = firstMondayInJuly.AddDays(1);
            var firstMondayInAugust = DateSystem.FindDay(year, 8, DayOfWeek.Monday, 2);

            var items = new List<PublicHoliday>();

            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year,3,8,"International Women's Day","International Women's Day",countryCode));
            items.Add(new PublicHoliday(year,3,12,"Youth Day","Youth Day",countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-1), "Holy Saturday", "Holy Saturday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year,5,1,"Labour Day","Labour Day",countryCode));
            items.Add(new PublicHoliday(year, 5, 25, "Africa Day", "Africa Day", countryCode));
            items.Add(new PublicHoliday(firstMondayInJuly,"Heroes' Day","Heroes' Day",countryCode));
            items.Add(new PublicHoliday(tuesdayFollowingFirstMondayInJuly,"Unity Day","Unity Day",countryCode));
            items.Add(new PublicHoliday(firstMondayInAugust, "Farmers Day", "Farmers Day", countryCode));
            items.Add(new PublicHoliday(year,10,18,"National Prayer Day","National Prayer Day",countryCode));
            items.Add(new PublicHoliday(year,10,24,"Independence Day","Independence Day",countryCode));
            items.Add(new PublicHoliday(year,12,25,"Christmas Day","Christmas Day",countryCode));

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
