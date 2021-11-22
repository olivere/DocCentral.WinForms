using System;
using System.Collections.Generic;

namespace DocCentral.WinForms.DTOs
{
    /// <summary>
    /// Alle Daten zu einem Patienten. Dies Klassen bilden üblicherweise
    /// das Datenbankmodell 1:1 ab.
    /// </summary>
    public class PatientDTO
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
        public static PatientDTO[] PreviewData
        {
            get
            {
                var previewData = new List<PatientDTO>();

                previewData.Add(new PatientDTO() { FirstName = "Oliver", LastName = "Eilhard", DateOfBirth = new DateTime(1998, 1, 4) });
                previewData.Add(new PatientDTO() { FirstName = "Peter", LastName = "Sauter", DateOfBirth = new DateTime(1986, 6, 24) });
                previewData.Add(new PatientDTO() { FirstName = "Oliver", LastName = "Bulling", DateOfBirth = new DateTime(1988, 12, 6) });
                previewData.Add(new PatientDTO() { FirstName = "Horst", LastName = "Boschner", DateOfBirth = new DateTime(1984, 10, 3) });

                previewData.Add(new PatientDTO() { FirstName = "Ben", LastName = "Bogenmann", DateOfBirth = new DateTime(1984, 6, 1) });
                previewData.Add(new PatientDTO() { FirstName = "Emma", LastName = "Erkner", DateOfBirth = new DateTime(1984, 3, 4) });
                previewData.Add(new PatientDTO() { FirstName = "Lisa", LastName = "Leipziger", DateOfBirth = new DateTime(1984, 4, 26) });
                previewData.Add(new PatientDTO() { FirstName = "Georg", LastName = "Gruner", DateOfBirth = new DateTime(1984, 11, 25) });
                previewData.Add(new PatientDTO() { FirstName = "Werner", LastName = "Wagenschmid", DateOfBirth = new DateTime(1984, 12, 24) });
                previewData.Add(new PatientDTO() { FirstName = "Fritz", LastName = "Fellner", DateOfBirth = new DateTime(1984, 8, 8) });
                previewData.Add(new PatientDTO() { FirstName = "Benjamin", LastName = "Bock", DateOfBirth = new DateTime(1984, 5, 9) });
                previewData.Add(new PatientDTO() { FirstName = "Rosa", LastName = "Elefant", DateOfBirth = new DateTime(1984, 7, 13) });
                previewData.Add(new PatientDTO() { FirstName = "Peter", LastName = "Obermeier", DateOfBirth = new DateTime(1984, 1, 18) });
                previewData.Add(new PatientDTO() { FirstName = "Olaf", LastName = "Merk", DateOfBirth = new DateTime(1984, 2, 13) });

                previewData.Add(new PatientDTO() { FirstName = "Regine", LastName = "Regenbogen", DateOfBirth = new DateTime(1984, 11, 28) });
                previewData.Add(new PatientDTO() { FirstName = "Maria", LastName = "Margenthaler", DateOfBirth = new DateTime(1984, 12, 23) });
                previewData.Add(new PatientDTO() { FirstName = "Elisabeth", LastName = "Wolf", DateOfBirth = new DateTime(1984, 3, 17) });
                previewData.Add(new PatientDTO() { FirstName = "Irene", LastName = "Underberg", DateOfBirth = new DateTime(1984, 5, 19) });
                previewData.Add(new PatientDTO() { FirstName = "Isa", LastName = "Bill", DateOfBirth = new DateTime(1984, 8, 5) });
                previewData.Add(new PatientDTO() { FirstName = "Karin", LastName = "Krisch", DateOfBirth = new DateTime(1984, 8, 11) });
                previewData.Add(new PatientDTO() { FirstName = "Xose", LastName = "de la Viera", DateOfBirth = new DateTime(1984, 9, 13) });
                previewData.Add(new PatientDTO() { FirstName = "Verena", LastName = "Born", DateOfBirth = new DateTime(1984, 11, 23) });
                previewData.Add(new PatientDTO() { FirstName = "Clara", LastName = "Clausewitz", DateOfBirth = new DateTime(1984, 3, 2) });
                previewData.Add(new PatientDTO() { FirstName = "Evelyn", LastName = "Pöhl", DateOfBirth = new DateTime(1984, 1, 31) });

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
}
