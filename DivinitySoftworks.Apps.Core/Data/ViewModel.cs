using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DivinitySoftworks.Apps.Core.Data {

    /// <summary>
    /// A viewmodel that implements <seealso cref="INotifyPropertyChanged"/>. Can be used for data that should be bind to a <seealso cref="Window"/>, <seealso cref="Page"/>, or <seealso cref="UserControl"/>.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged {
        /// <summary>
        /// Represents the method that will handle the System.ComponentModel.INotifyPropertyChanged.PropertyChanged event raised when a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The property with <paramref name="propertyName"/> has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Notify that the property with <paramref name="propertyName"/> has changed. Also notify that any of the <paramref name="additionalProperties"/> have changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        /// <param name="additionalProperties">The name(s) of additional properties that have also changed.</param>
        public void Notify([CallerMemberName] string? propertyName = null, params string[] additionalProperties) {
            OnPropertyChanged(propertyName);
            foreach (string p in additionalProperties)
                OnPropertyChanged(p);
        }

        /// <summary>
        /// Change the value of the <paramref name="field"/> with the new <paramref name="value"/>. Notify that the property with <paramref name="propertyName"/> has changed. Also notify that any of the <paramref name="additionalProperties"/> have changed.
        /// </summary>
        /// <typeparam name="T">The type of the property that should be changed.</typeparam>
        /// <param name="field">The field to update the value of.</param>
        /// <param name="value">The new value.</param>
        /// <param name="propertyName">The name of the property that has changed.</param>
        /// <param name="additionalProperties">The name(s) of additional properties that have also changed.</param>
        /// <returns>If the change was successful.</returns>
        public bool ChangeAndNotify<T>(ref T field, T value, [CallerMemberName] string? propertyName = null, params string[] additionalProperties) {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            if (comparer.Equals(field, value) == false) {
                field = value;
                OnPropertyChanged(propertyName);
                foreach (string p in additionalProperties)
                    OnPropertyChanged(p);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Change the value of the <paramref name="field"/> with the new <paramref name="value"/>. Notify that the property with <paramref name="propertyName"/> has changed. Also notify that any of the <paramref name="additionalProperties"/> have changed.
        /// </summary>
        /// <typeparam name="T">The type of the property that should be changed.</typeparam>
        /// <param name="field">The field to update the value of.</param>
        /// <param name="value">The new value.</param>
        /// <param name="action">The action that should be called when the change was successful.</param>
        /// <param name="propertyName">The name of the property that has changed.</param>
        /// <param name="additionalProperties">The name(s) of additional properties that have also changed.</param>
        /// <returns>If the change was successful.</returns>
        public bool ChangeAndNotifyWithAction<T>(ref T field, T value, Action action, [CallerMemberName] string? propertyName = null, params string[] additionalProperties) {
            bool changed = ChangeAndNotify(ref field, value, propertyName, additionalProperties);
            if (changed)
                action();
            return changed;
        }
    }
}
