using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace DivinitySoftworks.Apps.Core.Converters {

    /// <summary>
    /// Converts an <seealso cref="Enum"/> to <seealso langword="bool"/>.
    /// <para>
    /// To use this converter. Add <c>xmlns:converters="clr-namespace:DivinitySoftworks.Apps.Core.Converters;assembly=DivinitySoftworks.Apps.Core"</c> to the XAML file.
    /// </para>
    /// </summary>
    public class EnumToBooleanConverter : MarkupExtension, IValueConverter {

        /// <summary>
        /// The <seealso cref="Enum"/> the value should be.
        /// </summary>
        public Enum? True { get; set; }

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (True is null) throw new NullReferenceException(nameof(True));

            if (value is not null && value.GetType().IsEnum)
                return Equals(value, True);
            else
                return DependencyProperty.UnsetValue;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (True is null) throw new NullReferenceException(nameof(True));

            if (value is not null && value is bool boolean && boolean)
                return True;
            else
                return DependencyProperty.UnsetValue;
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}
