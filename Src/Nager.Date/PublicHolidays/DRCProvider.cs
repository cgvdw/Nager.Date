using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// DRC
    /// </summary>
    public class DRCProvider : IPublicHolidayProvider
    {
        

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.CD;

            var items = new List<PublicHoliday>();

            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 4, "Martyrs Day", "Martyrs Day", countryCode));
            items.Add(new PublicHoliday(year,5,1,"Labour Day","Labour Day",countryCode));
            items.Add(new PublicHoliday(year,5,17,"Liberation Day","Liberation Day",countryCode));
            items.Add(new PublicHoliday(year,6,30,"Independence Day","Independence Day",countryCode));
            items.Add(new PublicHoliday(year,8,1,"Parents' Day","Parents' Day",countryCode));
            items.Add(new PublicHoliday(year,11,17,"Army Day","Army Day",countryCode));
            items.Add(new PublicHoliday(year,12,25,"Christmas Day","Christmas Day",countryCode));
            items.Add(new PublicHoliday(year,12,25,"Saint Paul's Day","Saint Paul's Day",countryCode));

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
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Democratic_Republic_of_the_Congo"
            };
        }
    }
}
