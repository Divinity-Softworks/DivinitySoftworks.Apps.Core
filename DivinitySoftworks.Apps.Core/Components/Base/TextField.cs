using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DivinitySoftworks.Apps.Core.Components.Base {
    /// <inheritdoc/>
    public class TextField : TextBox {

        /// <summary>
        /// Gets or sets the placeholder of the <see cref="TextField"/>.
        /// </summary>
        public string Placeholder {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Placeholder"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(TextField), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets a brush that describes the placeholder of a <see cref="TextField"/>.
        /// </summary>
        public Brush PlaceholderBrush {
            get { return (Brush)GetValue(PlaceholderBrushProperty); }
            set { SetValue(PlaceholderBrushProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="PlaceholderBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PlaceholderBrushProperty = DependencyProperty.Register(nameof(PlaceholderBrush), typeof(Brush), typeof(TextField), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        /// <summary>
        /// Gets or sets a brush that describes the focus of a <see cref="TextField"/>.
        /// </summary>
        public Brush FocusBrush {
            get { return (Brush)GetValue(FocusBrushProperty); }
            set { SetValue(FocusBrushProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="FocusBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty FocusBrushProperty = DependencyProperty.Register(nameof(FocusBrush), typeof(Brush), typeof(TextField), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        /// <summary>
        /// Gets or sets the icon of the <see cref="TextField"/>.
        /// </summary>
        public Geometry Icon {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Icon"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(Geometry), typeof(TextField), new PropertyMetadata(null));
    }
}
