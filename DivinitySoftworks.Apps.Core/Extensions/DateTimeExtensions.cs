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
    }
}