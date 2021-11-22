using DocCentral.WinForms.DTOs;
using DocCentral.WinForms.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocCentral.WinForms.Models
{
    /// <summary>
    /// Ein einzelnes Suchergebnis mit einem Patienten.
    /// Diese Modelle können sich durchaus aus unterschiedlichen Entitäten
    /// zusammensetzen, z.B. einem Patient mit Adresse, Arbeitgeber und
    /// Krankheitsakte.
    /// 
    /// Modelle unterscheiden sich von DTOs dahingehend, dass sie einen Fokus
    /// auf die Nutzung im ViewModel haben. Beispiel: In einem DTO gibt es
    /// nur die Spalten FirstName und LastName. Im ViewModel (und in der UI)
    /// benötigen wir aber oft eine "berechnete" Einschaft mit dem vollständigen
    /// Namen einer Person. Diese Eigenschaft stellen Modelle zur Verfügung,
    /// wie hier etwa durch das <see cref="DisplayName"/>.
    /// </summary>
    public class PatientSearchResult : ObservableObject
    {
        private readonly PatientDTO _patient;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="patient">Patient</param>
        public PatientSearchResult(PatientDTO patient)
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
