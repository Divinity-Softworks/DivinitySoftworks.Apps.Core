using System;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Controls;


namespace DivinitySoftworks.Apps.Core.Components {
    /// <summary>
    /// Creates a label with a greeting based on the current time.
    /// <para>
    /// Good Morning
    /// <br/>05:00 - 11:59
    /// </para>
    /// <para>
    /// Good Afternoon
    /// <br/>12:00 - 16:59
    /// </para>
    /// <para>
    /// Good Evening
    /// <br/>17:00 - 04:59
    /// </para>
    /// <para>
    /// To use this component. Add <c>xmlns:components="clr-namespace:DivinitySoftworks.Apps.Core.Components;assembly=DivinitySoftworks.Apps.Core"</c> to the XAML file.
    /// </para>
    /// </summary>
    public partial class DateTimeLabel : DateTimeLabelBase {
        private readonly Timer _timer;

        /// <summary>
        /// Creates a label with a greeting based on the current time.
        /// <para>
        /// Good Morning
        /// <br/>05:00 - 11:59
        /// </para>
        /// <para>
        /// Good Afternoon
        /// <br/>12:00 - 16:59
        /// </para>
        /// <para>
        /// Good Evening
        /// <br/>17:00 - 04:59
        /// </para>
        /// <para>
        /// To use this component. Add <c>xmlns:components="clr-namespace:DivinitySoftworks.Apps.Core.Components;assembly=DivinitySoftworks.Apps.Core"</c> to the XAML file.
        /// </para>
        /// </summary>
        public DateTimeLabel() {
            InitializeComponent();

            _timer = new Timer(1);
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e) {
            if (sender is null) return;
            
            if (_timer.Interval != 1 && e.SignalTime.Second != 0) return;
            if (_timer.Interval != 500)
                _timer.Interval = 500;

            Dispatcher.Invoke(() => {
                _timer.Stop();
                _timer.Start();

                switch (CharacterCasing) {
                    case CharacterCasing.Lower:
                        Content = DateTime.Now.ToGreeting().ToLower();
                        break;
                    case CharacterCasing.Upper:
                        Content = DateTime.Now.ToGreeting().ToUpper();
                        break;
                    default:
                        Content = DateTime.Now.ToGreeting();
                        break;
                }
            });

        }
    }

    /// <inheritdoc/>
    public class DateTimeLabelBase : Label {

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