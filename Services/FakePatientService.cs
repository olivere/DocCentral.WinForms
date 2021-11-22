using DocCentral.WinForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocCentral.WinForms.Services
{
    public class FakePatientService : IPatientService
    {
        public Task<Patient> GetPatientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SearchPatientsResponse> SearchPatientsAsync(SearchPatientsRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
