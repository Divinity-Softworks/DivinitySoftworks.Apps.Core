using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace DivinitySoftworks.Apps.Core.Converters {

    /// <summary>
    /// Converts a <seealso langword="bool"/> to a <seealso cref="Brush"/>.
    /// <para>
    /// To use this converter. Add <c>xmlns:converters="clr-namespace:DivinitySoftworks.Apps.Core.Converters;assembly=DivinitySoftworks.Apps.Core"</c> to the XAML file.
    /// </para>
    /// </summary>
    public class BooleanToBrushConverter : MarkupExtension, IValueConverter {

        /// <summary>
        /// The <seealso cref="Brush"/> to use when the value is <seealso langword="true"/>.
        /// </summary>
        public Brush True { get; set; } = Brushes.Black;

        /// <summary>
        /// The <seealso cref="Brush"/> to use when the value is <seealso langword="false"/>.
        /// </summary>
        public Brush False { get; set; } = Brushes.White;

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
