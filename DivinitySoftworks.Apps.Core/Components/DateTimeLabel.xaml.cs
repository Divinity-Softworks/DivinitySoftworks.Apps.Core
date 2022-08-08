using System;
using System.Timers;
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
    public partial class DateTimeLabel : Base.DateTimeLabel {
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

                Content = CharacterCasing switch {
                    CharacterCasing.Lower => DateTime.Now.ToGreeting().ToLower(),
                    CharacterCasing.Upper => DateTime.Now.ToGreeting().ToUpper(),
                    _ => DateTime.Now.ToGreeting(),
                };
            });

        }
    }
}