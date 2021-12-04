﻿using DocCentral.WinForms.DTOs;
using System;
using System.Collections.Generic;
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
        /// <returns><see cref="PatientDTO"</returns>
        Task<PatientDTO> GetPatientByIdAsync(int id);

        /// <summary>
        /// Sucht nach Patienten.
        /// </summary>
        /// <param name="request">Filter für die Suchergebnisse</param>
        /// <returns>Suchergebnis als <see cref="SearchPatientsResponse"/></returns>
        Task<SearchPatientsResponse> SearchPatientsAsync(SearchPatientsRequest request);

        /// <summary>
        /// Aktualisiert einen bestehenden Patienten. Kommt es beim Aktualisieren zu
        /// einem Fehler, so wird eine Ausnahme geworfen.
        /// </summary>
        /// <param name="request">Zu aktualisierender Patient</param>
        Task UpdateAsync(UpdatePatientRequest request);
    }

    /// <summary>
    /// Anforderung zur Suche nach Patienten.
    /// </summary>
    public class SearchPatientsRequest
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public SearchPatientsRequest()
        {
            Page = 1;
            PageSize = 10;
            Sort = PatientSortOrder.LastNameAsc;
        }

        /// <summary>
        /// Abzurufende Seite (1-basiert).
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Treffer pro Seite (10 im Standard).
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Sortierreihenfolge.
        /// </summary>
        public PatientSortOrder Sort { get; set; }

        /// <summary>
        /// Suchstichwort, welches die Suchergebnisse einschränkt.
        /// </summary>
        public string Keywords { get; set; }
    }

    /// <summary>
    /// Antwort auf eine Suche nach Patienten.
    /// </summary>
    public class SearchPatientsResponse
    {
        /// <summary>
        /// Anzahl der gefundenen Treffer.
        /// </summary>
        public int Found { get; set; }

        /// <summary>
        /// Seite mit Patient, gemäß den in <see cref="SearchPatientsRequest"/>
        /// angegebenen Einschränkungen.
        /// </summary>
        public IList<PatientDTO> Data { get; set; }
    }

    /// <summary>
    /// Anfrage zum Aktualisieren eines Patienten. Wir tun dies anhand einer
    /// eigenen Struktur, um auszudrücken, dass nur bestimmte EIgenschaften
    /// eines Patienten überhaupt aktualisierbar sind (etwa Vorname, Nachname
    /// und Geburtsdatum, nicht aber dessen Id).
    /// </summary>
    public class UpdatePatientRequest
    {
        private int _id;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="id">Id des zu aktualisierenden Patienten</param>
        public UpdatePatientRequest(int id)
        {
            _id = id;
        }

        /// <summary>
        /// Id des zu aktualisierenden Patienten.
        /// </summary>
        public int Id { get => _id; }

        /// <summary>
        /// Setzt den Vornamen des zu aktualisierenden Patienten.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Setzt den Nachname des zu aktualisierenden Patienten.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Setzt das Geburtsdatum des zu aktualisierenden Patienten.
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}
