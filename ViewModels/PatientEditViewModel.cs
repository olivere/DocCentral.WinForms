using DocCentral.WinForms.Models;
using DocCentral.WinForms.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;

namespace DocCentral.WinForms.ViewModels
{
    /// <summary>
    /// Anzeige und Bearbeitung eines Patienten.
    /// </summary>
    public class PatientEditViewModel : ObservableObject
    {
        private readonly ILogger _logger;
        private readonly IPatientService _patientService;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="logger">Protokollierungsservice</param>
        /// <param name="patientService">Patientenservice</param>
        public PatientEditViewModel(ILogger<PatientEditViewModel> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        /// <summary>
        /// Patient.
        /// </summary>
        public Patient Patient
        {
            get => _patient;
            set => SetProperty(ref _patient, value);
        }

        private Patient _patient;

        /// <summary>
        /// Laden des Patienten anhand seiner Id.
        /// </summary>
        /// <param name="patientId">Id des gesuchten Patienten</param>
        /// <returns><see cref="Task" /></returns>
        public async Task LoadAsync(int patientId)
        {
            var patientDto = await _patientService.GetPatientByIdAsync(patientId);
            Patient = new Patient(patientDto);
        }
    }
}
