using Blazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApplication.Api.Models
{
    public class EmployRepository : IEmployRepository
    {

        private readonly AppDbContext appDbContext;
        public EmployRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Employe>> GetEmployes()
        {
            return await appDbContext.Employes.ToListAsync();
        }
        public async Task<Employe> AddEmploye(Employe emplye)
        {
            var result = await appDbContext.Employes.AddAsync(emplye);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteEmploye(int emplyeId)
        {
            var result = await appDbContext.Employes.FirstOrDefaultAsync(e => e.EmployeID == emplyeId);
            if (result != null)
            {
                appDbContext.Employes.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
            
            
        }

        public async Task<Employe> GetEmploye(int emplyeId)
        {
            return await appDbContext.Employes.FirstOrDefaultAsync(e => e.EmployeID == emplyeId);

        }



        public async Task<Employe> UpdateEmploye(Employe emplye)
        {
          var result =   await appDbContext.Employes.FirstOrDefaultAsync(e => e.EmployeID == emplye.EmployeID);
            if(result!=null)
            {
                result.Name = emplye.Name;
                result.Salary = emplye.Salary;
                result.Age = result.Age;
                await appDbContext.SaveChangesAsync();
                return result ;
            }

            return null;
        }
    }
}
