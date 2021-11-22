using DocCentral.WinForms.DTOs;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace DocCentral.WinForms.Models
{
    /// <summary>
    /// Ein einzelner Patient als Modell. Es setzt sich aus dem DTO für den
    /// Patienten zusammen. Während die DTOs dumm sind, kommt hier noch eine
    /// Validierungslogik und die Möglichkeit des Data Bindings hinzu.
    /// </summary>
    public class Patient: ObservableValidator
    {
        private readonly PatientDTO _patient;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="patient">Patient als DTO</param>
        public Patient(PatientDTO patient)
        {
            _patient = patient;
        }

        /// <summary>
        /// Eindeutige Id des Patienten.
        /// </summary>
        public int Id
        {
            get => _patient.Id;
        }

        /// <summary>
        /// Vorname.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string FirstName
        {
            get => _patient.FirstName;
            set => SetProperty(_patient.FirstName, value, _patient, (p, v) => p.FirstName = v);
        }

        /// <summary>
        /// Nachname.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string LastName
        {
            get => _patient.LastName;
            set => SetProperty(_patient.LastName, value, _patient, (p, v) => p.LastName = v);
        }

        /// <summary>
        /// Geburtsdatum.
        /// </summary>
        [Required]
        public DateTime DateOfBirth
        {
            get => _patient.DateOfBirth;
            set => SetProperty(_patient.DateOfBirth, value, _patient, (p, v) => p.DateOfBirth = v);
        }
    }
}
