using System;
using System.Collections.Generic;

namespace DocCentral.WinForms.Models
{
    /// <summary>
    /// Alle Daten zu einem Patienten. Dies Klassen bilden üblicherweise
    /// das Datenbankmodell 1:1 ab.
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Eindeutige Id des Patienten.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Vorname des Patienten.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nachname des Patienten.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Geburtsdatum des Patienten.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Enthält eine Reihe von Testdaten, die zur Anzeigen oder
        /// initialem Befüllen von leeren Datenbanken dienen.
        /// </summary>
        public static Patient[] PreviewData
        {
            get
            {
                var previewData = new List<Patient>();

                previewData.Add(new Patient() { FirstName = "Oliver", LastName = "Eilhard", DateOfBirth = new DateTime(1998, 1, 4) });
                previewData.Add(new Patient() { FirstName = "Peter", LastName = "Sauter", DateOfBirth = new DateTime(1986, 6, 24) });
                previewData.Add(new Patient() { FirstName = "Oliver", LastName = "Bulling", DateOfBirth = new DateTime(1988, 12, 6) });
                previewData.Add(new Patient() { FirstName = "Horst", LastName = "Boschner", DateOfBirth = new DateTime(1984, 10, 3) });

                previewData.Add(new Patient() { FirstName = "Ben", LastName = "Bogenmann", DateOfBirth = new DateTime(1984, 6, 1) });
                previewData.Add(new Patient() { FirstName = "Emma", LastName = "Erkner", DateOfBirth = new DateTime(1984, 3, 4) });
                previewData.Add(new Patient() { FirstName = "Lisa", LastName = "Leipziger", DateOfBirth = new DateTime(1984, 4, 26) });
                previewData.Add(new Patient() { FirstName = "Georg", LastName = "Gruner", DateOfBirth = new DateTime(1984, 11, 25) });
                previewData.Add(new Patient() { FirstName = "Werner", LastName = "Wagenschmid", DateOfBirth = new DateTime(1984, 12, 24) });
                previewData.Add(new Patient() { FirstName = "Fritz", LastName = "Fellner", DateOfBirth = new DateTime(1984, 8, 8) });
                previewData.Add(new Patient() { FirstName = "Benjamin", LastName = "Bock", DateOfBirth = new DateTime(1984, 5, 9) });
                previewData.Add(new Patient() { FirstName = "Rosa", LastName = "Elefant", DateOfBirth = new DateTime(1984, 7, 13) });
                previewData.Add(new Patient() { FirstName = "Peter", LastName = "Obermeier", DateOfBirth = new DateTime(1984, 1, 18) });
                previewData.Add(new Patient() { FirstName = "Olaf", LastName = "Merk", DateOfBirth = new DateTime(1984, 2, 13) });

                previewData.Add(new Patient() { FirstName = "Regine", LastName = "Regenbogen", DateOfBirth = new DateTime(1984, 11, 28) });
                previewData.Add(new Patient() { FirstName = "Maria", LastName = "Margenthaler", DateOfBirth = new DateTime(1984, 12, 23) });
                previewData.Add(new Patient() { FirstName = "Elisabeth", LastName = "Wolf", DateOfBirth = new DateTime(1984, 3, 17) });
                previewData.Add(new Patient() { FirstName = "Irene", LastName = "Underberg", DateOfBirth = new DateTime(1984, 5, 19) });
                previewData.Add(new Patient() { FirstName = "Isa", LastName = "Bill", DateOfBirth = new DateTime(1984, 8, 5) });
                previewData.Add(new Patient() { FirstName = "Karin", LastName = "Krisch", DateOfBirth = new DateTime(1984, 8, 11) });
                previewData.Add(new Patient() { FirstName = "Xose", LastName = "de la Viera", DateOfBirth = new DateTime(1984, 9, 13) });
                previewData.Add(new Patient() { FirstName = "Verena", LastName = "Born", DateOfBirth = new DateTime(1984, 11, 23) });
                previewData.Add(new Patient() { FirstName = "Clara", LastName = "Clausewitz", DateOfBirth = new DateTime(1984, 3, 2) });
                previewData.Add(new Patient() { FirstName = "Evelyn", LastName = "Pöhl", DateOfBirth = new DateTime(1984, 1, 31) });

                return previewData.ToArray();
            }
        }
    }

    /// <summary>
    /// Sortierreihenfolge bei Search- oder Find-Operationen.
    /// </summary>
    public enum PatientSortOrder
    {
        /// <summary>
        /// Sortierung nach Id, aufsteigend (A-Z).
        /// </summary>
        IdAsc,
        /// <summary>
        /// Sortierung nach Id, absteigend (Z-A).
        /// </summary>
        IdDesc,
        /// <summary>
        /// Sortierung nach Vorname, aufstreigend (A-Z).
        /// </summary>
        FirstNameAsc,
        /// <summary>
        /// Sortierung nach Vorname, absteigend (Z-A).
        /// </summary>
        FirstNameDesc,
        /// <summary>
        /// Sortierung nach Nachname, aufstreigend (A-Z).
        /// </summary>
        LastNameAsc,
        /// <summary>
        /// Sortierung nach Nachname, absteigend (Z-A).
        /// </summary>
        LastNameDesc,
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
        public IList<Patient> Data { get; set; }
    }
}
