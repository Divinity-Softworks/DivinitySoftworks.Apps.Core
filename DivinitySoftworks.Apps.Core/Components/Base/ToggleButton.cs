using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DivinitySoftworks.Apps.Core.Components.Base {
    /// <inheritdoc/>
    public class ToggleButton : Button {

        /// <summary>
        /// Gets or sets whether the <see cref="ToggleButton"/> is toggled.
        /// </summary>
        public bool IsToggled {
            get { return (bool)GetValue(IsToggledProperty); }
            set { SetValue(IsToggledProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="IsToggled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsToggledProperty = DependencyProperty.Register(nameof(IsToggled), typeof(bool), typeof(ToggleButton), new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets a brush that describes the toggled of a <see cref="ToggleButton"/>.
        /// </summary>
        public Brush Toggled {
            get { return (Brush)GetValue(ToggledProperty); }
            set { SetValue(ToggledProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Toggled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ToggledProperty = DependencyProperty.Register(nameof(Toggled), typeof(Brush), typeof(ToggleButton), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        /// <summary>
        /// Gets or sets a value that represents the degree to which the corners of a <see cref="ToggleButton"/> are rounded.
        /// </summary>
        public CornerRadius CornerRadius {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="CornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ToggleButton), new PropertyMetadata(new CornerRadius(0)));

        /// <summary>
        /// Gets or sets the value related to the <see cref="ToggleButton"/>.
        /// </summary>
        public object Value {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Value"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(object), typeof(ToggleButton), new PropertyMetadata(null));
    }
}
