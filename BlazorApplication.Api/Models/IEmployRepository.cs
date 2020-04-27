using Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApplication.Api.Models
{
    public interface IEmployRepository
    {
        Task<IEnumerable<Employe>> GetEmployes();
        Task<Employe> GetEmploye(int emplyeId);
        Task<Employe> AddEmploye(Employe emplye);
        Task<Employe> UpdateEmploye(Employe emplye);
        void DeleteEmploye(int emplyeId);

    }
}
