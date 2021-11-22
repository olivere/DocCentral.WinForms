using DocCentral.WinForms.Models;
using DocCentral.WinForms.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;

namespace DocCentral.WinForms.ViewModels
{
    public class PatientEditViewModel : ObservableObject
    {
        private readonly ILogger _logger;
        private readonly IPatientService _patientService;

        public PatientEditViewModel(ILogger<PatientEditViewModel> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        public PatientModel Patient
        {
            get => _patient;
            set => SetProperty(ref _patient, value);
        }

        private PatientModel _patient;

        public async Task LoadAsync(int patientId)
        {
            var patient = await _patientService.GetPatientByIdAsync(patientId);
            Patient = new PatientModel(patient);
        }

        public class PatientModel : ObservableValidator
        {
            private readonly Patient _patient;

            public PatientModel(Patient patient)
            {
                _patient = patient;
            }

            public int Id
            {
                get => _patient.Id;
            }

            public string FirstName
            {
                get => _patient.FirstName;
                set => SetProperty(_patient.FirstName, value, _patient, (p, v) => p.FirstName = v);
            }

            public string LastName
            {
                get => _patient.LastName;
                set => SetProperty(_patient.LastName, value, _patient, (p, v) => p.LastName = v);
            }

            public DateTime DateOfBirth
            {
                get => _patient.DateOfBirth;
                set => SetProperty(_patient.DateOfBirth, value, _patient, (p, v) => p.DateOfBirth = v);
            }
        }
    }
}
