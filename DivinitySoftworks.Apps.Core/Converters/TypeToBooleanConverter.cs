using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace DivinitySoftworks.Apps.Core.Converters {

    /// <summary>
    /// Converts a <seealso cref="Type"/> to a <seealso langword="bool"/>.
    /// <para>
    /// To use this converter. Add <c>xmlns:converters="clr-namespace:DivinitySoftworks.Apps.Core.Converters;assembly=DivinitySoftworks.Apps.Core"</c> to the XAML file.
    /// </para>
    /// </summary>
    public class TypeToBooleanConverter : MarkupExtension, IValueConverter {

        /// <summary>
        /// The <seealso cref="Type"/> the value should be.
        /// </summary>
        public Type? Type { get; set; }

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (Type is null) throw new NullReferenceException(nameof(Type));
            return value.GetType() == Type;
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
