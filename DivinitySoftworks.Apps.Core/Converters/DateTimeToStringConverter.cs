using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace DivinitySoftworks.Apps.Core.Converters {

    /// <summary>
    /// Converts a <seealso cref="DateTime"/> to a <seealso langword="string"/>.
    /// <para>
    /// To use this converter. Add <c>xmlns:converters="clr-namespace:DivinitySoftworks.Apps.Core.Converters;assembly=DivinitySoftworks.Apps.Core"</c> to the XAML file.
    /// </para>
    /// </summary>
    public class DateTimeToStringConverter : MarkupExtension, IValueConverter {

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is not DateTime dateTime)
                return DependencyProperty.UnsetValue;

            return dateTime.ToString("dddd, MMMM 'SUFFIX', yyyy", new CultureInfo("en-GB")).Replace("SUFFIX", dateTime.ToSuffixDate());
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
