using DocCentral.WinForms.DTOs;
using System;
using System.Threading.Tasks;

namespace DocCentral.WinForms.Services
{
    /// <summary>
    /// Eine Implementierung der Schnittstelle <see cref="IPatientService"/>
    /// für Unit-Tests.
    /// </summary>
    public class FakePatientService : IPatientService
    {
        public Task<PatientDTO> GetPatientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SearchPatientsResponse> SearchPatientsAsync(SearchPatientsRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
