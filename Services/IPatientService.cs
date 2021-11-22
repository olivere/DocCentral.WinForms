using DocCentral.WinForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocCentral.WinForms.Services
{
    /// <summary>
    /// Zugriff auf Patientendaten.
    /// </summary>
    public interface IPatientService
    {
        /// <summary>
        /// Gibt die Daten eines Patienten zurück.
        /// </summary>
        /// <param name="id">Id des gesuchten Patienten</param>
        /// <returns><see cref="Patient"</returns>
        Task<Patient> GetPatientByIdAsync(int id);

        /// <summary>
        /// Sucht nach Patienten.
        /// </summary>
        /// <param name="request">Filter für die Suchergebnisse</param>
        /// <returns>Suchergebnis als <see cref="SearchPatientsResponse"/></returns>
        Task<SearchPatientsResponse> SearchPatientsAsync(SearchPatientsRequest request);
    }
}
