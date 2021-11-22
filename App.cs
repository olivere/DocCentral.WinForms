using DocCentral.WinForms.Services;
using DocCentral.WinForms.ViewModels;
using LiteDB;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace DocCentral.WinForms
{
    /// <summary>
    /// App dient als globale Klasse für alle Eigenschaften der Anwendung,
    /// zum Beispiel für den Zugriff auf Services.
    /// </summary>
    public sealed class App
    {
        /// <summary>
        /// Initialisiert die Instanz der App.
        /// </summary>
        private App()
        {
            Host = Configure();
        }

        /// <summary>
        /// Stellt den Zugriff auf die Applikationsklasse bereit.
        /// </summary>
        public static App Current => new App();

        /// <summary>
        /// Gibt den Host zurück, über den die Anwendung initialisiert wurde.
        /// </summary>
        public IHost Host { get; }

        /// <summary>
        /// Stellt Zugriff auf alle bereitgestellten Dienste zur Verfügung.
        /// </summary>
        public IServiceProvider Services => Host.Services;

        /// <summary>
        /// Gibt den Service zurück, oder <see langword="null"/> falls der Service nicht gefunden wurde.
        /// </summary>
        /// <typeparam name="T">Typ des Services</typeparam>
        /// <returns>Service oder <see langword="null"/></returns>
        public T GetService<T>()
        {
            return Services.GetService<T>();
        }

        /// <summary>
        /// Gibt den Service zurück.
        /// </summary>
        /// <typeparam name="T">Typ des Services</typeparam>
        /// <returns>Service</returns>
        public T GetRequiredService<T>()
        {
            return Services.GetRequiredService<T>();
        }

        /// <summary>
        /// Konfiguriert die Dienste, die der Anwendung überall im Form von
        /// Interfaces zur Verfügung stehen. Dies geschieht durch Verwendung
        /// eines Inversion-of-Control (IoC) Containers.
        /// </summary>
        /// <returns><see cref="IServiceProvider"</returns>
        /// <seealso cref="https://docs.microsoft.com/en-us/windows/communitytoolkit/mvvm/ioc"/>
        private static IHost Configure()
        {
            var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder().
                ConfigureLogging((logging) => logging.AddConsole()).
                ConfigureServices((context, services) => ConfigureServices(context, services)).
                Build();

            return host;
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            //services.AddLogging(logging => logging.AddConsole());

            // Services für den Zugriff auf Patientendaten konfigurieren
            var db = new LiteDatabase(":memory:");
            services.AddSingleton<ILiteDBConfiguration>(new LiteDBConfiguration(db));
            services.AddSingleton<IPatientService, LiteDBPatientService>();

            // Konfiguriere Zugriff auf ViewModel von den Views aus
            services.AddTransient<ShellViewModel>();
            services.AddTransient<PatientsSearchViewModel>();
            services.AddTransient<PatientEditViewModel>();

            // ShellView
            services.AddTransient<ShellView>();
        }
    }
}
