using DivinitySoftworks.Apps.Core.Configuration;
using DivinitySoftworks.Apps.Core.Configuration.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace DivinitySoftworks.Apps.Core {

    /// <summary>
    /// The base application class for all Divinity Softworks applications. Follow the following steps to implement.
    /// <br />- Make sure you have an AppSettings class, and IAppSettings interface in your project. The interface should implement <see cref="IAppSettings"/>, the class should implement the interface you created. 
    /// </summary>
    /// <typeparam name="I">The IAppSettings interface that implements <see cref="IAppSettings"/>.</typeparam>
    /// <typeparam name="A">The AppSettings class that implements the custom interface that implements <see cref="IAppSettings"/>.</typeparam>
    public class App<I, A> : Application where I : IAppSettings where A : IAppSettings {

        IServiceProvider? _serviceProvider = null;
        /// <summary>
        /// The mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
        /// </summary>
        public IServiceProvider ServiceProvider {
            get {
                if (_serviceProvider is null) throw new NullReferenceException(nameof(ServiceProvider));
                return _serviceProvider;
            }
            private set {
                _serviceProvider = value;
            }
        }

        IConfiguration? _configuration = null;
        /// <summary>
        /// Represents a set of key/value application configuration properties.
        /// </summary>
        public IConfiguration Configuration {
            get {
                if (_configuration is null) throw new NullReferenceException(nameof(Configuration));
                return _configuration;
            }
            private set {
                _configuration = value;
            }
        }

        /// <inheritdoc/>
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", false, true)
                .Build();

            ServiceCollection serviceCollection = new();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// Configures the services required by the application.
        /// </summary>
        /// <param name="services">The mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <exception cref="NullReferenceException">The loaded configurations does not contain an 'AppSettings' section.</exception>
        protected virtual void ConfigureServices(IServiceCollection services) {
            A appSettings = Configuration.GetSection("AppSettings").Get<A>();
            if (appSettings is null) throw new NullReferenceException("Invalid [AppSettings.json] file. It is missing the 'AppSettings' section.");

            services.AddSingleton(typeof(I), appSettings);
            services.AddSingleton<IConfigurationManager, Configuration.Managers.ConfigurationManager>();
        }
    }
}
