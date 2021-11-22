using DocCentral.WinForms.Models;
using DocCentral.WinForms.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DocCentral.WinForms.ViewModels
{
    /// <summary>
    /// Dieses ViewModel bildet die gesamte Logik für einen View ab, der
    /// auf Eingabe des Benutzers nach Patienten sucht und diese dann etwa
    /// tabellarisch darstellt. Das Ziel ist es, den "View" dumm zu halten
    /// und das "ViewModel" schlau.
    /// </summary>
    public class PatientsSearchViewModel : ObservableObject
    {
        private readonly ILogger _logger;
        private readonly IPatientService _patientService;
        private readonly SearchPatientsRequest _lastSearchRequest;
        private SearchPatientsResponse _lastSearchResponse;

        /// <summary>
        /// Konstruktor des ViewModels. Das ViewModel wird niemals direkt mit
        /// <see langword="new"/> erzeugt, sondern immer über
        /// <see cref="App.Current.GetRequiredService"/>. Dadurch kann man an
        /// zentraler Stelle die Services konfigurieren und muss nicht überall
        /// den Code ändern, wenn man einen Service durch eine andere Implementation
        /// auswechselt.
        /// </summary>
        /// <param name="logger">Protokollierungsdienst</param>
        /// <param name="patientService">Dienst zum Zugriff auf Patienten</param>
        public PatientsSearchViewModel(ILogger<PatientsSearchViewModel> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
            _lastSearchRequest = new SearchPatientsRequest();
            _lastSearchResponse = new SearchPatientsResponse();
        }

        /// <summary>
        /// Gibt an, ob sich das ViewModel im Initialzustand befindet.
        /// Dieser ist für die Patientensuche dadurch gegeben, dass das
        /// Fenster gerade geöffnet und noch keine Suche durchgeführt wurde.
        /// </summary>
        public bool Blankslate
        {
            get => _blankslate;
            set => SetProperty(ref _blankslate, value);
        }

        public bool NotBlankslate => !Blankslate;

        private bool _blankslate = true;

        /// <summary>
        /// Anzahl Treffer in der letzten Suche.
        /// </summary>
        public int Matches
        {
            get => _lastSearchResponse.Found;
        }

        /// <summary>
        /// Aktuelle Seite, beginnend mit 1.
        /// </summary>
        public int Page
        {
            get => _lastSearchRequest.Page;
            set => SetProperty(_lastSearchRequest.Page, value, _lastSearchRequest, (r, v) => r.Page = v);
        }

        /// <summary>
        /// Aktuelle Seitengröße.
        /// </summary>
        public int PageSize
        {
            get => _lastSearchRequest.PageSize;
            set => SetProperty(_lastSearchRequest.PageSize, value, _lastSearchRequest, (r, v) => r.PageSize = v);
        }

        /// <summary>
        /// Gibt es eine vorherige Seite?
        /// </summary>
        public bool HasPreviousPage
        {
            get => Page > 1;
        }

        /// <summary>
        /// Gibt es eine nächste Seite?
        /// </summary>
        public bool HasNextPage
        {
            get => Matches > (Page - 1) * PageSize + PageSize;
        }

        /// <summary>
        /// Text für die Paginierung: 1-10 von 100.
        /// </summary>
        public string Paginator
        {
            get {
                if (Matches == 0)
                {
                    return "Keine Treffer";
                }
                var x = 1 + ((Page - 1) * PageSize);
                var y = x + Math.Min(PageSize, Results.Count) - 1;
                return $"{x}-{y} von {Matches}";
            }
        }

        /// <summary>
        /// Treffer im Suchergebnis.
        /// </summary>
        public ObservableCollection<SearchResult> Results
        {
            get => _results;
            set => SetProperty(ref _results, value);
        }

        private ObservableCollection<SearchResult> _results;

        /// <summary>
        /// Suchstichwort des Benutzers. Diese Eigenschaft wird im View
        /// z. B. auf die Eigenschaft <see cref="TextBox.Text"/> gemapped.
        /// </summary>
        public string Keywords
        {
            get => _keywords;
            set => SetProperty(ref _keywords, value);
        }

        private string _keywords;

        /// <summary>
        /// Startet eine Suche nach Patienten.
        /// </summary>
        /// <returns><see cref="Task"/></returns>
        public async Task SearchAsync()
        {
            _logger.LogDebug($"Starte suche nach {Keywords}");

            _lastSearchRequest.Keywords = Keywords;
            _lastSearchRequest.Page = 1;

            await ExecuteSearchAsync();

            _logger.LogDebug($"Suche nach {Keywords} beendet: ${Matches} Treffer");
        }

        /// <summary>
        /// Führt die Suche aus und aktualisiert danach die verschiedenen Properties.
        /// </summary>
        /// <returns></returns>
        private async Task ExecuteSearchAsync()
        {
            _lastSearchResponse = await _patientService.SearchPatientsAsync(_lastSearchRequest);

            Results = new ObservableCollection<SearchResult>(
                _lastSearchResponse.Data.Select(p => new SearchResult(p))
            );
            Blankslate = false;
        }

        /// <summary>
        /// Zur nächsten Seite.
        /// </summary>
        /// <returns></returns>
        public async Task NextPageAsync()
        {
            _lastSearchRequest.Page++;
            await ExecuteSearchAsync();
        }

        /// <summary>
        /// Zur vorherigen Seite.
        /// </summary>
        /// <returns></returns>
        public async Task PreviousPageAsync()
        {
            _lastSearchRequest.Page--;
            await ExecuteSearchAsync();
        }

        /// <summary>
        /// Ein einzelnes Suchergebnis. Diese Modelle können sich durchaus
        /// aus unterschiedlichen Entitäten zusammensetzen, z.B. einem Patient
        /// mit Adresse, Arbeitgeber und Krankheitsakte.
        /// </summary>
        public class SearchResult : ObservableObject
        {
            private readonly Patient _patient;

            /// <summary>
            /// Konstruktor.
            /// </summary>
            /// <param name="patient">Patient</param>
            public SearchResult(Patient patient)
            {
                _patient = patient;
            }

            /// <summary>
            /// Id des Patienten.
            /// </summary>
            public int Id => _patient.Id;

            /// <summary>
            /// Zusammengesetzter Name aus Vor- und Nachname.
            /// </summary>
            public string DisplayName => $"{_patient.FirstName} {_patient.LastName}";

            /// <summary>
            /// Geburtsdatum bestehend aus Tag, Monat und Jahr.
            /// </summary>
            public string DateOfBirthFormatted => _patient.DateOfBirth.ToString("d");
        }
    }
}
