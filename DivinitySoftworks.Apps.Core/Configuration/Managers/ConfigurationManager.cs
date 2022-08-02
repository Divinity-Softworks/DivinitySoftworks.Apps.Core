using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Threading.Tasks;

namespace DivinitySoftworks.Apps.Core.Configuration.Managers {

    /// <summary>
    /// Manages application configuration.
    /// </summary>
    public interface IConfigurationManager {
        /// <summary>
        /// The configuration of the application has changed.
        /// </summary>
        event EventHandler<ConfigurationChangedEventArgs>? OnConfigurationChanged;
        /// <summary>
        /// Get the setting from the user-specific configuration.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="key">The configuration key.</param>
        /// <returns>The value of the <paramref name="key"/> if found.</returns>
        ValueTask<T?> GetUserSettingAsync<T>(string key);
        /// <summary>
        /// Set the setting in the user-specific configuration.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="key">The configuration key.</param>
        /// <param name="value">The value to save for the <paramref name="key"/>.</param>
        ValueTask SetUserSettingAsync<T>(string key, T value);
    }

    /// <summary>
    /// Manages application configuration.
    /// </summary>
    public class ConfigurationManager : IConfigurationManager {
        /// <summary>
        /// The base directory inside the configuration directory.
        /// </summary>
        protected string _directory = "Settings";

        Dictionary<string, object>? _userSettings;

        /// <inheritdoc/>
        public event EventHandler<ConfigurationChangedEventArgs>? OnConfigurationChanged;

        /// <inheritdoc/>
        public async ValueTask<T?> GetUserSettingAsync<T>(string key) {
            if (_userSettings is null || !_userSettings.ContainsKey(key))
                await LoadUserSettingsAsync();

            if (_userSettings is null || !_userSettings.ContainsKey(key))
                return default;

            if (_userSettings[key] is T value)
                return value;

            try {
                return (T)Convert.ChangeType(_userSettings[key], typeof(T));
            }
            catch (InvalidCastException) {
                return default;
            }
        }

        /// <inheritdoc/>
        public async ValueTask SetUserSettingAsync<T>(string key, T value) {
            if (_userSettings is null || !_userSettings.ContainsKey(key))
                await LoadUserSettingsAsync();

            if (_userSettings is null)
                _userSettings = new Dictionary<string, object>();

            if (value is null)
                throw new NullReferenceException(nameof(value));

            if (_userSettings.ContainsKey(key)) {
                _userSettings[key] = value;
                await SaveUserSettingsAsync();

                OnConfigurationChanged?.Invoke(this, new ConfigurationChangedEventArgs(key));

                return;
            }

            _userSettings.Add(key, value);
            await SaveUserSettingsAsync();

            OnConfigurationChanged?.Invoke(this, new ConfigurationChangedEventArgs(key));

            return;
        }

        private async Task LoadUserSettingsAsync() {
            using IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
            isolatedStorageFile.CreateDirectory(_directory);
            if (!isolatedStorageFile.FileExists($@"{_directory}\User.cfg")) {
                await SaveUserSettingsAsync();
                return;
            }

            using IsolatedStorageFileStream isolatedStorageFileStream = isolatedStorageFile.OpenFile($@"{_directory}\User.cfg", FileMode.OpenOrCreate);
            using StreamReader streamReader = new(isolatedStorageFileStream);
            // Using 'ReadToEnd()', since 'ReadToEndAsync()' doesn't return.
            _userSettings = JsonConvert.DeserializeObject<Dictionary<string, object>>(streamReader.ReadToEnd());
        }

        private ValueTask SaveUserSettingsAsync() {
            if (_userSettings is null)
                _userSettings = new();

            using IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
            isolatedStorageFile.CreateDirectory(_directory);
            using IsolatedStorageFileStream isolatedStorageFileStream = isolatedStorageFile.CreateFile($@"{_directory}\User.cfg");
            return isolatedStorageFileStream.WriteAsync(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_userSettings))));
        }
    }

    /// <summary>
    /// Represents event data for when a configuration key got updated.
    /// </summary>
    public class ConfigurationChangedEventArgs : EventArgs {
        /// <summary>
        /// Represents event data for when a configuration key got updated.
        /// </summary>
        /// <param name="key">The configuration key that got updated.</param>
        public ConfigurationChangedEventArgs(string key) {
            Key = key;
        }

        /// <summary>
        /// The configuration key that got updated.
        /// </summary>
        public string Key { get; set; }
    }
}
