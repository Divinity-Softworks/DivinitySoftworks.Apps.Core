using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DivinitySoftworks.Apps.Core.Components.Base {
    /// <inheritdoc/>
    public class MenuItem : Button {

        /// <summary>
        /// Gets or sets whether the <see cref="MenuItem"/> is selected.
        /// </summary>
        public bool IsSelected {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="IsSelected"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(nameof(IsSelected), typeof(bool), typeof(MenuItem), new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets a brush that describes the selected of a <see cref="MenuItem"/>.
        /// </summary>
        public Brush Selected {
            get { return (Brush)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Brush"/> dependency property.
        /// </summary>

        public static readonly DependencyProperty SelectedProperty = DependencyProperty.Register(nameof(Selected), typeof(Brush), typeof(MenuItem), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        /// <summary>
        /// Gets or sets the icon of the <see cref="MenuItem"/>.
        /// </summary>
        public Geometry Icon {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Icon"/> dependency property.
        /// </summary>

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(Geometry), typeof(MenuItem));

        /// <summary>
        /// Gets or sets the target of the <see cref="MenuItem"/>.
        /// </summary>
        public Type Target {
            get { return (Type)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Target"/> dependency property.
        /// </summary>

        public static readonly DependencyProperty TargetProperty = DependencyProperty.Register(nameof(Target), typeof(Type), typeof(MenuItem));
    }
}
