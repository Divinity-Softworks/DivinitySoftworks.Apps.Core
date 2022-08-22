using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace DivinitySoftworks.Apps.Core.Converters {

    /// <summary>
    /// Converts a <seealso langword="bool"/> to a <seealso langword="string"/>.
    /// <para>
    /// To use this converter. Add <c>xmlns:converters="clr-namespace:DivinitySoftworks.Apps.Core.Converters;assembly=DivinitySoftworks.Apps.Core"</c> to the XAML file.
    /// </para>
    /// </summary>
    public class BooleanToStringConverter : MarkupExtension, IValueConverter {

        /// <summary>
        /// The <seealso langword="string"/> to use when the value is <seealso langword="true"/>.
        /// </summary>
        public string True { get; set; } = "Yes";

        /// <summary>
        /// The <seealso langword="string"/> to use when the value is <seealso langword="false"/>.
        /// </summary>
        public string False { get; set; } = "No";

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is not bool)
                return False;

            return ((bool)value) ? True : False;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}