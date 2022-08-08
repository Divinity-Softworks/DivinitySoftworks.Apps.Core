using System.Windows;
using System.Windows.Controls;

namespace DivinitySoftworks.Apps.Core.Components.Base {
    /// <inheritdoc/>
    public class DateTimeLabel : Label {

        /// <summary>
        /// Gets or sets a <seealso cref="System.Windows.Controls.CharacterCasing"/> enumerated value that indicates the capital form of the selected font.
        /// </summary>
        public CharacterCasing CharacterCasing {
            get { return (CharacterCasing)GetValue(CharacterCasingProperty); }
            set { SetValue(CharacterCasingProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="CharacterCasing"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CharacterCasingProperty = DependencyProperty.Register(nameof(CharacterCasing), typeof(CharacterCasing), typeof(DateTimeLabel), new PropertyMetadata(CharacterCasing.Normal));
    }
}
