using DocCentral.WinForms.DTOs;
using LiteDB;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DocCentral.WinForms.Services
{
    /// <summary>
    /// Implementiert den <see cref="IPatientService"/> mit Hilfe von LiteDB,
    /// einer kleinen, lokalen, serverlosen Datenbank, die in C# geschrieben ist.
    /// </summary>
    public class LiteDBPatientService : IPatientService
    {
        private ILogger _logger;
        private ILiteDBConfiguration _dbConfig;

        /// <summary>
        /// Konstruktor. Dieser Konstruktor wird niemals direkt per <see langword="new"/>
        /// erzeugt, sondern immer über die in <see cref="App"/> definierten Services.
        /// </summary>
        /// <param name="logger">Protokollierungsdienst</param>
        /// <param name="dbConfig">LiteDB Konfiguration</param>
        public LiteDBPatientService(ILogger<LiteDBPatientService> logger, ILiteDBConfiguration dbConfig)
        {
            _logger = logger;
            _dbConfig = dbConfig;

            EnsureValidSchema();
        }

        /// <summary>
        /// Datenbank.
        /// </summary>
        private LiteDatabase Database => _dbConfig.Database;

        /// <summary>
        /// Zugriff auf die Patiententabelle.
        /// </summary>
        private ILiteCollection<PatientDTO> Patients => Database.GetCollection<PatientDTO>("patients");

        /// <summary>
        /// Stellt sicher, dass die Patiententabelle korrekt initialisiert ist.
        /// Ist die Datenbank leer, so werden ein paar Testdaten eingefügt.
        /// </summary>
        private void EnsureValidSchema()
        {
            Patients.EnsureIndex(p => p.FirstName);
            Patients.EnsureIndex(p => p.LastName);

            var count = Patients.Count();
            if (count == 0)
            {
                // Füge ein paar Testdaten ein
                Patients.Insert(PatientDTO.PreviewData);
            }
        }

        /// <summary>
        /// Gibt den Patienten mit der angegebenen Id zurück, oder <see langword="null"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Patient oder <see langword="null"/></returns>
        public Task<PatientDTO> GetPatientByIdAsync(int id)
        {
            return Task.FromResult(Patients.FindById(id));
        }

        /// <summary>
        /// Sucht nach Patientdatendaten.
        /// </summary>
        /// <param name="request">Filter für die Anfrage</param>
        /// <returns>Suchergebnis als <see cref="SearchPatientsResponse"/></returns>
        public Task<SearchPatientsResponse> SearchPatientsAsync(SearchPatientsRequest request)
        {
            return Task.Run(() =>
            {
                // Query für die Gesamtzahl an Treffern zählt
                var countQ = Patients.Query();

                // Query für die Suchergebnisse
                var dataQ = Patients.Query();

                if (!string.IsNullOrWhiteSpace(request.Keywords))
                {
                    Expression<Func<PatientDTO, bool>> expr = p => p.FirstName.Contains(request.Keywords) || p.LastName.Contains(request.Keywords);
                    countQ = countQ.Where(expr);
                    dataQ = dataQ.Where(expr);
                }

                // Sortierung über die Erweiterungsmethode
                dataQ = dataQ.ApplySortOrder(request.Sort);

                // Paginierung:
                // limit muss zwischen 1 und 100 liegen
                // skip muss größer oder gleich 0 sein
                var limit = Math.Max(1, Math.Min(request.PageSize, 100));
                var skip = (Math.Max(1, request.Page)-1) * limit;

                var response = new SearchPatientsResponse()
                {
                    Found = countQ.Count(),
                    Data = dataQ.Offset(skip).Limit(limit).ToList(),
                };
                return response;
            });
        }

        /// <summary>
        /// Aktualisiert einen bestehenden Patienten. Kommt es bei der Aktualisierung
        /// zu einem Fehler, so wird eine Ausnahme geworfen.
        /// </summary>
        /// <param name="request">Zu aktualisierender Patient</param>
        public async Task UpdateAsync(UpdatePatientRequest request)
        {
            var dto = await GetPatientByIdAsync(request.Id);
            dto.FirstName = request.FirstName;
            dto.LastName = request.LastName;
            dto.DateOfBirth = request.DateOfBirth;

            var success = Patients.Update(dto);
            if (!success)
            {
                throw new ApplicationException($"Patient {request.Id} wurde nicht gefunden");
            }
        }
    }

    /// <summary>
    /// Enthält Hilfsmethoden, die die Arbeit mit Patientendaten in LiteDB
    /// vereinfacht.
    /// </summary>
    public static class LiteDBPatientServiceExtensions
    {
        /// <summary>
        /// Wendet die Sortierreihenfolgen auf den Query an.
        /// </summary>
        /// <param name="query">Query für LiteDB</param>
        /// <param name="sortOrders">Sortierreihenfolge</param>
        /// <returns>Modifizierter Query</returns>
        public static ILiteQueryable<PatientDTO> ApplySortOrder(this ILiteQueryable<PatientDTO> query, PatientSortOrder sortOrder)
        {
            switch (sortOrder)
            {
                case PatientSortOrder.IdAsc:
                    query = query.OrderBy(p => p.Id);
                    break;
                case PatientSortOrder.IdDesc:
                    query = query.OrderByDescending(p => p.Id);
                    break;
                case PatientSortOrder.FirstNameAsc:
                    query = query.OrderBy(p => p.FirstName);
                    break;
                case PatientSortOrder.FirstNameDesc:
                    query = query.OrderByDescending(p => p.FirstName);
                    break;
                case PatientSortOrder.LastNameAsc:
                    query = query.OrderBy(p => p.LastName);
                    break;
                case PatientSortOrder.LastNameDesc:
                    query = query.OrderByDescending(p => p.LastName);
                    break;
            }

            return query;
        }
    }
}
