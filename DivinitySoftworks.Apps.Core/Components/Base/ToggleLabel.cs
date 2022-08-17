using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DivinitySoftworks.Apps.Core.Components.Base {
    /// <inheritdoc/>
    public class ToggleLabel : Label {
        Brush _cacheBrush = Brushes.White;

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
        public static readonly DependencyProperty IsToggledProperty = DependencyProperty.Register(nameof(IsToggled), typeof(bool), typeof(ToggleLabel), new PropertyMetadata(false, new PropertyChangedCallback(ChangeIsToggled)));

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
        public static readonly DependencyProperty ToggledProperty = DependencyProperty.Register(nameof(Toggled), typeof(Brush), typeof(ToggleLabel), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        /// <summary>
        /// The callback that is invoked when the <see cref="IsToggled"/> property value changes.
        /// </summary>
        /// <param name="d">The <seealso cref="DependencyObject"/> on which the property has changed value.</param>
        /// <param name="e">Event data that is issued by any event that tracks changes to the effective value of this property.</param>
        private static void ChangeIsToggled(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is not ToggleLabel toggleLabel) return;
            if((bool)e.NewValue)
                toggleLabel._cacheBrush = toggleLabel.Foreground;

            toggleLabel.Foreground = (bool)e.NewValue ? toggleLabel.Toggled : toggleLabel._cacheBrush;
        }
    }
}