using System.Globalization;

namespace System {

    /// <summary>
    /// Extentions for the <seealso cref="DateTime"/> type.
    /// </summary>
    public static class DateTimeExtensions {
        /// <summary>
        /// Creates a greeting based on the <paramref name="dateTime"/>.
        /// <para>
        /// Good Morning
        /// <br/>05:00 - 11:59
        /// </para>
        /// <para>
        /// Good Afternoon
        /// <br/>12:00 - 16:59
        /// </para>
        /// <para>
        /// Good Evening
        /// <br/>17:00 - 04:59
        /// </para>
        /// </summary>
        /// <param name="dateTime">The <seealso cref="DateTime"/> to base a greeting on.</param>
        /// <returns>The greeting.</returns>
        public static string ToGreeting(this DateTime dateTime) {
            if (dateTime.Hour >= 5 && dateTime.Hour < 12)
                return "Good Morning";

            if (dateTime.Hour >= 12 && dateTime.Hour < 17)
                return "Good Afternoon";

            return "Good Evening";
        }

        /// <summary>
        /// Adds the proper suffix to a day. Like 1st, 2nd, 21st, etc. This expects the <seealso cref="CultureInfo"/> to be in English
        /// </summary>
        /// <param name="dateTime">The <seealso cref="DateTime"/> to base the day and suffix on.</param>
        /// <returns>The day with suffix, like 1st, 2nd, 21st, etc.</returns>
        public static string ToSuffixDate(this DateTime dateTime) {
            return dateTime.Day switch {
                1 or 21 or 31 => $"{dateTime.Day}st",
                2 or 22 => $"{dateTime.Day}nd",
                3 or 23 => $"{dateTime.Day}rd",
                _ => $"{dateTime.Day}th",
            };
        }

        /// <summary>
        /// Gets the number of the current week.
        /// </summary>
        /// <param name="dateTime">The <seealso cref="DateTime"/> to get the week number from.</param>
        /// <param name="dayOfWeek">The <seealso cref="DayOfWeek"/>.</param>
        /// <param name="calendarWeekRule">The <seealso cref="CalendarWeekRule"/>.</param>
        /// <returns>The week number of the given <seealso cref="DateTime"/>.</returns>
        public static int GetWeekNumber(this DateTime dateTime, DayOfWeek dayOfWeek = DayOfWeek.Sunday, CalendarWeekRule calendarWeekRule = CalendarWeekRule.FirstDay) {
            return CultureInfo.CurrentCulture.Calendar
                .GetWeekOfYear(dateTime, calendarWeekRule, dayOfWeek);
        }
    }
}