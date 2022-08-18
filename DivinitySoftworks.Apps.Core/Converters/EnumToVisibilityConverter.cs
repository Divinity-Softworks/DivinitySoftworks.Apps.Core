using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace DivinitySoftworks.Apps.Core.Converters {

    /// <summary>
    /// Converts an <seealso cref="Enum"/> to a <seealso langword="bool"/>.
    /// <para>
    /// To use this converter. Add <c>xmlns:converters="clr-namespace:DivinitySoftworks.Apps.Core.Converters;assembly=DivinitySoftworks.Apps.Core"</c> to the XAML file.
    /// </para>
    /// </summary>
    public class EnumToVisibilityConverter : MarkupExtension, IValueConverter {

        /// <summary>
        /// The <seealso cref="Enum"/> the value should be to be <seealso cref="Visibility.Visible"/>.
        /// </summary>
        public Enum? Visible { get; set; }

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (Visible is null) throw new NullReferenceException(nameof(Visible));

            if (value is not null && value.GetType().IsEnum)
                return Equals(value, Visible) ? Visibility.Visible : Visibility.Collapsed;
            else
                return DependencyProperty.UnsetValue;
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

